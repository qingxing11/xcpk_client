using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackpotCtrl : BaseController
{
    private UIJackpot uiJackpot;
    public override void InitAction()
    {
        uiJackpot = GetUIPage<UIJackpot>();
    }
    public void Show(JackpotData jackpotData,long jackPot)
    {
        ShowUI<UIJackpot>();
        uiJackpot.Init(jackpotData,jackPot);
    }
}