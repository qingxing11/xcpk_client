using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exit;
using WT.UI;
using FairyGUI;
using System;

public class UIExit : WTUIPage<UI_exit, ExitCtrl>
{
    public UIExit() : base(UIType.Dialog, UIMode.HideOther,R.UI.EXIT )
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
        UIPage.m_btn_cancel.onClick.Add(base.Hide);
        UIPage.m_btn_ok.onClick.Add(OkOnClick);
    }

    private void OkOnClick(EventContext context)
    {
        Application.Quit();
    }
}