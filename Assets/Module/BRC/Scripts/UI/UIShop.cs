
using Shop;
using WT.UI;

using FairyGUI;
using System;
using UnityEngine;

public class UIShop : WTUIPage<UI_shop, MailCtrl>
{
    public Action<int, int> ActionShop;
    public UIShop() : base(UIType.Dialog, UIMode.DoNothing, R.UI.SHOP)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_return.onClick.Add(base.Hide);
        InitBtn();
    }

    private void Init()
    {
        if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
        {
            Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
            UIPage.m_icon.texture = new NTexture(t2d);
        }
        else if (CacheManager.gameData.roleId == 0)
        {
            UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
        }
        else
        {
            UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
        }
        ToolClass.SetVipTexture(UIPage.m_vip, CacheManager.gameData.vipLv);
        UIPage.m_txt_nike.text = CacheManager.gameData.nickName;
        UIPage.m_txt_jinbi.text = CacheManager.gameData.coins.ToString();
        UIPage.m_txt_zuanshi.text = CacheManager.gameData.crystals.ToString();
    }

    public void RefreshVip()
    {
        if(isActive())
            ToolClass.SetVipTexture(UIPage.m_vip, CacheManager.gameData.vipLv);
    }

    internal void SetIndex(int index)
    {
        UIPage.m_c1.SetSelectedIndex(index);
    }

    private void InitBtn()
    {
        UIPage.m_list_shop0.GetChildAt(0).onClick.Add(() => { ActionShop?.Invoke(0, 0); });
        UIPage.m_list_shop0.GetChildAt(1).onClick.Add(() => { ActionShop?.Invoke(0, 1); });
        UIPage.m_list_shop0.GetChildAt(2).onClick.Add(() => { ActionShop?.Invoke(0, 2); });
        UIPage.m_list_shop0.GetChildAt(3).onClick.Add(() => { ActionShop?.Invoke(0, 3); });
        UIPage.m_list_shop0.GetChildAt(4).onClick.Add(() => { ActionShop?.Invoke(0, 4); });
        UIPage.m_list_shop0.GetChildAt(5).onClick.Add(() => { ActionShop?.Invoke(0, 5); });

        UIPage.m_list_shop1.GetChildAt(0).onClick.Add(() => { ActionShop?.Invoke(1, 0); });
        UIPage.m_list_shop1.GetChildAt(1).onClick.Add(() => { ActionShop?.Invoke(1, 1); });
        UIPage.m_list_shop1.GetChildAt(2).onClick.Add(() => { ActionShop?.Invoke(1, 2); });
        UIPage.m_list_shop1.GetChildAt(3).onClick.Add(() => { ActionShop?.Invoke(1, 3); });
        UIPage.m_list_shop1.GetChildAt(4).onClick.Add(() => { ActionShop?.Invoke(1, 4); });
        UIPage.m_list_shop1.GetChildAt(5).onClick.Add(() => { ActionShop?.Invoke(1, 5); });

        UIPage.m_list_shop2.GetChildAt(0).onClick.Add(() => { ActionShop?.Invoke(2, 0); });
        UIPage.m_list_shop2.GetChildAt(1).onClick.Add(() => { ActionShop?.Invoke(2, 1); });
        UIPage.m_list_shop2.GetChildAt(2).onClick.Add(() => { ActionShop?.Invoke(2, 2); });
        UIPage.m_list_shop2.GetChildAt(3).onClick.Add(() => { ActionShop?.Invoke(2, 3); });
        UIPage.m_list_shop2.GetChildAt(4).onClick.Add(() => { ActionShop?.Invoke(2, 4); });
        UIPage.m_list_shop2.GetChildAt(5).onClick.Add(() => { ActionShop?.Invoke(2, 5); });
    }
    public override void Refresh()
    {
        Init();
    }

    public void RefreshGoldAndCry()
    {
        UIPage.m_txt_jinbi.text = CacheManager.gameData.coins.ToString();
        UIPage.m_txt_zuanshi.text = CacheManager.gameData.crystals.ToString();
    }
}
