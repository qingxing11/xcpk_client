using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCtrl : BaseController
{
    private UIExit uiExit; 
    public override void InitAction()
    {
        uiExit = GetUIPage<UIExit>();
    }
    public void Show()
    {
        ShowUI<UIExit>();
    }
}
