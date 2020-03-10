using Classic;
using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
/// <summary>
/// 宝箱
/// </summary>
public class UILuckyBox : WTUIPage<UI_luckyBox, LuckyBoxCtrl>
{
    public Action<int> ActionLuckyBox;
   

    public UILuckyBox() : base(UIType.PopUp, UIMode.DoNothing, R.UI.CLASSIC)
    { }

    public override void Awake()
    {
        UIPage.m_box1.onClick.Add(() => { BoxOnClick(1); });
        UIPage.m_box2.onClick.Add(() => { BoxOnClick(2); });
        UIPage.m_box3.onClick.Add(() => { BoxOnClick(3); });
        UIPage.m_box4.onClick.Add(() => { BoxOnClick(4); });
        UIPage.m_box5.onClick.Add(() => { BoxOnClick(5); });
    }
    private void BoxOnClick(int index)
    {
        if (index == CacheManager.gameData.vipLv)
        {
            switch (index)
            {
                case 1: UIPage.m_box1.m_c1.SetSelectedIndex(1); break;
                case 2: UIPage.m_box2.m_c1.SetSelectedIndex(1); break;
                case 3: UIPage.m_box3.m_c1.SetSelectedIndex(1); break;
                case 4: UIPage.m_box4.m_c1.SetSelectedIndex(1); break;
                case 5: UIPage.m_box5.m_c1.SetSelectedIndex(1); break;
                default:
                    break;
            }
            ActionLuckyBox?.Invoke(index);
        }
    }

    internal void PlayAnima(int index,int num)
    {
        UIPage.m_c1.SetSelectedIndex(index-1);
        UIPage.m_t0.Play();
        UIPage.m_t0.SetHook("over", () => { });
        switch (index)
        {
            case 1: UIPage.m_coins1.text = "+" + num.ToString(); UIPage.m_t0.SetHook("over", () => { UIPage.m_coins1.text = ""; }); break;
            case 2: UIPage.m_coins2.text = "+" + num.ToString(); UIPage.m_t0.SetHook("over", () => { UIPage.m_coins2.text = ""; }); break;
            case 3: UIPage.m_coins3.text = "+" + num.ToString(); UIPage.m_t0.SetHook("over", () => { UIPage.m_coins3.text = ""; }); break;
            case 4: UIPage.m_coins4.text = "+" + num.ToString(); UIPage.m_t0.SetHook("over", () => { UIPage.m_coins4.text = ""; }); break;
            case 5: UIPage.m_coins5.text = "+" + num.ToString(); UIPage.m_t0.SetHook("over", () => { UIPage.m_coins5.text = ""; }); break;
            default:
                break;
        }
       
    }

    public void Init()
    {
        switch (CacheManager.gameData.vipLv)
        {
            case 1:
                UIPage.m_box1.m_t0.Play();
                break;
            case 2:
                UIPage.m_box2.m_t0.Play();
                break;
            case 3:
                UIPage.m_box3.m_t0.Play();
                break;
            case 4:
                UIPage.m_box4.m_t0.Play();
                break;
            case 5:
                UIPage.m_box5.m_t0.Play();
                break;
            default:
                break;
        }
    }

    public override void Hide()
    {
        if (UIPage == null)
        {
            return;
        }
        UIPage.m_box1.m_c1.SetSelectedIndex(0);
        UIPage.m_box1.m_t0.Stop();
        UIPage.m_box2.m_c1.SetSelectedIndex(0);
        UIPage.m_box2.m_t0.Stop();
        UIPage.m_box3.m_c1.SetSelectedIndex(0);
        UIPage.m_box3.m_t0.Stop();
        UIPage.m_box4.m_c1.SetSelectedIndex(0);
        UIPage.m_box4.m_t0.Stop();
        UIPage.m_box5.m_c1.SetSelectedIndex(0);
        UIPage.m_box5.m_t0.Stop();
        base.Hide();
    }
}