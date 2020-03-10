using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using WT.UI;
using Pay;
  public   class UIpay : WTUIPage<UI_Pay, PayCtrl>
{
    public Action weiXin;
    public Action zhiFuBao;
    public UIpay() : base(UIType.Dialog, UIMode.HideOther, R.UI.PAY)
    {
    }

    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_weiXin.onClick.Add(()=> {
            weiXin();
        });
        UIPage.m_zhiFuBao.onClick.Add(()=> {
            zhiFuBao();
        });
    }

    internal void SetInfo(int num, int price)
    {
        if (isActive())
        {
            UIPage.m_shopNum.text = num + "钻";
            UIPage.m_price.text = price + "元";
        }
    }
}