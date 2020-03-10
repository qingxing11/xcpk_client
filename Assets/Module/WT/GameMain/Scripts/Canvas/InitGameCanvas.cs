

//mumu:7555
using FairyGUI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WT.UI;

public class InitGameCanvas : BaseCanvas, IHandlerReceive
{
    private bool isDebug = false;

    /// <summary>
    /// 下载更新时，每个文件间隔60秒为下载周期，超过60秒未完成一个下载资源时弹出超时
    /// </summary>
    public const int DOWNLOAD_TIMEOUT = 60000;

    private string url;

    #region 存档相关
    public const string VERSION_TXT = "version";

    #endregion

    public ClientConfig configManager;

    public static ClientConfig mClientConfig;
    public static ClientConfig ClientConfig
    {
        get
        {
            return mClientConfig;
        }
    }

    //private LuaEnv luaEnv;
    //private LuaTable scriptEnv;

    private long startDownloadTimer;
    private bool isStartDownload;



    void Awake()
    {
 
        WTUIPage.CloseAll();
        WTUIPage.ClearNodes();

         
        AddHandlerGlobalReceiveEvent<GlobalReceiveCanvas>();
        AddAudioControl();
        LocalArchiveManager.LoadLanguage();

        if (PlayerPrefs.GetInt("music") == 1)
        {
            CacheManager.PlayMusic = false;
        }
        else
        {
            PlayBGM(R.AudioClip.GAME_BGM);
            CacheManager.PlayMusic = true;
        }
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            CacheManager.PlaySound = false;
        }
        else
        {
            CacheManager.PlaySound = true;
        }



        if (PlayerPrefs.GetInt("bullte") == 1)
        {
            CacheManager.Bullte = false;
        }
        else
        {
            CacheManager.Bullte = true;
        }
        StartCoroutine(ShowLogo());

