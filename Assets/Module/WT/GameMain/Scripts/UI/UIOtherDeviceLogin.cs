
using Main;
using UnityEngine;
using WT.UI;

public class UIOtherDeviceLogin : WTUIPage<UI_OtherDeviceLogin, MainSceneCtrl>
{
    public UIOtherDeviceLogin() : base(UIType.Dialog, UIMode.DoNothing, R.UI.MAIN)
    {
    }

    public override void Awake()
    {
        UIPage.m_btn_sure.onClick.Add(()=> {
            Application.Quit();
        });
    }
 
}