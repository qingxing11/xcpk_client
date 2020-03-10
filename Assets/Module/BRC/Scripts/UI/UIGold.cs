using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Room;
using WT.UI;
using System;
using FairyGUI;

public class UIGold : WTUIPage<UI_gold, RoomCtrl>
{
    /// <summary>
    /// 起始位置
    /// </summary>
    public int startPos;
    /// <summary>
    /// 到达位置
    /// </summary>
    public int endPos;

    private GTweener gTween;
    public UIGold() : base(UIType.Fixed, UIMode.DoNothing, R.UI.ROOM)
    {
    }

    public void Init(int startPos, int endPos)
    {
        this.endPos = endPos;
        this.startPos = startPos;
    }
    public void SetVisible(bool isTrue)
    {
        UIPage.visible = isTrue;
    }
    public bool GetVisible()
    {
        return UIPage.visible;
    }

    internal void SetGTweener(GTweener gTween)
    {
        this.gTween = gTween;
    }

    public void KillTweener()
    {
        if (gTween != null)
        {
            gTween.Kill();
        }
    }
 

    public override WTUIPage SetPosition(Vector3 v3)
    {
 

        return base.SetPosition(v3); ;
    }
}