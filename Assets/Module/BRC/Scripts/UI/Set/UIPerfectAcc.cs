using Set;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using System;
/// <summary>
/// 完善账号
/// </summary>
public class UIPerfectAcc : WTUIPage<UI_wszh, SetCtrl>
{
    public Action<string,string,string> ActionCreate;//完善账号
    public Action<string> ActionErrorCode;             //显示错误提示
    public UIPerfectAcc() : base(UIType.Dialog, UIMode.HideOther, R.UI.SET)
    { }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
    }
    private void CreateOnClick()
    {
        string pattern = @"^[a-zA-Z][a-zA-Z0-9]*$"; //匹配字符是以字母开头的字母数字组合

        string acc = UIPage.m_text_acc.text;
        string pwd = UIPage.m_text_pwd.text;
        if (acc.Length < 6)
        {
            ActionErrorCode?.Invoke("账号长都不能小于6");
            Debug.LogError("账号长都不能小于6");
            return;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(acc, pattern))
        {
            ActionErrorCode?.Invoke("账号必须是以字母开头的字母或者数字组合");
            Debug.LogError("账号必须是以字母开头的字母或者数字组合");
            return;
        }

        if (pwd.Length <= 0)
        {
            ActionErrorCode?.Invoke("密码不能为空");
            Debug.LogError("密码不能为空");
            return;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(pwd, pattern))
        {
            ActionErrorCode?.Invoke("密码必须是以字母开头的字母或者数字组合");
            Debug.LogError("密码必须是以字母开头的字母或者数字组合");
            return;
        }
        if (pwd != UIPage.m_text_pwd2.text)
        {
            ActionErrorCode?.Invoke("您两次输入的密码不一致");
            Debug.LogError("您两次输入的密码不一致");
            return;
        }




        ActionCreate?.Invoke(UIPage.m_text_acc.text, UIPage.m_text_nickName.text, UIPage.m_text_pwd.text);
    }
    public override void Refresh()
    {
        if (!CacheManager.gameData.accountSupplementary)
        {
            UIPage.m_text_acc.touchable = true;
            UIPage.m_text_nickName.touchable = true;
            UIPage.m_text_pwd.touchable = true;
            UIPage.m_text_pwd2.touchable = true;
            UIPage.m_btn_create.onClick.Add(CreateOnClick);
        }
        else
        {
            UIPage.m_text_acc.touchable = false;
            UIPage.m_text_nickName.touchable = false;
            UIPage.m_text_pwd.touchable = false;
            UIPage.m_text_pwd2.touchable = false;
            UIPage.m_btn_create.visible = false;
        }
    }
}