using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrendCtrl : BaseController
{
    private UITrend uiTrend;
    public override void InitAction()
    {
        uiTrend = GetUIPage<UITrend>();
    }
    public void Show()
    {
        ShowUI<UITrend>();
    }
}
