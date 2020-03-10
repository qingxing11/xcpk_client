using Room;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

/// <summary>
/// 保险箱和商城面板
/// </summary>
public class UIShopBox : WTUIPage<UI_ShopBox, ShopBoxCtrl>
{
    public Action btnBox;
    public Action ActionShop;
    private bool isCtrlPanel = false;
    public UIShopBox() : base(UIType.PopUp, UIMode.HideOther, R.UI.ROOM)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_box.onClick.Add(() => btnBox());
        UIPage.m_btn_conrol.onClick.Add(CtrlPanelOnClick);
        UIPage.m_btn_shop.onClick.Add(() => { ActionShop?.Invoke(); });
        UIPage.SetPosition(-68, 0, 0);
    }

    internal void Init()
    {
        UIPage.SetPosition(-68, 0, 0);
    }

    private void CtrlPanelOnClick()
    {
        if (!isCtrlPanel)
        {
            UIPage.TweenMoveX(0, 0.5f).OnComplete(() => { isCtrlPanel = true; });
        }
        else
        {
            UIPage.TweenMoveX(-68, 0.5f).OnComplete(() => { isCtrlPanel = false; });
        }
    }
    public void Hide2()
    {
        UIPage.TweenMoveX(-68, 0.5f).OnComplete(() =>
        {
            isCtrlPanel = false;
        });
    }
}