using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
//  0 BuildAssetBundleOptions.None --构建AssetBundle没有任何特殊的选项
//  1 BuildAssetBundleOptions.UncompressedAssetBundle --不进行数据压缩。如果使用该项，因为没有压缩\解压缩的过程， AssetBundle的发布和加载会很快，但是AssetBundle也会更大，下载变慢
//  2 BuildAssetBundleOptions.CollectDependencies  --包含所有依赖关系
//  4 BuildAssetBundleOptions.CompleteAssets  --强制包括整个资源
//  8 BuildAssetBundleOptions.DisableWriteTypeTree --在AssetBundle中不包含类型信息。发布web平台时，不能使用该项
// 16 BuildAssetBundleOptions.DeterministicAssetBundle --使每个Object具有唯一不变的hash ID，可用于增量式发布AssetBundle
// 32 BuildAssetBundleOptions.ForceRebuildAssetBundle --强制重新Build所有的AssetBundle
// 64 BuildAssetBundleOptions.IgnoreTypeTreeChanges --忽略TypeTree的变化，不能与DisableTypeTree同时使用
//128 BuildAssetBundleOptions.AppendHashToAssetBundleName --附加hash到AssetBundle名称中
//256 BuildAssetBundleOptions.ChunkBasedCompression --Assetbundle的压缩格式为lz4。默认的是lzma格式
public class AssetBunldeManager
{
    private static bool isAssetBunldeManagerDebug = false;


    /// <summary>
    /// 开发模式还是发布模式
    /// </summary>
    private static bool isDebug = false;

    public static readonly string[] BunldeType = new string[]{
        "Prefab",
        "SpritePack",
        "Texture",
        "AudioClip",
        "Data",
        "Font",
        "UI",
        "Materials"
    };
    public const int ASSETTYPE_Prefab = 0;
    public const int ASSETTYPE_SpritePack = 1;
    public const int ASSETTYPE_TextureB = 2;
    public const int ASSETTYPE_AudioClip = 3;
    public const int ASSETTYPE_Data = 4;
    public const int ASSETTYPE_Font = 5;
    public const int ASSETTYPE_UI = 6;
    public const int ASSETTYPE_Materials = 7;


    private static StringBuilder[] list_sb = new StringBuilder[BunldeType.Length];
    private static StringBuilder[] list_sbPath = new StringBuilder[BunldeType.Length];

    private static Dictionary<string, string> sb_allName = new Dictionary<string, string>();

    public static string pathURL = Application.streamingAssetsPath + "/";
    public static string sourcePath = Application.dataPath + "/Res/";
    public static string resourcePath = Application.dataPath + "/Resources/";
    public static string genURL = Application.dataPath + "/Gen/";


    [MenuItem("WT/AssetBunlde资源管理/生成索引并打包-lz4压缩")]
    static void CreateAssetBunldesMainByLz4()
    {

        isFirst = true;
        sb_allName.Clear();
        ClearAssetBundlesName();

        Pack(sourcePath, false);

        string outputPath = Path.Combine(pathURL, GetPlatformFolder(EditorUserBuildSettings.activeBuildTarget));

        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        //根据BuildSetting所激活的平台进行打包  

        if (!isDebug)
        {
            BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);
        }

        WriteAssetBunldesNameCS("R.cs", sb_allName);

