using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using FirstCZ;
using System;
/// <summary>
/// 抽奖
/// </summary>
public class UILucky : WTUIPage<UI_Firstcharge, LuckyCtrl>
{
    public Action ActionPoint;
    public UILucky() : base(UIType.Dialog, UIMode.HideOther, R.UI.FIRSTCZ)
    {

    }

    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
    }

    internal void Init()
    {
        UIPage.m_Point.onClick.Clear();
        if (!CacheManager.gameData.isLucky)
        {
            UIPage.m_Point.m_c1.SetSelectedIndex(0);

            UIPage.m_Point.onClick.Add(() =>
            {
                ActionPoint?.Invoke();
            });
        }
        else //当月已经抽取过奖励
        {
            
            UIPage.m_Point.m_c1.SetSelectedIndex(1);
            //UIPage.m_Point.rotationX = (CacheManager.gameData.luckyNum*60+30);
            UIPage.m_Point.TweenRotate(CacheManager.gameData.luckyNum * 60  + 30, 0.005f);
        }
    }

    internal void PlayerRoundAnim(int luckyNum)
    {
        int i = UnityEngine.Random.Range(1,7);
        UIPage.m_Point.TweenRotate(360* i + 60* luckyNum + 30, 2f).OnComplete(()=> { UIPage.m_Point.m_c1.SetSelectedIndex(1); });
       
    }
}