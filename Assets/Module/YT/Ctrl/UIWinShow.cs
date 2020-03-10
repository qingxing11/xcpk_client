using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiningShow;
using WT.UI;

public class UIWinShow : WTUIPage<UI_WinShow, TaskCtrl>
{
    public UIWinShow() : base(UIType.PopUp, UIMode.DoNothing, R.UI.WININGSHOW)
    {

    }


    public override void Awake()
    {
        UIPage.m_click.onClick.Add(Hide);
    }
    public override void Refresh()
    {
        UIPage.m_text.text = "";
    }

    internal void setWinTextContent(long winCoins)
    {
        if (!isActive())
        {
            return;
        }

        UIPage.m_text.text = ToolClass.LongConverStr(winCoins);
        UIPage.m_playWin.Play();
        UIPage.m_playWin.SetHook("over", () => { base.Hide(); });
    }
}