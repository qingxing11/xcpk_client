
using Main;
using UnityEngine;
using Version;
using WT.UI;

public class UIBigVersion : WTUIPage<UI_BigVersionChange, MainSceneCtrl>
{
    public UIBigVersion() : base(UIType.Dialog, UIMode.DoNothing, R.UI.VERSION)
    {
    }

    public override void Awake()
    {
        UIPage.m_btn_ok.onClick.Add(()=> {
            Application.OpenURL("http://47.100.229.107/");
        });

        UIPage.m_btn_close.onClick.Add(() => {
            Application.Quit();
        });
    }
 
}