using Lottery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;

public class UIGglwin : WTUIPage<UI_GglWin, LotteryCtrl>
{
    public UIGglwin() : base(UIType.PopUp, UIMode.DoNothing, R.UI.LOTTERY)
    {
    }
 
    public void ShowSigleCoin(long addCoin)
    {
        
        UIPage.m_txt_coinNUm.text = "金币+" + addCoin;

        UIPage.m_t0.Play(OnComplete);
    }

    


    private void OnComplete()
    {
        UIPage.m_t0.Stop();
        Hide();
    }

    public override void Hide()
    {
         base.Hide();
        if (window != null)
        {
            window.Dispose();
        }
       
    }
}
