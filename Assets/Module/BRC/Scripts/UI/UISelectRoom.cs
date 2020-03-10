using Main;
using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UISelectRoom : WTUIPage<UI_SelectRoom, MainSceneCtrl>
{
    public Action ActionAllKill;  //进入通杀场
    public Action ActionFruit;   //进入水果机
    public Action ActionClassic; //进入经典场
    public Action ActionClose;   //关闭当前页面
    public Action ActionManyPeople; //万人场
    public Action ActionYule;//娱乐场
    public UISelectRoom() : base(UIType.PopUp, UIMode.DoNothing, R.UI.MAIN)
    {
    }
    public override void Awake()
    {
        UIPage.m_btn_fruit2.onClick.Add(() => { ActionFruit?.Invoke(); base.Hide(); });
        UIPage.m_btn_allkill2.onClick.Add(() => { ActionAllKill?.Invoke();base.Hide(); });  //通杀局
        UIPage.m_btn_classic.onClick.Add(() => { ActionClassic?.Invoke(); base.Hide(); });  //经典场
        UIPage.m_btn_manyPeople.onClick.Add(() => { ActionManyPeople?.Invoke(); base.Hide(); });//万人场
        UIPage.m_btn_yule.onClick.Add(() => { ActionYule?.Invoke(); });
        UIPage.m_btn_return.onClick.Add(ReturnOnClick);
    }
    private void ReturnOnClick()
    {
        base.Hide();
        ActionClose.Invoke();
    }
}