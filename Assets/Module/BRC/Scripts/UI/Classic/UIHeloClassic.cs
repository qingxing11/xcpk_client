using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Help;
using WT.UI;

public class UIHeloClassic : WTUIPage<UI_helpClassic, HelpCtrl>
{
    public UIHeloClassic() : base(UIType.PopUp, UIMode.DoNothing, R.UI.HELP)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
    }
}