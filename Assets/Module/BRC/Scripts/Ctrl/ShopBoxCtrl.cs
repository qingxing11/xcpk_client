using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 保险箱和商城面板
/// </summary>
public class ShopBoxCtrl : BaseController
{
    private UIShopBox uiShopBox;        //保险箱和商城面板
    public override void InitAction()
    {
        uiShopBox = GetUIPage<UIShopBox>();
        uiShopBox.btnBox = BtnBox;
        uiShopBox.ActionShop = ShowShopUI;
    }

    private void BtnBox()
    {
        GetController<SafeBoxCtrl>().ShowUISafeBoxCom2();
    }

    private void ShowShopUI()
    {
        GetController<ShopCtrl>().Show(0);
    }

    public void Show()
    {
        ShowUI<UIShopBox>();
        uiShopBox.Init();
    }
    public void Hide()
    {
        if (uiShopBox != null && uiShopBox.isActive())
            uiShopBox.Hide();
    }
    public void Hide2()
    {
        if (uiShopBox != null && uiShopBox.isActive())
        {
            uiShopBox.Hide2();
        }
    }
}
