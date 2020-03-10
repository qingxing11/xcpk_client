using FairyGUI;
using Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UITips : WTUIPage<UI_Tips, MessageCtrl>
{
    public UITips() : base(UIType.Dialog, UIMode.HideOther, R.UI.MESSAGE)
    {
    }
    public void Init(string str)
    {
        UIPage.m_text_content.text = str;
    }
}