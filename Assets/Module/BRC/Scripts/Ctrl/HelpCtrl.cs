using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCtrl : BaseController
{
    private UIHelp uiHelp;
    private UIHeloClassic uIHeloClassic;
    public override void InitAction()
    {
        uiHelp = GetUIPage<UIHelp>();
        uIHeloClassic = GetUIPage<UIHeloClassic>();
    }
    public void Show()
    {
        ShowUI<UIHelp>();
    }
    public void ShowHelpClassicUI()
    {
        ShowUI<UIHeloClassic>();
}
}