using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Help;
using WT.UI;

public class UIHelp : WTUIPage<UI_help, HelpCtrl>
{
    public UIHelp() : base(UIType.Dialog, UIMode.DoNothing, R.UI.HELP)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
    }
}