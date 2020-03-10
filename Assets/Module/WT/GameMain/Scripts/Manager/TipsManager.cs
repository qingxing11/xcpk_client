using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class TipsManager : WTUIPage
{
    public const int COUNT_验证码 = 4;
    public const int COUNT_手机号码 = 11;
    public TipsManager(UIType type, UIMode mod)
        : base(type, mod)
    {
    }
    private static Dictionary<string, TipsManager> allPage = new Dictionary<string, TipsManager>();


    public static void Alert(string info_str)
    {
        //OpenBox<UITipsPanel>(info_str,null);
    }
    public static void OpenBox<T>(string text) where T : TipsManager, new()
    {
        OpenBox<T>(text,null);
    }
    public static void OpenBox<T>(string text, Action SetSurebtn) where T : TipsManager, new()
    {
        
        Type t = typeof(T);
        string pageName = t.ToString();
        TipsManager instance;
        if (allPage != null && allPage.ContainsKey(pageName))
        {
            instance = allPage[pageName];
        }
        else
        {
            instance = new T();
            allPage.Add(pageName, instance);
        }
        instance.SetText(text, SetSurebtn);
//todo        TipsManager.ShowPage(pageName, instance);
    }
    public virtual void SetText(string text,Action setSureBtn){ }

    protected override void InitLanguage()
    {
        throw new NotImplementedException();
    }
}
