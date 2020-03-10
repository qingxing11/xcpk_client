using Main;
using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UILogin : WTUIPage<UI_Login, LoginCtrl>
{
    public Action<string, string> ActionLogin;
    public Action ActionRegist;

    public UILogin() : base(UIType.Normal, UIMode.DoNothing, R.UI.MAIN)
    {

    }

    public override void Awake()
    {
        UIPage.m_btn_login.onClick.Add(LoginOnClick);
        UIPage.m_btn_regist.onClick.Add(RegistOnClick);

        string account = PlayerPrefs.GetString("account");
        string pwd = PlayerPrefs.GetString("pwd");

        if(account!=null&& pwd != null)
        {
            UIPage.m_text_account.text = account;
            UIPage.m_text_pwd.text = pwd;
        }
    }

    private void LoginOnClick()
    {
        string account = UIPage.m_text_account.text;
        string pwd = UIPage.m_text_pwd.text;
        if (account.Length < 6)
        {
            Debug.LogError("用户名为6位以上的字符");
            return;
        }
        if (pwd.Length < 6)
        {
            Debug.LogError("密码为6位以上的字符");
            return;
        }

        PlayerPrefs.SetString("account",account);
        PlayerPrefs.SetString("pwd",pwd);

        ActionLogin?.Invoke(account,pwd);
    }

    private void RegistOnClick()
    {
        ActionRegist?.Invoke();
    }
}