using Config;
using DG.Tweening;
using System;
using Tree;
using UnityEngine;
using WT.UI;
/// <summary>
/// 摇钱树页面
/// </summary>
public class UITree : WTUIPage<UI_Tree, TreeCtrl>
{
    private Tween tween;
    public Action getMoney;
    private int baseMoneyInHour = 1000;//基本金币
    private float baseOutputfficiency = 100 / 100f;//基本效率
    private int lvAddMoneyInHour = 50;//基本等级增加，每小时增加金币量
    private int improveLvNeedExp = 20;//提升一等级，需要的经验
    private int topUpAddExp = 1;//每充值一元增加的经验值
    private float improveLvAddOutput = 0.01f;//每提升一级增加的产出效率
    private float improveVipLvAddOutput = 0.2f;//VIp每级增加的产出效率

    public UITree() : base(UIType.Dialog, UIMode.DoNothing, R.UI.TREE)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_btn_ok.onClick.Add(() => getMoney());
    }

    public override void Refresh()
    {
        base.Refresh();
        RefreshLv();
        ShowTxtInEffAndCoin();
    }

    private void ShowTxtInEffAndCoin()
    {
        int vipLv = CacheManager.gameData.vipLv;
        int treeLv = CacheManager.gameData.treeLv;
        int lv = CacheManager.gameData.playerLevel;
        float efficency = GetMoneyEfficiency(vipLv,lv);
        long moneyCoin = GetPreHourCoin(treeLv, efficency);
        UIPage.m_txt_coin_pre.text =Math.Round(efficency,2)*100+ "%"+"="+"("+"VIP"+vipLv+"+100%,等级+"+(lv)+"%)";
        UIPage.m_txt_hour.text = moneyCoin+ "=(1000+"+ ((treeLv) * lvAddMoneyInHour)+")X"+ Math.Round(efficency, 2) * 100 + "%";

    }

    /// <summary>
    /// 效率
    /// </summary>
    /// <param name="vipLv"></param>
    /// <param name="lv"></param>
    /// <returns></returns>
    private float GetMoneyEfficiency(int vipLv,int lv)
    {
        return baseOutputfficiency + improveVipLvAddOutput * vipLv + (lv) * improveLvAddOutput;
    }

    /// <summary>
    /// 金币数
    /// </summary>
    /// <param name="lv"></param>
    /// <returns></returns>
    private long GetPreHourCoin(int treeLv,float efficency)
    {
        return (long)((baseMoneyInHour + (treeLv) * lvAddMoneyInHour)* efficency);
    }




    /// <summary>
    /// 刷新等级
    /// </summary>
    public void RefreshLv()
    {
        UIPage.m_txt_lv.text = "LV" + CacheManager.gameData.treeLv;
        //UIPage.m_txt_money.text = NeedNextVipLvMoney(CacheManager.gameData.vipLv).ToString();
    }

    private int NeedNextVipLvMoney(int vipLv)
    {
        int money = 0;
        switch (vipLv)
        {
            case 0:
                money = EnumVipLvTopUp.one;
                break;
            case 1:
                money = EnumVipLvTopUp.two;
                break;
            case 2:
                money = EnumVipLvTopUp.three;
                break;
            case 3:
                money = EnumVipLvTopUp.four;
                break;
            case 4:
                money = EnumVipLvTopUp.five;
                break;
            default:
                break;
        }
        return money;
    }

    /// <summary>
    /// 多少金币可以领取
    /// </summary>
    public void GetCoin(long money)
    {
        string txt = money.ToString();
        //string txt = "";
        //if (money < 0)
        //{
        //    txt = "0";
        //}
        //else if (money > 10000)
        //{
        //    money /= 10000;
        //    txt = money+ "万";
        //}
        //else
        //{
        //    txt = money.ToString();
        //}
        
        UIPage.m_txt_coin.text = txt;//多少万金币

    }




    /// <summary>
    ///领取按钮是否可用
    /// </summary>
    private void SetOkFalse(bool show)
    {
        UIPage.m_btn_ok.enabled = show;
    }

    public void ShowTime(long mm)
    {
        if (tween!=null)
        {
            tween.Kill();
        }
        //Debug.Log("剩余时间："+ GetHour(mm/1000)+ ",mm:"+mm);
        tween = DOTween.To(() => mm, (value) => { UIPage.m_txt_time.text = GetHour(value); }, 0, mm/1000).SetEase(Ease.Linear).OnComplete(() =>
        {
            //BtnOk(0);
        });

    }
    public void BtnOk(long money)
    {

        if (money >0)
        {
            Debug.Log("摇钱树可以领取");
            SetOkFalse(true);//可以领取
        }
        else
        {
            Debug.Log("摇钱树不可以领取");
            SetOkFalse(false);//不可以领取
        }
    }

    public string GetHour(long mm)
    {
        int hour = (int)(mm / MyTimeUtil.TIME_H);
        int min = (int)(mm %MyTimeUtil.TIME_H/MyTimeUtil.TIME_M);
        int s = (int)(mm % MyTimeUtil.TIME_H % MyTimeUtil.TIME_M/MyTimeUtil.TIME_S);
        string hourS = hour > 9 ? hour.ToString() : "0" + hour;
        string minS = min > 9 ? min.ToString() : "0" + min;
        string sS = s > 9 ? s.ToString() : "0" + s;
        return hourS + ":" + minS + ":" + sS;
    }

}