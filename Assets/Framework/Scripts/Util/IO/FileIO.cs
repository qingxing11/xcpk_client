using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using FairyGUI;

/// <summary>
/// 文件io类，已根据资源类型分配路径
///  
///  <para>Wangtuo </para>
///  
/// </summary>
/// 

public class FileIO
{
    private static bool isABDebug = false;

    private static bool isAbLoadDebug = false;


#if UNITY_EDITOR
    /// <summary>
    /// 是否编辑器环境(开发模式)
    /// </summary>
    public static readonly bool isEditor = true;
#elif UNITY_STANDALONE
    public static readonly bool isEditor = true;
#else
    public static readonly bool isEditor = true;
#endif



#if UNITY_STANDALONE || UNITY_EDITOR

#if UNITY_STANDALONE
    public static readonly string platform_path = "/windows/";
    public static readonly string platform = "windows";
#elif UNITY_ANDROID
    public static readonly string platform = "Android";
    public static readonly string platform_path = "/Android/";
#elif UNITY_IPHONE
    public static readonly string platform = "IOS";
    public static readonly string platform_path = "/IOS/";
#endif
    /// <summary>
    /// 更新文件读取路径
    /// </summary>
    public static readonly string PathURL = Application.streamingAssetsPath + platform_path;

    /// <summary>
    /// xlua热更新路径
    /// </summary>
    public static readonly string HOTFIX_LUA_REMOTE_PATH = "Hotfix/src/";

#elif UNITY_ANDROID
    public static readonly string platform = "Android";
    public static readonly string platform_path ="/Android/";
    public static readonly string PathURL = Application.persistentDataPath + platform_path;

    public static readonly string HOTFIX_LUA_REMOTE_PATH = PathURL + "src/";     

#elif UNITY_IPHONE
    public static readonly string platform = "IOS";
    public static readonly string platform_path = "/IOS/";


#if UNITY_EDITOR
	public static readonly string PathURL = Application.streamingAssetsPath + platform_path;
#else
    public static readonly string PathURL = Application.persistentDataPath + platform_path;
#endif

         /// <summary>
    /// xlua热更新路径
    /// </summary>
  public static readonly string HOTFIX_LUA_REMOTE_PATH = PathURL + "src/";
#else
    public static readonly string PathURL = string.Empty;
#endif



    /// <summary>
    /// lua pb文件路径
    /// </summary>
    public static readonly string HOTFIX_LUA_PB_PATH = Application.streamingAssetsPath + "/Hotfix/lua/pb/";

    public static readonly string HOTFIX_LUA_LOCAL_PATH = Application.streamingAssetsPath + platform_path + "src/";


    public static readonly string Remote_AssetBunlde_PATH = PathURL;

    /// <summary>
    /// 发布后的本地目录，所有端都以streamingAssetsPath为ab资源默认目录
    /// </summary>
    public static readonly string Local_AssetBunlde_PathURL = Application.streamingAssetsPath + platform_path;

    /// <summary>
    /// pc编辑器环境临时存档路径
    /// </summary>
    public static readonly string SAVE_DATA_PATH = "Save/";

    /// <summary>
    /// ab资源缓存
    /// </summary>
    private static Dictionary<string, AssetBundle> map_ab = new Dictionary<string, AssetBundle>();

    /// <summary>
    /// 预制体缓存
    /// </summary>
    private static Dictionary<string, GameObject> map_gameObject = new Dictionary<string, GameObject>();

    /// <summary>
    /// 精灵缓存
    /// </summary>
    private static Dictionary<string, Sprite> map_sprite = new Dictionary<string, Sprite>();

    /// <summary>
    /// 声音缓存
    /// </summary>
    private static Dictionary<string, AudioClip> map_audioClip = new Dictionary<string, AudioClip>();

    private static Dictionary<string, Material> map_material = new Dictionary<string, Material>();

    private static Dictionary<string, Texture2D> map_texture2d = new Dictionary<string, Texture2D>();

