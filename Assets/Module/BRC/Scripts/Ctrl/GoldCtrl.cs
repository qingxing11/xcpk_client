using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCtrl : BaseController
{
    private UIGold uiGold;
    public override void InitAction()
    {
    }
    public UIGold Show(string name)
    {
        uiGold = ShowUI<UIGold>(name);
        return uiGold;
    }
}