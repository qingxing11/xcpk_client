using Set;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIFindPwd : WTUIPage<UI_zhmm, SetCtrl>
{
    public Action GetCode;
    public Action<string, string, string> FindPassword;

    public UIFindPwd() : base(UIType.Dialog, UIMode.HideOther, R.UI.SET)
    {

    }

    public override void Refresh()
    {
        UIPage.m_text_acc.text = CacheManager.gameData.account;
    }

    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);

        UIPage.m_btn_getCode.onClick.Add(() =>
        {
            GetCode?.Invoke();
        });

        UIPage.m_btn_ok.onClick.Add(() =>
        {
            FindPassword?.Invoke(UIPage.m_text_pwd1.text, UIPage.m_text_pwd2.text, UIPage.m_text_code.text);
        });
    }
}
