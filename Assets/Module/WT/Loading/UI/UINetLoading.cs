using WT.UI;
using UnityEngine;
using System.Collections.Generic;
using NetLoading;
using NewLoding;

public class UINetLoading : WTUIPage<UI_NewLoading, LoadingCtrl> 
{
    private int reconectNum;
    
    public UINetLoading() : base(UIType.Dialog, UIMode.DoNothing, R.UI.NEWLODING)
    {

    }
     
    public override void Awake()
    {
        
    }

    public override void Refresh()
    {
        if ((bool)this.data)
        {
            reconectNum++;

        }  
    }

    public bool IsReconnect
    {
        get
        {
            return reconectNum > 0;
        }
    }

    public void HideLoading(bool isReconnect)
    {
        if (isReconnect)
        {
            reconectNum--;
        }
        Debug.Log("HideLoading,isReconnect:"+ isReconnect);
        Hide();
    }
}