using FruitMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;

public   class UIShowTips : WTUIPage<UI_ShowTips, FruitMechineCtrl>
{
    public UIShowTips() : base(UIType.PopUp, UIMode.DoNothing, R.UI.FRUITMACHINE)
    {
    }
    public void ShowTips(string content,int index=1)
    {
        if (index==1)
        {
            UIPage.m_index.selectedIndex = 0;
            UIPage.m_n3.text = content;
            UIPage.m_play1.Play();
        }
        else
        {
            UIPage.m_index.selectedIndex = 1;
            UIPage.m_n8.text = content;
            UIPage.m_play2.Play();
        }
    }
}