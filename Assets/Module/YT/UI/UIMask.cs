using FruitMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;

public  class UIMask : WTUIPage<UI_mask, FruitMechineCtrl>
{
    public UIMask() : base(UIType.Normal, UIMode.DoNothing, R.UI.FRUITMACHINE)
    {
    }


    public void PlayAnim()
    {
        UIPage.m_t0.Play();
    }

    public void ShowSelectIndex(int show)
    {
        UIPage.m_scale.selectedIndex = show - 1;
    }
}