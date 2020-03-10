using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCtrl : BaseController
{
    private UIMessage uiMessage;
    private UITips uiTips;
    private UILow uiLow;
    private UIWinOrLossTips uiWinOrLossTips;
    public override void InitAction()
    {
        uiMessage = GetUIPage<UIMessage>();
        uiTips = GetUIPage<UITips>();
        uiLow = GetUIPage<UILow>();
        uiWinOrLossTips = GetUIPage<UIWinOrLossTips>();
    }
    public void Show(string str)
    {
        ShowUI<UIMessage>();
        uiMessage.PlayAnim(str, () =>
        {
            uiMessage.Hide();
        });
    }
    public void ShowTips()
    {
        string str = CacheManager.Helper_list[UnityEngine.Random.Range(0, CacheManager.Helper_list.Count)];
        ShowUI<UITips>();
        uiTips.Init(str);
    }
    public void ShowLow(string str)
    {
        ShowUI<UILow>();
        uiLow.PlayAnim(str, () =>
        {
            uiLow.Hide();
        });
    }
    /// <summary>
    /// 小贴士
    /// </summary>
    public void HideTipesUI()
    {
        if (uiTips != null && uiTips.isActive())
            uiTips.Hide();
    }

    public void ShowWinOrLosUI(string str)
    {
        ShowUI<UIWinOrLossTips>();
        uiWinOrLossTips.PlayAnim(str, () =>
         {
             uiWinOrLossTips.Hide();
         });
    }
}