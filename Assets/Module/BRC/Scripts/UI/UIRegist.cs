using Main;
using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIRegist : WTUIPage<UI_Regist, LoginCtrl>
{
    public Action<string,string,string> ActionRegist;
    public UIRegist():base(UIType.PopUp, UIMode.DoNothing, R.UI.MAIN)
    {}

    public override void Awake()
    {
        UIPage.m_btn_regist.onClick.Add(RegistOnClick);
        UIPage.m_btn_close.onClick.Add(base.Hide);
    }

    private void RegistOnClick()
    {
        string account = UIPage.m_text_account.text;
        string pwd = UIPage.m_text_pwd.text;
        string accRegular = @"^[a-zA-Z][a-zA-Z0-9]*$"; //匹配字符是以字母开头的字母数字组合
        string nickRegular = "^[a-zA-Z0-9\u4e00-\u9fa5]{2,6}$"; //匹配昵称是字母数字汉字组成的2-6位组合
        string nickName = UIPage.m_text_nickname.text;
        if (account.Length < 6)
        {
            Debug.LogError("账号不能小于6位");
            return;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(nickName, nickRegular))
        {
            Debug.LogError("昵称必须是2到6位的字母数字汉字组合");
            return;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(account, accRegular))
        {
            Debug.LogError("账号必须是以字母开头的字母数字组合");
            return;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(pwd, accRegular))
        {
            Debug.LogError("密码必须是以字母开头的字母数字组合");
            return;
        }
        if (pwd.Length < 6)
        {
            Debug.LogError("密码不能小于6位");
            return;
        }
        if (UIPage.m_text_pwd.text != UIPage.m_text_pwdcon.text)
        {
            Debug.LogError("您两次输入的密码不一样");
            return;
        }
        PlayerPrefs.SetString("account", account);
        PlayerPrefs.SetString("pwd", pwd);
        ActionRegist?.Invoke(account, UIPage.m_text_nickname.text, pwd);
        base.Hide();
    }
}