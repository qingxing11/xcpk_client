using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using Set;
using System;
/// <summary>
/// 修改密码
/// </summary>
public class UIModifyPwd : WTUIPage<UI_xgmm, SetCtrl>
{
    public Action<string,string> ActionModifyPwd;
    public Action<string> ActionShowErrorLog;
    public UIModifyPwd() : base(UIType.Dialog, UIMode.HideOther, R.UI.SET)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
        UIPage.m_btn_ok.onClick.Add(BtnOkOnClick);
    }

    private void BtnOkOnClick()
    {
        if (string.IsNullOrEmpty(UIPage.m_text_oldPwd.text))
        {
            BaseCanvas.GetController<MessageCtrl>().Show("旧密码不能为空");
            return;
        }
        if (UIPage.m_text_newPwd1.text != UIPage.m_text_newPwd2.text)
        {
            BaseCanvas.GetController<MessageCtrl>().Show("两次输入的密码不一致");
            return;
        }
        string pattern = @"^[a-zA-Z][a-zA-Z0-9]*$"; //匹配字符是以字母开头的字母数字组合
        if (!System.Text.RegularExpressions.Regex.IsMatch(UIPage.m_text_newPwd1.text, pattern))
        {
            BaseCanvas. GetController<MessageCtrl>().Show("密码必须是以字母开头的字母或者数字组合");
            Debug.LogError("密码必须是以字母开头的字母或者数字组合");
            return;
        }
        //需要加其他调价判断
        ActionModifyPwd?.Invoke(UIPage.m_text_oldPwd.text, UIPage.m_text_newPwd1.text);
    }
}