using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class IOSCall : MonoBehaviour
{
    //引入在oc中定义的那两个方法
    [DllImport("__Internal")]
    private static extern void IOS_OpenAlbum();

    public static IOSCall inst;
    void Awake()
    {
        inst = this;
    }

    public void OpenAlbum()
    {
        Debug.Log("OpenAlbum");
        IOS_OpenAlbum();
    }

    //ios回调unity的函数
    void IOSCallMessage(string filenName)
    {
        //我们传进来的只是文件名字 这里合成路径
        string filePath = Application.persistentDataPath + "/" + filenName;

        //开启一个协程加载图片
        StartCoroutine(LoadTexture(filenName));
    }


    IEnumerator LoadTexture(string fileName)
    {
        //注解1
        string path = "file://" + Application.persistentDataPath + "/" + fileName;
        Debug.Log("LoadTexture:" + path);
        WWW www = new WWW(path);
        while (!www.isDone)
        {

        }
        yield return www;
        //为贴图赋值

        Debug.Log("图片加载完成:" + www.texture.texelSize);
        
    }
}