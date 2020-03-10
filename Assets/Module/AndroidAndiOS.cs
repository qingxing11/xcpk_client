using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AndroidAndiOS : MonoBehaviour
{

    public static AndroidAndiOS inst;

    private AndroidJavaObject jo;

    public Action<Texture2D> takePhotoSuccess;

    [DllImport("__Internal")]
    private static extern void IOS_OpenAlbum();
     
    void Awake()
    {
        inst = this;

        //AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        DontDestroyOnLoad(this);
    }

    public void OpenAlbum()
    {
        Debug.Log("OpenAlbum");
        IOS_OpenAlbum();
    }

    public void AliPay(string payOrder)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        jo = new AndroidJavaObject("com.wt.alipay.Unity2Android");
        jo.Call("payV2", payOrder);
        Debug.Log("android===========>:AliPay");
#endif
    }

    public void WxPay(string payOrder)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        jo = new AndroidJavaObject("com.wt.wxpay.Unity2Android");
        jo.Call("wxPay", payOrder);
       
#endif
        Debug.Log("android===========>:callwxPay");
    }

    void IOSUpdateHeadImage(string filenName)
    {
        //开启一个协程加载图片
        StartCoroutine(LoadTexture(filenName));
    }

    public void UpdateHeadImage(string path)
    {
        Debug.Log("唤起unity读取图片,path:" + path);
        //在Android插件中通知Unity开始去指定路径中找图片资源
        StartCoroutine(LoadTexture(path));
    }

    IEnumerator LoadTexture(string name)
    {
        //注解1
        string path = "file://" + Application.persistentDataPath + "/" + name;
        Debug.Log("LoadTexture:" + path);
        WWW www = new WWW(path);
        while (!www.isDone)
        {

        }
        yield return www;
        //为贴图赋值


        takePhotoSuccess(www.texture);
        Debug.Log("图片加载完成,长度:" + www.bytes.Length);
        //Texture2D t2d = TextureToTexture2D(texture);
        //GameObject.Find("Sprite").GetComponent<SpriteRenderer>().sprite = Sprite.Create(t2d, new Rect(0,0,texture.width,texture.height),Vector2.zero);
    }



    public void TakePhoto()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
         jo = new AndroidJavaObject("com.wt.alipay.Unity2Android");
        jo.Call("TakePhoto", "test0");

#elif UNITY_IPHONE
        OpenAlbum();
#endif
    }
}
