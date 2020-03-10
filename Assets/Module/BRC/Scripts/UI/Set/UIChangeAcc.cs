using Set;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
/// <summary>
/// 切换账号
/// </summary>
public class UIChangeAcc : WTUIPage<UI_qhzh, SetCtrl>
{
    public Action<string, string> btn_ok;

    public UIChangeAcc() : base(UIType.Dialog, UIMode.HideOther, R.UI.SET)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_ok.onClick.Add(()=> {
            Debug.Log("Hide.....");
            base.Hide();
            btn_ok?.Invoke(UIPage.m_account.text, UIPage.m_password.text);
        });

        UIPage.m_btn_close.onClick.Add(base.Hide);
    }
}