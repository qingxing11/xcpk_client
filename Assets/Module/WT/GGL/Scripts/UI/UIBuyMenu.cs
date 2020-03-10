using FairyGUI;
using Guaguale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;
 
public   class UIBuyMenu : WTUIPage<UI_BuyMenu, GGLCtrl>
{

    public Action<int, int,int> ziDingYiBuy;//张数，需要的金币,购买类型

    private int zhangValue = 0;//自定义购买张数
    private int coins = 0;//
    private int buyCostCoins =1000;// 购买类型 1->1000   2->10000  3->100000  默认 1000
    private int buyType;

    private List<int> list_money;
    public UIBuyMenu() : base(UIType.PopUp, UIMode.DoNothing, R.UI.GUAGUALE)
    {

    }
    public override void Awake()
    {
        UIPage.m_num.text = "";
        UIPage.m_txt_money.text = "";
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_btn_cancel.onClick.Add(Hide);
        UIPage.m_btn_buy.onClick.Add(()=> {
            if (zhangValue==0)
            {
                //请先添加购买张数
                return;
            }
            ziDingYiBuy.Invoke(zhangValue,zhangValue* buyCostCoins, buyType);
        });

        UIPage.m_btn_add.onClick.Add(()=> {
            if (zhangValue<100)
            {
                zhangValue++;
                UIPage.m_num.text = zhangValue.ToString();
                UIPage.m_txt_money.text = (zhangValue * buyCostCoins).ToString();

            }
        });
        UIPage.m_btn_add.onTouchMove.Add(() => {
            Debug.Log("张数增加："+zhangValue);
            if (zhangValue+10>100)
            {
                zhangValue = 100;
                UIPage.m_num.text = zhangValue.ToString();
                UIPage.m_txt_money.text = (zhangValue * buyCostCoins).ToString();
                return;
            }
            zhangValue += 10;
            UIPage.m_num.text = zhangValue.ToString();
           UIPage.m_txt_money.text = (zhangValue * buyCostCoins).ToString();
        });
        UIPage.m_btn_sub.onClick.Add(() => {
            if (zhangValue >0)
            {
                zhangValue--;
                UIPage.m_num.text = zhangValue.ToString();
                UIPage.m_txt_money.text = (zhangValue * buyCostCoins).ToString();
            }
        });

        UIPage.m_btn_NextBuy.onClick.Add(()=> {
            ClickReBuy();
        });

        UIPage.m_list_history.itemRenderer = CustomizeBuyItemRenderer;


        window.rotation = -90;
        Vector2 scale = window.scale;
        window.SetScale(scale.y, scale.x);
        window.y = window.width * scale.y;
    }

    private void ClickReBuy()
    {
        ziDingYiBuy.Invoke(zhangValue, zhangValue * buyCostCoins, buyType);
    }

    private string numTonum(int index)
    {
        switch (index)
        {
            case 1:
                return "一";
            case 2:
                return "二";
            case 3: return "三";
            case 4: return "四";
            case 5: return "五";
            case 6: return "六";
            case 7: return "七";
            case 8: return "八";
            case 9: return "九";
            case 10: return "十";
            default: return "";
        }
    }


    private void CustomizeBuyItemRenderer(int index, GObject item)
    {
        UI_MyTxtItem txtItem = item as UI_MyTxtItem;
        Debug.Log("第" + (index + 1) + "张：" + list_money[index]);
        if (list_money[index] > 0)
        {
            txtItem.m_c1.selectedIndex = 1;

            //txtItem.m_txt_myTitlle2.text = "第" + numTonum(index + 1) + "张：";//  list_money[0]; 
            txtItem.m_txt_myTitlle3.text = "第" + (index + 1) + "张： " + ToolClass.GuaGuale(list_money[index]);
        }
        else
        {
            txtItem.m_c1.selectedIndex = 0;
            txtItem.m_txt_myTitlle.text = "第" + (index + 1) + "张未";
        }
    }

    public override void Refresh()
    {
        zhangValue = 10;
        UIPage.m_num.text = zhangValue.ToString();
        UIPage.m_txt_money.text = (zhangValue * buyCostCoins).ToString();
    }
    /// <summary>
    /// 购买方式 1 >自定义  /    2 >购买一张  
    /// </summary>
    /// <param name="type"></param>
    public void SetInfo(int type,int buyType)
    {
        switch (type)
        {
            case 1:
                UIPage.m_c1.selectedIndex = 0;
                break;
            default:
                UIPage.m_c1.selectedIndex = 1;
                break;
        }
        this.buyType = buyType;
        switch (buyType)
        {
            case 0:
                buyCostCoins = 1000;
                break;
            case 1:
                buyCostCoins = 10000;
                break;
            case 2:
                buyCostCoins = 100000;
                break;
        }
    }

   
    internal void ShowCustomizeBuy(List<int> list_money, int gift)
    {
        UIPage.m_c1.selectedIndex = 1;
        this.list_money = list_money;
 
        UIPage.m_list_history.numItems = list_money.Count;
        UIPage.m_txtAllReward.text = ToolClass.GuaGuale(gift);
    }
}