        GetNewRes();
        
    }

    private IEnumerator ShowGameTips()
    {
        UIGameTips uIGameTips = WTUIPage.ShowPage<UIGameTips>();
        yield return new WaitForSeconds(1.5f);
        uIGameTips.Hide();
        WTUIPage.ShowPage<UILoading>();
    }

    private IEnumerator ShowLogo()
    {
        UIConfig.bringWindowToFrontOnClick = false;

        mClientConfig = configManager;
        AddAudioControl();
        AddEffectControl();
        if (isDebug)
        {
            Debug.Log("configManager.ip:" + configManager.ip);
        }

#if !UNITY_IOS
        NetWorkClient.Disconnect();
#endif
        NetWorkClient.InitConnect(configManager.ip, configManager.port, configManager.serializerUtil);

        AddHandlerGlobalReceiveEvent<GlobalReceiveCanvas>();
        AddHandlerReceiveEvent(this);

        //GetController<MainSceneCtrl>().ShowUIMainScene();
        //string url = "https://dianying-guandan-download.oss-cn-shanghai.aliyuncs.com/gd_test.apk";
        //StartCoroutine(NetworkIO.HttpGetAndSave(url, "guandan.apk", downloadComplete));

        //GetNewRes();

        //ActivationConntroller<CommonCtrl>();

        yield return null;


    }
    private void PlayOver()
    {
        if (isDebug)
        {
            Debug.Log("加载完毕！");
        }
        LoadScene();
    }

    private void LoadScene()
    {
        //SceneManager.LoadScene("Login");
      
    }


    private void GetNewRes()
    {
        InitVersion();

        GetResRequest request = new GetResRequest
        {
            clientVersion = configManager.versionCode,
            bigVersion = configManager.bigVersion,

#if UNITY_STANDALONE && UNITY_EDITOR
            clientPlatform = 2,
#elif UNITY_ANDROID
            clientPlatform = 0,
#elif UNITY_IOS
             clientPlatform = 1,
#else
             clientPlatform = 0,
#endif

        };

        SendMessage(request);
    }

    /// <summary>
    /// 初始化当前版本号
    /// </summary>
    private void InitVersion()
    {
        int getLocalVersion = PlayerPrefs.GetInt(VERSION_TXT);
        if (getLocalVersion != 0 && getLocalVersion < configManager.versionCode)
        {
            configManager.versionCode = getLocalVersion;
        }
        else//大版本发布时，安装包自带版本号应大于存档中版本号
        {
#if !UNITY_STANDALONE && !UNITY_EDITOR//开发环境不删除
            FileIO.ClearRemoteDir();
#endif
        }
    }

    private int updateFileNum;
    private int version;
    private string host;
    private int port;
    private void StartGetNewFile(HotfixUpdateFileVO hotfixUpdateFile)
    {
        updateFileNum = hotfixUpdateFile.list_fileUrl.Count;
        version = hotfixUpdateFile.version;
        host = hotfixUpdateFile.gateway_host;
        port = hotfixUpdateFile.gateway_port;
        StartCoroutine(NetworkIO.HttpGetAndSave(hotfixUpdateFile.list_fileUrl, hotfixUpdateFile.url_path, HotfixUpdateCallback));
    }

    private void HotfixUpdateCallback(int updateIndex)
    {
        ResetStartDownloadTime();

        if (isDebug)
        {
            Debug.Log("当前进度:" + updateIndex + "/" + updateFileNum);
        }

        if (updateIndex == updateFileNum)
        {
            ChangeToLogin();
        }
    }

    private void ChangeToLogin()
    {
        StartCoroutine(ShowGameTips());
        //if (luaEnv == null)
        //{
        //    string path = "lua/Main";
        //    luaEnv = new LuaEnv();
        //    luaEnv.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadRapidJson);
        //    luaEnv.AddLoader(FileIO.CustomLoaderMethod);
        //    luaEnv.DoString(FileIO.CustomLoaderMethod(ref path));

        //}
        return;


#if !UNITY_IOS
        NetWorkClient.Disconnect();
#endif

        //NetWorkClient.Disconnect();

        Debug.Log("configManager.serializerUtil:" + configManager.serializerUtil);
        NetWorkClient.InitConnect(host, port, configManager.serializerUtil);

        PlayerPrefs.SetString("GameHost", host);
        PlayerPrefs.SetInt("GamePort", port);

        PlayerPrefs.SetInt(VERSION_TXT, version);//测试时不打开
        FileIO.ClearAssetBundleManifest();

        WTUIPage.ClearNodes();

        Debug.Log("Login==============");



        //SceneManager.LoadScene("Login");
       
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {

            switch (response.msgType)
            {
                case MsgType.UTIL_GET_NEW_FILE_URL:
                    GetNewFileReceive(response.data);
                    break;

                case -998:

                    break;

                default:
                    return response;
            }
        }

        return null;
    }

    private void GetNewFileReceive(byte[] data)
    {
        GetResResponse response = MySerializerUtil.DeSerializerFromProtobufNet<GetResResponse>(data);
        Debug.Log("response:"+ response.code);
        switch (response.code)
        {
            case GetResResponse.SUCCESS:
                HotfixUpdateFileVO hotfixUpdateFile = response.updateFileVO;
                StartGetNewFile(hotfixUpdateFile);
                break;

            case GetResResponse.ERROR_不需要更新:
                hotfixUpdateFile = response.updateFileVO;
                host = hotfixUpdateFile.gateway_host;
                port = hotfixUpdateFile.gateway_port;
                ChangeToLogin();
                break;

            case GetResResponse.SUCCESS_需要大版本更新:
                StartGetNewVersionUpdate(response.bigVersion, response.install_pack_url);
                break;

            default:
                break;
        }
    }

    protected override void Update()
    {

        base.Update();

        RunDownloadTimeOut();
    }

    public void StartDownload()
    {
        isStartDownload = true;
        startDownloadTimer = MyTimeUtil.GetCurrTimeMM;
    }

    /// <summary>
    /// 下载进度有变化时刷新计时
    /// </summary>
    public void ResetStartDownloadTime()
    {
        startDownloadTimer = MyTimeUtil.GetCurrTimeMM;
    }

    private void RunDownloadTimeOut()
    {
        if (isStartDownload)
        {
            if (MyTimeUtil.GetCurrTimeMM - startDownloadTimer > DOWNLOAD_TIMEOUT)
            {
                isStartDownload = false;
                //连接服务器失败,请检查网络!
            }
        }
    }

    public void LostConnect()
    {

    }


    /// <summary>
    /// 接收到获取大版本更新消息，进行版本判断
    /// </summary>
    private void StartGetNewVersionUpdate(int bigVersion, string url)
    {
        // Application.OpenURL("http://47.100.229.107/");

        WTUIPage.ShowPage<UIBigVersion>();
        return;
#if UNITY_STANDALONE && UNITY_EDITOR
        TipsManager.Alert("开发者环境下无法测试！");
#elif UNITY_ANDROID
        //WTUIPage.ClearNodes();

        //this.url = url;
       
#elif UNITY_IOS
        
#else

#endif
    }


    /// <summary>
    /// 在提示大版本更新的界面点击取消或者关闭按钮，直接退出
    /// </summary>
    private void CancelUpdate()
    {
        Application.Quit();          //关闭游戏
    }

    /// <summary>
    /// 提示确定更新之后调用下载
    /// </summary>
    private void GoUpdate()
    {


        //开启协程下载软件
        StartCoroutine(NetworkIO.HttpGetAndSaveToAPK(url, "guandan.apk", BigVersionUpdateCallback, downloadComplete));
    }

    private void BigVersionUpdateCallback(float updateIndex)
    {
        ResetStartDownloadTime();

        if (isDebug)
        {
            Debug.Log("当前进度:" + updateIndex + "/" + 100);
        }
    }

    private void downloadComplete()
    {
        MyUtil.InstallAPK(Application.persistentDataPath + "/apk/guandan.apk");
    }


}