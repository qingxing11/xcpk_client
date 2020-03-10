using FairyGUI;
using Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIWinOrLossTips : WTUIPage<UI_winOrLoss, MessageCtrl>
{
    public UIWinOrLossTips() : base(UIType.PopUp, UIMode.HideOther, R.UI.MESSAGE)
    {
    }
    public void PlayAnim(string str, PlayCompleteCallback callback)
    {
        UIPage.m_text_content.text = str;
        UIPage.m_t0.Play(callback);
    }
}