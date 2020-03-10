using Classic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIGifLuckyBox : WTUIPage<UI_luckyBoxGif, LuckyBoxCtrl>
{
    public UIGifLuckyBox() : base(UIType.PopUp, UIMode.DoNothing, R.UI.CLASSIC)
    { }

    public override void Awake()
    {
        UIPage.onClick.Add(()=>{ base.Hide();BaseCanvas.GetController<LuckyBoxCtrl>().Hide(); });
    }
    public void Init(int index)
    {
        UIPage.m_c1.SetSelectedIndex(index);
    }
}