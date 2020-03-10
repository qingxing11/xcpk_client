
using Main;
using UnityEngine;
using WT.UI;

public class UIBanned : WTUIPage<UI_Banned, MainSceneCtrl>
{
    public UIBanned() : base(UIType.Normal, UIMode.DoNothing, R.UI.MAIN)
    {
    }

    public override void Awake()
    {
        UIPage.m_btn_sure.onClick.Add(()=> {
            Application.Quit();
        });
    }

    public void SetUserId(string userId)
    {
        UIPage.m_bannedId.text = userId;
    }
}