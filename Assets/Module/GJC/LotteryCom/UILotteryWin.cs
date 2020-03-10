using Lottery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;

public class UILotteryWin : WTUIPage<UI_LotteryWin, LotteryCtrl>
{
    public UILotteryWin() : base(UIType.Dialog, UIMode.DoNothing, R.UI.LOTTERY)
    {
    }

    public void ShowCoin(long addCoin)
    {
        UIPage.m_win.visible = true;
        UIPage.m_txt_coinNUm.text = "金币+" + addCoin;

        UIPage.m_t0.Play(() => { Hide(); });
    }
    public void ShowSigleCoin(long addCoin)
    {
        UIPage.m_win.visible = false;
        UIPage.m_txt_coinNUm.text = "金币+" + addCoin;

        UIPage.m_t0.Play(() => { Hide(); });
    }
}
