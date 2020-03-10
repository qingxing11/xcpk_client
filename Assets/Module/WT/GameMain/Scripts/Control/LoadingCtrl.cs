using DG.Tweening;
using UnityEngine;
using WT.UI;

public class LoadingCtrl : BaseController
{
    private UINetLoading uiWaitClock;
    public override void InitAction()
    {
        uiWaitClock = WTUIPage.GetUIPage<UINetLoading>();
    }

    public void ShowLoading(bool isReconnect = false)
    {
        if (!uiWaitClock.isActive())
        {
            Debug.Log("showLoading");
            uiWaitClock.ShowSelf();
            WTUIPage.ShowPage<UINetLoading>(isReconnect);
           
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isReconnect"></param>
    public void HideLoading(bool isReconnect)
    {
        if (uiWaitClock.isActive())
        {
            if (uiWaitClock.IsReconnect && isReconnect)
            {
                uiWaitClock.HideLoading(true);
            }
            else if (!uiWaitClock.IsReconnect)
            {
                uiWaitClock.HideLoading(false);
            }
        }
    }

}