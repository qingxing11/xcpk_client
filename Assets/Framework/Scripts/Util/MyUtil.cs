

using Config;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MyUtil
{
    private static System.Random random = new System.Random();

    public static int GetRandom(int bound)
    {
        return random.Next(bound);
    }

    public static bool GetRandomBool (int bound)
    {
        return random.Next(2) == 0 ? true : false;
    }

    public static int GetRandom(int min, int max)
    {
        return random.Next(min, max);
    }


    public static bool InstallAPK(string path)
    {
        try
        {
            var Intent = new AndroidJavaClass("android.content.Intent");
            var ACTION_VIEW = Intent.GetStatic<string>("ACTION_VIEW");
            var FLAG_ACTIVITY_NEW_TASK = Intent.GetStatic<int>("FLAG_ACTIVITY_NEW_TASK");
            var intent = new AndroidJavaObject("android.content.Intent", ACTION_VIEW);

            var file = new AndroidJavaObject("java.io.File", path);
            var Uri = new AndroidJavaClass("android.net.Uri");
            var uri = Uri.CallStatic<AndroidJavaObject>("fromFile", file);

            intent.Call<AndroidJavaObject>("setDataAndType", uri, "application/vnd.android.package-archive");
            intent.Call<AndroidJavaObject>("addFlags", FLAG_ACTIVITY_NEW_TASK);
            intent.Call<AndroidJavaObject>("setClassName", "com.android.packageinstaller", "com.android.packageinstaller.PackageInstallerActivity");

            var UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intent, "");


            return true;
        }
        catch (System.Exception e)
        {
            //intent.Call<AndroidJavaObject>("addFlags", FLAG_ACTIVITY_NEW_TASK);
            //intent.Call<AndroidJavaObject>("setClassName", "com.android.packageinstaller", "com.android.packageinstaller.PackageInstallerActivity");

            Debug.LogError("Error:" + e.Message + " -- " + e.StackTrace);
            return false;
        }
    }

     

    //用于打日志控制
    static bool isDebug = false;
    public static void DebugError(string debugContent)
    {
        if (isDebug)
            Debug.LogError(debugContent);
    }

    public static void DebugWarning(string debugContent)
    {
        if (isDebug)
            Debug.LogError(debugContent);
    }

    /// <summary>
    /// 字符串是否只包含数字和“.”
    /// </summary>
    /// <param name="str"></param>
    public static bool IsHaveNumberAndDian(string str)
    {
        foreach (var item in str)
        {
            if (!((item >= '0' && item <= '9') || item == '.'))
            {
                return false;
            }
        }
        return true;
    }
    /// <summary>
    /// 字符串是否只包含数字和“.”
    /// </summary>
    /// <param name="str"></param>
    public static bool IsHaveNumberAndDian(char cha)
    {
        if (!((cha >= '0' && cha <= '9') || cha == '.'))
        {
            return false;
        }
        return true;
    }
}