    private static AssetBundleManifest assetBundleManifest;
    /// <summary>
    ///	热更新结束后清理旧资源对象
    /// </summary>
    public static void ClearAssetBundleManifest()
    {
        assetBundleManifest = null;


        foreach (var item in map_ab)
        {
            item.Value.Unload(true);
        }
        map_ab.Clear();


        map_gameObject.Clear();
        map_sprite.Clear();
        map_audioClip.Clear();
    }

    public static Material LoadMaterial(int index)
    {
        return LoadMaterial(R.Materials.path[index]);
    }
    public static Material LoadMaterial(string abName)
    {
        Material material = map_material.GetValue(abName);
        if (isEditor && material == null)
        {
            material = Resources.Load<Material>(abName);
        }

        if (material == null)
        {
            //string[] spriteNameArr = abName.Split('/');

            //string name = abName.Substring(0, abName.Length - spriteNameArr[spriteNameArr.Length - 1].Length - 1);
            string name = abName;

            AssetBundle ab = LoadAssetBundle(name);//
            if (ab == null)
            {
                return null;
            }
            string[] spriteNameArr = abName.Split('/');

            material = ab.LoadAsset<Material>(spriteNameArr[spriteNameArr.Length - 1]);
            if (material != null)
            {
                map_material.Add(abName, material);
            }
        }

        return material;
    }

    /// <summary>
    /// 从网络获取Sprite
    /// </summary>
    /// <param name="url"></param>
    /// <param name="sourceW"></param>
    /// <param name="sourceH"></param>
    public static Sprite LoadSpriteByNetwork(string url, int w, int h)
    {
        byte[] imgData = NetworkIO.HttpGetByWWW(url);
        if (imgData == null || imgData.Length == 0)
        {
            Debug.LogError("网络加载图片失败:" + url);
            return null;
        }
        Texture2D texture2 = new Texture2D(w, h, TextureFormat.ARGB32, false);



        Sprite sprite = null;
        try
        {
            texture2.LoadImage(imgData);
            texture2.Apply();

            sprite = Sprite.Create(texture2, new Rect(0, 0, w, h), Vector2.zero);
        }
        catch (Exception e)
        {
            Debug.LogError("创建网络Srpite失败,url" + url + "期望宽高,w:" + w + ",h:" + h + ",纹理宽高,w:" + texture2.width + "," + texture2.height + ",Exception:" + e);
            return null;
        }

        return sprite;
    }

    /// <summary>
    /// 根据指定分辨率重新创建纹理
    /// </summary>
    /// <param name="source"></param>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <returns></returns>
    public static Texture2D LoadTexture2D(Texture2D source, int w, int h)
    {
        Texture2D texture2 = new Texture2D(w, h, source.format, false);
        for (int i = 0; i < texture2.height; i++)
        {
            for (int j = 0; j < texture2.width; j++)
            {
                Color newColor = source.GetPixelBilinear(j / texture2.width, i / texture2.height);
                texture2.SetPixel(j, i, newColor);
            }
        }
        texture2.Apply();
        return texture2;
    }


    /// <summary>
    /// 尝试从缓存中读取ab资源。 如未缓存，则同步加载并缓存
    /// 1.尝试缓存中读取，如没有
    /// 2.尝试读取ab文件，加载AssetBundleManifest
    /// 3.根据AssetBundleManifest加载所有依赖
    /// 4.加载目标AssetBundle
    /// </summary>
    /// <param name="abName"></param>
    /// <returns></returns>
    public static GameObject LoadPrefab(string abName)
    {
        abName = abName.Replace('\\', '/');
        GameObject gameObject = map_gameObject.GetValue(abName);
        if (isABDebug)
            Debug.Log("LoadPrefab--->abName:" + abName + ",gameObject:" + gameObject);

        if (gameObject == null)
        {
            if (isABDebug)
                Debug.Log("LoadPrefab--->缓存中没有gameobj,是否编辑器环境加载:" + isEditor);
            if (isEditor && gameObject == null)
            {
                gameObject = Resources.Load(abName) as GameObject;//只有开发时
            }

            if (gameObject == null)
            {
                AssetBundle obj = map_ab.GetValue(abName);

                if (obj == null)
                {
                    List<AssetBundle> list_Dependencies = LoadDependencies(abName);//加载所有依赖
                    if (list_Dependencies == null)
                    {
                        if (isABDebug)
                            Debug.Log(abName + "的依赖加载失败");
                        return null;
                    }

                    obj = LoadAssetBundle(abName);//加载自己
                    if (obj == null)
                    {
                        return null;
                    }

                    string[] abnames = abName.Split('/');

                    string assetName = abnames[abnames.Length - 1];
                    if (isABDebug)Debug.Log("LoadPrefab--->assetName:" + assetName);
                    gameObject = obj.LoadAsset<GameObject>(assetName);
                    //obj.Unload(true);

                    if (gameObject == null)
                    {
                        Debug.LogError("读取[" + abName + "]异常!");
                    }
                    else
                    {
                        map_gameObject.Add(abName, gameObject);
                    }
                }
            }
        }
        return gameObject;
    }

