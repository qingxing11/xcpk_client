using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;
using TxtTitle;
using DG.Tweening;
using UnityEngine;

public class UITxtCom : WTUIPage<UI_TxtCom, TxtCtrl>
{
    private Tween tween;
    private Tween tween2;
    private float time = 1.5f;
    public Action over;

    public UITxtCom() : base(UIType.Dialog, UIMode.DoNothing, R.UI.TXTTITLE)
    {

    }

    public void ShowTxt(string txt)
    {
        if (tween!=null)
        {
            tween.Kill();
        }
        UIPage.m_txt.text = txt;
        tween = DOTween.To(() => time, (value) => { }, 1, time).OnComplete(Hide);
    }

    public void ShowTxt2(string info)
    {
        if (tween2 != null)
        {
            tween2.Kill();
        }
        UIPage.m_txt.text = info;
        //Debug.Log("info:" + info);
        tween2 = DOTween.To(() => time, (value) => { }, 1, time+1).OnComplete(()=>over());
    }
    public override void Hide()
    {
        base.Hide();
        //Debug.Log("Hide 隐藏");
    }
}
