using Lottery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;

public class UILotteryLose : WTUIPage<UI_LotteryLose, LotteryCtrl>
{
    public UILotteryLose() : base(UIType.Dialog, UIMode.DoNothing, R.UI.LOTTERY)
    {
    }

    public void ShowCoin()
    {
        UIPage.m_lose.visible = true;

        UIPage.m_t0.Play(() => { Hide(); });
    }

}