    /// <summary>
    /// 加载预制体类型ab资源,优先检查远程下载目录，如果为空，随后检查：
    /// 移动端:streamingAssetsPath;编辑器开发环境:Resources
    /// </summary>
    /// <param name="abIndex"></param>
    /// <returns></returns>
    public static GameObject LoadPrefab(int abIndex)
    {
        string abName = R.Prefab.path[abIndex];
        GameObject gameObject = LoadPrefab(abName);//读ab
        return gameObject;
    }

    private static StringBuilder sb = new StringBuilder();

    /// <summary>
    /// 加载ui包，线程不安全
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns> 
    public static UIPackage LoadFairyGUI(int index)
    {
        string uiPath = R.UI.path[index];

        UIPackage uIPackage = null;
        try
        {
            if (isEditor)
            {
                uIPackage = UIPackage.AddPackage(uiPath);//编辑器模式优先考虑Resources
            }
            else
            {
                uIPackage = UIPackage.AddPackage(LoadAssetBundle(uiPath));
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning("默认方式加载UI包:[" + uiPath + "]错误,尝试其他!堆栈:" + e);
        }

        try
        {
            if (uIPackage == null)
            {
                if (!isEditor)
                {
                    string[] pathSplit = uiPath.Split('/');
                    sb.Clear();
                    sb.Append(uiPath);
                    sb.Append("/");
                    sb.Append(pathSplit[pathSplit.Length - 1]);

                    uIPackage = UIPackage.AddPackage(sb.ToString());
                }
                else
                {
                    uIPackage = UIPackage.AddPackage(LoadAssetBundle(uiPath));
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("加载UI包:[" + uiPath + "]错误,退出!堆栈:" + e);
            return null;
        }

        if (isABDebug)
            Debug.Log("uiPath:" + uiPath);

        string[] pathAndName = uiPath.Split('/');
        string name = pathAndName[pathAndName.Length - 1];


        sb.Clear();

        sb.Append(name);
        sb.Append(".");
        sb.Append(name);
        sb.Append("Binder");
         

        Type t = Type.GetType(sb.ToString());
        if (t == null)
        {
            throw new Exception("加载FairyGUI时，script为空,类名:" + sb);
        }
        MethodInfo method = t.GetMethod("BindAll");
        method.Invoke(null, null);
        return uIPackage;
    }

    public static void DisposeTexture2D(int index)
    {
        string spriteName = R.Texture.path[index];
        if (map_texture2d.ContainsKey(spriteName))
        {
            map_texture2d.Remove(spriteName);
        }
    }

    public static Texture2D LoadTexture2D(int spriteIndex)
    {
        string spriteName = R.Texture.path[spriteIndex];
        if(isABDebug)Debug.Log("LoadTexture2D->spriteName:"+ spriteName);
        Texture2D sprite = LoadTexture2D(spriteName);

        return sprite;
    }



    public static Texture2D LoadTexture2D(string spriteName)
    {
        spriteName = spriteName.Replace('\\', '/');
        Texture2D sprite = map_texture2d.GetValue(spriteName);
        if (isEditor && sprite == null)
        {
            sprite = Resources.Load<Texture2D>(spriteName);
        }

        if (sprite == null)
        {
             
            string[] spriteNameArr = spriteName.Split('/');

            //string name = spriteName.Substring(0, spriteName.Length - spriteNameArr[spriteNameArr.Length - 1].Length - 1);

            string name = spriteName;

            AssetBundle ab = LoadAssetBundle(name);//
            if (ab == null)
            {
                return null;
            }
            string assetName = spriteNameArr[spriteNameArr.Length - 1];
            if (isABDebug) Debug.Log("assetName:" + assetName);
            sprite = ab.LoadAsset<Texture2D>(assetName);
            if (sprite != null)
            {
                map_texture2d.Add(spriteName, sprite);
            }
        }

        return sprite;
    }


    public static Texture2D LoadSpritePackTexture(int spriteIndex)
    {
        string spriteName = R.SpritePack.path[spriteIndex];
        if (isABDebug) Debug.Log("LoadTexture2D->spriteName:" + spriteName);
        Texture2D sprite = LoadSpritePackTexture(spriteName);
        return sprite;
    }

    public static Texture2D LoadSpritePackTexture(string spriteName)
    {
        spriteName = spriteName.Replace('\\', '/');
        Texture2D sprite = map_texture2d.GetValue(spriteName);
        if (isEditor && sprite == null)
        {
            sprite = Resources.Load<Texture2D>(spriteName);
        }

        if (sprite == null)
        {
             
            string[] spriteNameArr = spriteName.Split('/');

            string name = spriteName.Substring(0, spriteName.Length - spriteNameArr[spriteNameArr.Length - 1].Length - 1);
            if (isABDebug) Debug.Log("LoadSpritePackTexture--->name:" + name);

            AssetBundle ab = LoadAssetBundle(name);//
            if (ab == null)
            {
                return null;
            }
            string assetName = spriteNameArr[spriteNameArr.Length - 1];
            if (isABDebug) Debug.Log("LoadSpritePackTexture--->assetName:" + assetName+ ",ab:"+ ab);
            sprite = ab.LoadAsset<Texture2D>(assetName);
            if (isABDebug) Debug.Log("LoadSpritePackTexture--->sprite:" + sprite);
            if (sprite != null)
            {
                map_texture2d.Add(spriteName, sprite);
            }
        }

        return sprite;
    }

    /// <summary>
    /// 加载Srpite
    /// </summary>
    /// <param name="spriteIndex"></param>
    /// <returns></returns>
    public static Sprite LoadSprite(int spriteIndex)
    {
        string spriteName = R.SpritePack.path[spriteIndex];
        Sprite sprite = LoadSprite(spriteName);

        return sprite;
    }

    

    public static Sprite LoadSprite(string spriteName)
    {
        spriteName = spriteName.Replace('\\', '/');
        Sprite sprite = map_sprite.GetValue(spriteName);
        if (isEditor && sprite == null)
        {
            sprite = Resources.Load<Sprite>(spriteName);
        }

        if (sprite == null)
        {
            string[] spriteNameArr = spriteName.Split('/');

            string name = spriteName.Substring(0, spriteName.Length - spriteNameArr[spriteNameArr.Length - 1].Length - 1);
            if (isABDebug) Debug.Log("LoadSprite--->name:" + name);
            AssetBundle ab = LoadAssetBundle(name);//
            if (ab == null)
            {
                return null;
            }
            string assetName = spriteNameArr[spriteNameArr.Length - 1];
            if (isABDebug) Debug.Log("LoadSprite--->assetName:" + assetName);
            sprite = ab.LoadAsset<Sprite>(assetName);
            if (sprite != null)
            {
                map_sprite.Add(spriteName, sprite);
            }
        }

        return sprite;
    }

    /// <summary>
    /// 加载数据，无缓存
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static byte[] LoadBytes(int index)
    {
        string dataName = R.Data.path[index];

        string[] spriteNameArr = dataName.Split('/');
        TextAsset textAsset = null;
        if (isEditor)
        {
            textAsset = Resources.Load<TextAsset>(dataName);
        }

        if (textAsset == null)
        {
            AssetBundle ab = LoadAssetBundle(dataName);//
            if (ab != null)
            {
                textAsset = ab.LoadAsset<TextAsset>(spriteNameArr[spriteNameArr.Length - 1]);
            }
            if (textAsset == null)
            {
                throw new Exception("资源[" + dataName + "]加载错误");
            }
        }

        return textAsset.bytes;
    }

    public static byte[] LoadBytes(string path)
    {
        string dataName = path;

        string[] spriteNameArr = dataName.Split('/');
        TextAsset textAsset = null;
        if (isEditor)
        {
            textAsset = Resources.Load<TextAsset>(dataName);
        }

        if (textAsset == null)
        {
            AssetBundle ab = LoadAssetBundle(dataName);//
            if (ab != null)
            {
                textAsset = ab.LoadAsset<TextAsset>(spriteNameArr[spriteNameArr.Length - 1]);
            }
            if (textAsset == null)
            {
                throw new Exception("资源[" + spriteNameArr[spriteNameArr.Length - 1] + "]加载错误");
            }
        }

        return textAsset.bytes;
    }

    /// <summary>
    /// 加载AudioClip
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static AudioClip LoadAudioClip(int index)
    {
         
        string name = R.AudioClip.path[index];
        AudioClip ac = LoadAudioClip(name);

        return ac;
    }

    /// <summary>
    /// 根据abName加载AudioClip，无缓存
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static AudioClip LoadAudioClip(string audioClipName)
    {
        AudioClip audioClip = map_audioClip.GetValue(audioClipName);

        //if (isABDebug)
        //{
        //    Debug.Log("加载音乐:"+ audioClipName+",检查缓存:"+ audioClip);
        //}
        if (isEditor && audioClip == null)
        {
            audioClip = Resources.Load<AudioClip>(audioClipName);
        }

        if (audioClip == null)
        {
            //if (isABDebug)
            //{
            //    Debug.Log("加载音乐:" + audioClipName + ",缓存中没有");
            //}

            string[] spriteNameArr = audioClipName.Split('/');

            string name = spriteNameArr[spriteNameArr.Length - 1];


            AssetBundle ab = LoadAssetBundle(audioClipName);//

            if (ab == null)
            {

                return null;
            }
            audioClip = ab.LoadAsset<AudioClip>(name);

            if (audioClip != null)
            {
                map_audioClip.Add(audioClipName, audioClip);
            }
            else
            {
                //throw new Exception("资源[" + name + "]加载错误");
                return null;
            }
        }
        return audioClip;
    }

    /// <summary>
    /// 根据名称加载缓存中ab资源和所有依赖的其他ab。如缓存中没有则读取文件并缓存
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static List<AssetBundle> LoadDependencies(string name)
    {
        AssetBundleManifest assetBundleManifest = LoadAssetBundleManifest();
        if (assetBundleManifest == null)
        {
            if (isABDebug)
                Debug.Log("加载ab资源【" + name + "】时，AssetBundleManifest加载失败!");
            return null;
        }

        List<AssetBundle> list_dependencies = LoadDependencies(assetBundleManifest, name);
        return list_dependencies;

    }

    /// <summary>
    /// 获得AssetBundle的所有依赖
    /// </summary>
    /// <param name="abm"></param>
    /// <param name="abName"></param>
    /// <returns></returns>
    public static List<AssetBundle> LoadDependencies(AssetBundleManifest abm, string abName)
    {
        if (isABDebug)
            Debug.Log("LoadDependencies->abName:" + abName);
        List<AssetBundle> list_ab = new List<AssetBundle>();
        foreach (var item in abm.GetAllDependencies(abName))
        {
            if (isABDebug)
                Debug.Log("依赖物品:" + item);
            if (map_ab.ContainsKey(item))
            {
                list_ab.Add(map_ab[item]);
            }
            else
            {
                if (isABDebug)
                    Debug.Log("依赖不存在，加载:" + item);
                AssetBundle ab = LoadAssetBundle(item);
                if (ab != null)
                {
                    list_ab.Add(ab);
                }
            }
        }
        return list_ab;
    }

    /// <summary>
    /// 读取缓存中AssetBundle文件,如缓存中没有，则读取文件,
    /// 优先寻找远程下载目录，pc:streamingAssetsPath,移动:persistentDataPath
    /// </summary>
    /// <param name="abName"></param>
    /// <returns></returns>
    public static AssetBundle LoadAssetBundle(string abName)
    {
        abName = abName.ToLower();
        AssetBundleManifest assetBundleManifest = LoadAssetBundleManifest();
        if (assetBundleManifest == null)
        {
            Debug.LogError("加载ab资源【" + abName + "】时，AssetBundleManifest加载失败!");
            return null;
        }

        if (isABDebug) Debug.Log("LoadAssetBundle--->abName:" +abName);
        AssetBundle ab = map_ab.GetValue(abName);
        if (ab != null)
        {
            return ab;
        }
        else
        {
            //缓存中没有，优先寻找远程下载目录，pc:streamingAssetsPath,移动:persistentDataPath

            string path = Remote_AssetBunlde_PATH + abName;

            if (isABDebug)
                Debug.Log("远程下载地址:" + path);

            if (FileIO.FileExists(path))
            {
                ab = AssetBundle.LoadFromFile(path);//优先远程地址
            }

            if (ab == null)//读取失败,尝试读取本地
            {
                path = Local_AssetBunlde_PathURL + abName;

                if (isABDebug)
                    Debug.Log("远程加载失败，本地读取地址:" + path);

                ab = AssetBundle.LoadFromFile(path);//优先远程地址
            }

            if (ab == null)//本地读取失败
            {
                if (isABDebug)
                {
                    Debug.Log("加载:" + abName + ",失败!");
                }
                return null;
            }

            if (isABDebug) Debug.Log("LoadAssetBundle--->abName.Add:" + abName+ ",ab:"+ ab);
            map_ab.Add(abName, ab);
            return ab;
        }
    }


    /// <summary>
    /// 加载ab包AssetBundleManifest
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static AssetBundleManifest LoadAssetBundleManifest()
    {
        if (assetBundleManifest == null)
        {
            string path = Remote_AssetBunlde_PATH + platform;//先读远程目录

            if (isABDebug)
            {
                Debug.Log("assetBundleManifest，远程目录->path:" + path);
            }
            AssetBundle manifestBundle = null;
            if (FileIO.FileExists(path))
            {
                manifestBundle = AssetBundle.LoadFromFile(path);
            }

            if (isABDebug)
            {
                Debug.Log("manifestBundle:" + manifestBundle);
            }

            if (manifestBundle == null)//远程目录空
            {
                path = Local_AssetBunlde_PathURL + platform;//读本地目录
                if (isABDebug)
                {
                    Debug.Log("寻找本地目录assetBundleManifest->path:" + path);
                }

                manifestBundle = AssetBundle.LoadFromFile(path);

                if (isABDebug)
                {
                    Debug.Log("manifestBundle:" + manifestBundle);
                }

                if (manifestBundle != null)
                {
                    assetBundleManifest = manifestBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                    manifestBundle.Unload(false);
                }
                else
                {
                    Debug.LogError("AssetBundleManifest加载失败，远程目录和本地目录都为空:");
                }
            }
            else
            {
                assetBundleManifest = manifestBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                manifestBundle.Unload(false);
            }
        }
        return assetBundleManifest;
    }

    /// <summary>
    /// 传入需要保存的数据bean，将个人存档文件写入<SAVE_DATA_PATH>指定文件夹,只在pc编辑器环境有效
    /// 
    /// </summary>
    /// <param name="key">存档名称</param>
    /// <param name="data">需要保存的对象</param>
    public static void SaveData(string key, object json)
    {
        WriteFile(SAVE_DATA_PATH, key, json.SerializerToJson().GetBytes());
    }

    public static void SaveData(string key, string txt)
    {
        WriteFile(SAVE_DATA_PATH, key, txt.GetBytes());
    }

    public static T ReadSave<T>(string key)
    {
        byte[] data = ReadFile(SAVE_DATA_PATH, key);
        return data.DeSerialFromJson<T>();
    }

    public static string ReadSave(string key)
    {
        byte[] data = ReadFile(SAVE_DATA_PATH, key);
        return data.EncodingToString();
    }

    /// <summary>
    /// 写入data到指定目录，同步方法
    /// </summary>
    /// <param name="file_name"></param>
    /// <param name="data"></param>
    public static void WriteFile(string filePath, string fileName, byte[] data)
    {
        if (isABDebug)
            Debug.Log("filePath:" + filePath + ",fileName:" + fileName);
        if (!FileExists(filePath))
        {
            if (isABDebug)
                Debug.Log("目录不存在，创建。");
            try
            {
                Directory.CreateDirectory(filePath);
            }
            catch (Exception e)
            {

                Debug.Log("创建目录失败:" + e);
            }

        }
        if (isABDebug)
            Debug.Log("filePath + fileName:" + (filePath + fileName));
        FileStream fs = new FileStream(filePath + fileName, FileMode.Create);
        fs.Write(data, 0, data.Length);

        fs.Close();
        fs.Dispose();//文件流释放  
    }

    public static void WriteAllAbName(string filePath, string fileName, string text)
    {
        if (!FileExists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        File.WriteAllText(filePath + fileName, text);
    }

    /// <summary>
    /// 写入一个lua文件到热更文件夹
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="data"></param>
    public static void WriteLua(string fileName, byte[] data)
    {
        WriteFile(HOTFIX_LUA_REMOTE_PATH, fileName, data);
    }

    /// <summary>
    /// 写入一个lua pb文件到热更文件夹
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="data"></param>
    public static void WriteLuaPb(string fileName, byte[] data)
    {
        Debug.Log("写入pb：" + (HOTFIX_LUA_PB_PATH + fileName));
        WriteFile(HOTFIX_LUA_PB_PATH, fileName, data);
    }

    /// <summary>
    /// 获取指定文件md5码
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetFileMd5(string filePath)
    {
        return GetFileMd5(filePath);
    }

    /// <summary>
    /// 加载一个.pb文件，返回byte流。lua pbc专用方法
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static byte[] LoadPB(string fileName)
    {
        UnityEngine.Debug.Log("PB名称：" + fileName + "   路径：" + HOTFIX_LUA_PB_PATH + "/" + fileName);
        FileStream fs = new FileStream(HOTFIX_LUA_PB_PATH + "/" + fileName, FileMode.Open);
        byte[] data = new byte[fs.Length];
        fs.Read(data, 0, data.Length);

        fs.Close();
        fs.Dispose();
        return data;
    }

    public static byte[] ReadFile(string path, string fileName)
    {
        FileStream fs = new FileStream(path + fileName, FileMode.Open);

        byte[] data = new byte[fs.Length];
        fs.Read(data, 0, data.Length);

        fs.Close();
        fs.Dispose();
        return data;
    }

    public static sbyte[] ReadFileSbyte(string path, string fileName)
    {
        FileStream fs = new FileStream(path + fileName, FileMode.Open);
        byte[] data = new byte[fs.Length];
        fs.Read(data, 0, data.Length);

        sbyte[] signed = Array.ConvertAll(data, b => unchecked((sbyte)b));

        fs.Close();
        fs.Dispose();
        return signed;
    }

    public static void ClearRemoteDir()
    {
        if (isABDebug)
        {
            Debug.Log("清理当前版本远程文件夹:" + Remote_AssetBunlde_PATH);
        }

        if (FileIO.DirectoryExists(Remote_AssetBunlde_PATH))
        {
            Directory.Delete(Remote_AssetBunlde_PATH, true);
        }
    }

    /// <summary>
    /// 自定义lua加载器
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static byte[] CustomLoaderMethod(ref string fileName)
    {
        string path = HOTFIX_LUA_REMOTE_PATH + fileName + ".lua";
        if (isABDebug)
            Debug.Log("path:" + path + ",File.Exists(path):" + File.Exists(path));
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            string localPath = HOTFIX_LUA_LOCAL_PATH + fileName + ".lua";
            if (isABDebug)
                Debug.Log("lua文件远程不存在，加载安装包自带.");

            WWWGet(localPath, path);
            return File.ReadAllBytes(path);
        }
    }

    public static void WWWGet(string path, string remotePath)
    {
        WWW wwwAsset = new WWW(path);
        while (!wwwAsset.isDone)
        {
        }

        string[] pathStr = remotePath.Split('/');
        string fileName = pathStr[pathStr.Length - 1];
        remotePath = remotePath.Replace(fileName, "");

        Debug.Log("remotePath:" + remotePath + ",fileName:" + fileName);
        FileIO.WriteFile(remotePath, fileName, wwwAsset.bytes);
        wwwAsset.Dispose();
    }

    /// <summary>
    /// 文件是否存在
    /// </summary>
    /// <param name="file_name"></param>
    /// <returns></returns>
    public static bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    /// <summary>
    /// 文件夹是否存在
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static bool DirectoryExists(string filePath)
    {
        return Directory.Exists(filePath);
    }

    /// <summary>
    /// 获取指定文件md5码
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetFileMd5(string path, string fileName)
    {
        try
        {
            //指定文集为根目录下的Test.cs  
            FileStream fs = new FileStream(path + fileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(fs);
            fs.Close();


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }

            return sb.ToString();

        }
        catch (Exception ex)
        {

            throw new Exception("md5file() fail, error:" + ex.Message);
        }
    }

    public static byte[] DecompressGZip(byte[] data)
    {
        MemoryStream ms = new MemoryStream(data);
        int bufferSize = 8192;
        int bytesRead = 0;
        byte[] buffer = new byte[bufferSize];
        GZipStream decompressionStream = new GZipStream(ms, CompressionMode.Decompress);
        ms = new MemoryStream();
        while ((bytesRead = decompressionStream.Read(buffer, 0, bufferSize)) > 0)
        {
            ms.Write(buffer, 0, bytesRead);
        }
        byte[] deData = ms.ToArray();
        ms.Close();
        decompressionStream.Close();
        return deData;
    }

    public static sbyte[][] LoadMapData(int index)
    {
        sbyte[][] map_data = null;
        string str = FileIO.LoadBytes(index).EncodingToString();

        string[] map_line = str.Split('\n');
         
        for (int i = 0; i < map_line.Length - 1; i++)
        {
            string line_data = map_line[i];
            //Debug.Log("line_data:"+line_data);
            string[] item_line = line_data.Split(',');
            if (map_data == null)
            {
                map_data = new sbyte[map_line.Length - 1][];
            }

            map_data[i] = new sbyte[item_line.Length];

            for (int j = 0; j < item_line.Length - 1; j++)
            {
                string byte_str = item_line[j];
                sbyte mapData = 0;
                try
                {
                    mapData = sbyte.Parse(byte_str);
                }
                catch (Exception e)
                {

                    Debug.LogError("转换byte_str错误:"+ byte_str+ ",Exception:" + e);
                }
              
                map_data[i][j] = mapData;
            }
        }
        return map_data;
    }

    public static int[][] LoadMapMergeData(int index)
    {
        int[][] map_data = null;
        string str = FileIO.LoadBytes(index).EncodingToString();

        string[] map_line = str.Split('\n');

        for (int i = 0; i < map_line.Length - 1; i++)
        {
            string line_data = map_line[i];
            //Debug.Log("line_data:"+line_data);
            string[] item_line = line_data.Split(',');
            if (map_data == null)
            {
                map_data = new int[map_line.Length - 1][];
            }

            map_data[i] = new int[item_line.Length - 1];

            for (int j = 0; j < item_line.Length - 1; j++)
            {
                string byte_str = item_line[j];
                int mapData = int.Parse(byte_str);
                map_data[i][j] = mapData;
            }
        }
        return map_data;
    }
}