        AssetDatabase.Refresh(); //刷新编辑器
    }

    private static void WriteAssetBunldesNameCS(string name, Dictionary<string, string> txt)
    {
        string[] allTxt = new string[txt.Values.Count];
        txt.Values.CopyTo(allTxt, 0);

        WriteAssetBunldesNameCS(name, allTxt);
    }

    /// <summary>
    /// 写入索引到.cs
    /// </summary>
    /// <param name="name"></param>
    /// <param name="txt"></param>
    private static void WriteAssetBunldesNameCS(string name, string[] txt)
    {
        int[] bunldeIndex = new int[BunldeType.Length];

        StringBuilder sbMain = new StringBuilder();
        sbMain.Append("public class R{\n");

        for (int i = 0; i < list_sb.Length; i++)
        {
            list_sb[i] = new StringBuilder();
            list_sb[i].Append("\n\tpublic class " + BunldeType[i] + "{\n");

            list_sbPath[i] = new StringBuilder();
            list_sbPath[i].Append("\n\t\tpublic static string[] path = {");
        }

        foreach (var itemName in txt)
        {
            string abName = itemName;//.ToLower()

            for (int i = 0; i < BunldeType.Length; i++)
            {

                if (abName.Contains(BunldeType[i]))//该ab的类型   .ToLower()
                {
                    list_sb[i].Append(AbNameToIndex(abName, bunldeIndex[i]));
                    bunldeIndex[i]++;
                    list_sbPath[i].Append("\"");
                    list_sbPath[i].Append(abName);
                    list_sbPath[i].Append("\",");
                    if (bunldeIndex[i] != 0 && bunldeIndex[i] % 20 == 0)
                    {
                        list_sbPath[i].Append("\n");
                        list_sbPath[i].Append(WriteTableKey(8));
                    }
                }
            }
        }

        for (int i = 0; i < list_sb.Length; i++)
        {
            list_sbPath[i].Append("\n\t\t};\n\t}");
            sbMain.Append(list_sb[i].ToString());

            sbMain.Append(list_sbPath[i].ToString());
        }

        sbMain.Append("\n}");

        //Debug.Log("sbMain:"+ sbMain.ToString());

        FileIO.WriteAllAbName(genURL, name, sbMain.ToString());
    }

    private static string AbNameToIndex(string fileName, int index)
    {
        StringBuilder sb = new StringBuilder();
        string[] abName = fileName.Split('/');
        sb.Append("\t\tpublic const int ");

        if (abName.Length < 4)
        {
            Debug.LogError("资源文件[" + fileName + "]放置位置错误[姓名首字母/模块名/资源文件类型/文件名]!");
            return null;
        }
        for (int i = 3; i < abName.Length - 1; i++)
        {
            sb.Append(abName[i].ToUpper());
            sb.Append("_");
        }
        sb.Append(abName[abName.Length - 1].ToUpper());
        sb.Append(" = ");
        sb.Append(index);
        sb.Append(";\n");

        return sb.ToString();
    }

    //private static string AbNameToPath(string fileName, int index)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    string[] abName = fileName.Split('/');

    //    for (int i = 0; i < abName.Length; i++)
    //    {
    //        sb.Append(abName[i]);
    //        sb.Append("\",");
    //        if (i != 0 && i % 20 == 0)
    //        {
    //            sb.Append("\n");
    //            sb.Append(WriteTableKey(5));
    //        }
    //    }
    //    return sb.ToString();
    //}

    private static bool isFirst = true;
    /// <summary>
    /// 如上层目录是图集文件夹<SpritePack>,则下层目录按照文件夹分图集
    /// </summary>
    /// <param name="source"></param>
    /// <param name="isSpritePack">是图集目录</param>
    static void Pack(string source, bool isSpritePack)
    {
        bool isPackDebug = false;


        if (!FileIO.DirectoryExists(source))
        {
            Directory.CreateDirectory(source);
        }
        DirectoryInfo folder = new DirectoryInfo(source);
        FileSystemInfo[] files = folder.GetFileSystemInfos();
        if (isFirst)
        {
            isDebug = false;
        }

        if (files.Length == 0 && isFirst)
        {
            if (isFirst)
            {
                isDebug = true;
            }

            folder = new DirectoryInfo(resourcePath);
            files = folder.GetFileSystemInfos();
        }
        isFirst = false;

        for (int i = 0; i < files.Length; i++)
        {
            if (files[i] is DirectoryInfo)
            {
                if (isSpritePack)
                {
                    SetSpritePackName(files[i].FullName);
                }
                else
                {
                    if (isPackDebug)
                        Debug.Log("files[i].Name:" + files[i].Name + ",files[i].Name.EndsWith_UI:::::" + files[i].Name.EndsWith("UI"));
                    Pack(files[i].FullName, files[i].Name.EndsWith(BunldeType[ASSETTYPE_SpritePack]));// || files[i].Name.EndsWith(BunldeType[ASSETTYPE_UI]), files[i].Name.EndsWith("UI")
                }
            }
            else
            {
                if (!files[i].Name.EndsWith(".meta"))
                {

                    SetAbName(files[i].FullName, string.Empty, source.EndsWith(BunldeType[ASSETTYPE_UI]) ? BunldeType[ASSETTYPE_UI] : "");
                }
            }
        }
    }

    private static void SetSpritePackName(string source)
    {
        DirectoryInfo folder = new DirectoryInfo(source);
        FileSystemInfo[] files = folder.GetFileSystemInfos();

        for (int i = 0; i < files.Length; i++)
        {
            if (!files[i].Name.EndsWith(".meta"))
            {
                string name = source.Substring(source.IndexOf("/") + 1);

                SetAbName(files[i].FullName, files[i].Name, BunldeType[ASSETTYPE_SpritePack]);
            }
        }


    }

    private static void SetAbName(string source, string name, bool isPack, bool isOnce)
    {
        if (isAssetBunldeManagerDebug)
            Debug.Log("source:" + source + ",name:" + name);

        string _source = Replace(source);
        string _assetPath = "Assets" + _source.Substring(Application.dataPath.Length);
        string _assetPath2 = _source.Substring(Application.dataPath.Length + 1);

        AssetImporter assetImporter = AssetImporter.GetAtPath(_assetPath);
        string assetName = _assetPath2.Substring(_assetPath2.IndexOf("/") + 1);

        if (isAssetBunldeManagerDebug)
            Debug.Log("assetName:" + assetName + ",name:" + name);

        if (string.IsNullOrEmpty(name))
        {
            assetName = assetName.Replace(Path.GetExtension(assetName), "");
        }
        else
        {

            assetName = string.IsNullOrEmpty(name) ? assetName : assetName.Replace("/" + name, "");
        }

        if (isAssetBunldeManagerDebug)
            Debug.Log("目标文件:" + _assetPath + ",_assetPath2:" + _assetPath2 + ",assetName:" + assetName);


        if (isPack && !isOnce)//是图集,不是组合
        {
            string spriteName = assetName + "/" + name.Split('.')[0];
            Debug.Log("spriteName:" + spriteName);
            if (!sb_allName.ContainsKey(spriteName))
            {
                sb_allName.Add(spriteName, spriteName);
            }
        }
        else
        {
            if (isAssetBunldeManagerDebug)
                Debug.Log("assetName:" + assetName);

            if (!sb_allName.ContainsKey(assetName))
            {
                sb_allName.Add(assetName, assetName);
            }
        }

        if (!isDebug)
        {
            try
            {
                assetImporter.assetBundleName = assetName;//设置AssetBundleName 
            }
            catch (Exception e)
            {
                //                Debug.Log();
                throw new AggregateException("Can't set ABName about:" + source + ". the error message:" + e.Message);
            }
        }
    }


    private static void SetAbName(string source, string name, string assetType)
    {
        string uiAssetName = "";
        bool isSetAbNameDebug = false;

        if (isSetAbNameDebug)
            Debug.Log("SetAbName =========== source:" + source + ",name:" + name + ",assetType:" + assetType);

        string _source = Replace(source);
        string _assetPath = "Assets" + _source.Substring(Application.dataPath.Length);
        string _assetPath2 = _source.Substring(Application.dataPath.Length + 1);


        AssetImporter assetImporter = AssetImporter.GetAtPath(_assetPath);//得到需要打包的资源
        string assetName = _assetPath2.Substring(_assetPath2.IndexOf("/") + 1);

        if (isSetAbNameDebug)
            Debug.Log("assetName:" + assetName + ",name:" + name);

        if (string.IsNullOrEmpty(name))
        {
            assetName = assetName.Replace(Path.GetExtension(assetName), "");
        }
        else
        {
            assetName = string.IsNullOrEmpty(name) ? assetName : assetName.Replace("/" + name, "");
        }

        if (_assetPath.EndsWith(".cs"))
        {
            return;
        }

        if (isSetAbNameDebug)
            Debug.Log("目标文件:" + _assetPath + ",_assetPath2:" + _assetPath2 + ",assetName:" + assetName);

        string[] pathArray = assetName.Split('/');
        if (pathArray.Length < 3)
        {
            return;
        }
        assetType = pathArray[2];
        //Debug.Log("assetType:"+ assetType+ ",assetName:"+ assetName);
        if (BunldeType[ASSETTYPE_UI].Equals(assetType))
        {
           
            if (isAssetBunldeManagerDebug) Debug.Log("assetType:" + assetType + "->>>>>>>assetName:" + assetName);
            string abName = assetName.Split('_')[0];
            if (assetName.EndsWith("_fui"))
            {
                uiAssetName = assetName.Replace("_fui", "");
                if (isAssetBunldeManagerDebug) Debug.Log("设置R文件索引,uiAssetName:" + uiAssetName);
                sb_allName.Add(uiAssetName, uiAssetName);
            }
            assetName = abName;
           
        }
        else if (BunldeType[ASSETTYPE_SpritePack].Equals(assetType))
        {
            string spriteName = assetName + "/" + name.Split('.')[0];
            if (isSetAbNameDebug)
                Debug.Log("spriteName:" + spriteName);
            if (!sb_allName.ContainsKey(spriteName))
            {
                sb_allName.Add(spriteName, spriteName);
            }
        }
        else//其他普通资源
        {
            if (isSetAbNameDebug)
                Debug.Log("其他普通资源-----assetName:" + assetName);

            if (!sb_allName.ContainsKey(assetName))
            {
                sb_allName.Add(assetName, assetName);
            }
        }

        if (!isDebug)//发布模式
        {
            try
            {
                Debug.Log("assetImporter:" + assetImporter + ",assetName:" + assetName);
                assetImporter.assetBundleName = assetName;//设置AssetBundleName 
            }
            catch (Exception e)
            {
                //                Debug.Log();
                throw new AggregateException("Can't set ABName about:" + source + ". the error message:" + e.Message);
            }
        }
    }

    private static string WriteTableKey(int num)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < num; i++)
        {
            sb.Append("\t");
        }

        return sb.ToString();
    }

    private static string Replace(string s)
    {
        return s.Replace("\\", "/");
    }

    //[MenuItem("WT/AssetBunlde资源管理/lzma压缩打包")]
    //static void CreateAssetBunldesMainByLzma()
    //{
    //    Debug.Log("PathURL:" + PathURL);
    //    BuildPipeline.BuildAssetBundles(PathURL, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    //    //刷新编辑器
    //    AssetDatabase.Refresh();
    //}

    //[MenuItem("WT/AssetBunlde资源管理/不压缩打包")]
    //static void CreateAssetBunldesMainByUncompressedAssetBundle()
    //{
    //    Debug.Log("PathURL:" + PathURL);
    //    BuildPipeline.BuildAssetBundles(PathURL, BuildAssetBundleOptions.UncompressedAssetBundle, EditorUserBuildSettings.activeBuildTarget);
    //    //刷新编辑器
    //    AssetDatabase.Refresh();
    //}

    /// <summary>
    /// 查看所有的Assetbundle名称（设置Assetbundle Name的对象）
    /// </summary>
    [MenuItem("WT/AssetBunlde资源管理/查看所有AssetBundle names")]
    static void GetNames()
    {
        var names = AssetDatabase.GetAllAssetBundleNames();
        //获取所有设置的AssetBundle 
        foreach (var name in names) Debug.Log("AssetBundle: " + name);
    }


    [MenuItem("WT/AssetBunlde资源管理/清除所有AssetBundle names")]
    static void ClearAssetBundlesName()
    {
        int length = AssetDatabase.GetAllAssetBundleNames().Length;

        string[] oldAssetBundleNames = new string[length];
        for (int i = 0; i < length; i++)
        {
            oldAssetBundleNames[i] = AssetDatabase.GetAllAssetBundleNames()[i];
        }

        for (int j = 0; j < oldAssetBundleNames.Length; j++)
        {
            AssetDatabase.RemoveAssetBundleName(oldAssetBundleNames[j], true);
        }
        length = AssetDatabase.GetAllAssetBundleNames().Length;

    }

    public static string GetPlatformFolder(BuildTarget target)
    {
        switch (target)
        {
            case BuildTarget.Android:
                return "Android";
            case BuildTarget.iOS:
                return "IOS";

            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                return "Windows";


            default:
                return null;
        }
    }
}