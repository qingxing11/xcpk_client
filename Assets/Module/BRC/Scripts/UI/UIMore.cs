using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using More;
using System;

public class UIMore : WTUIPage<UI_more, MoreCtrl>
{ 
    public Action ActionFruit;
    public Action ActionKill;
    public Action ActionTenThousand;
    public bool isTrue;
    public UIMore() : base(UIType.PopUp, UIMode.DoNothing, R.UI.MORE)
    {
    }

    public override void Awake()
    {
        UIPage.m_text_packUp.onClick.Add(Hide2);
        UIPage.m_btn_fruit.onClick.Add(()=> { ActionFruit?.Invoke(); });
        UIPage.m_btn_kill.onClick.Add(() => { ActionKill?.Invoke(); });
        UIPage.m_btn_wanren.onClick.Add(()=> {ActionTenThousand.Invoke(); });
    }
    internal void Init(int index)
    {
        UIPage.m_c1.SetSelectedIndex(index);
        UIPage.SetPosition(800, 0,0);
        UIPage.TweenMoveX(725, 1f).OnComplete(()=> { isTrue = true; });
    }
    public void Hide2()
    {
        UIPage.TweenMoveX(800, 1f).OnComplete(() => {
            base.Hide();
            isTrue = false;
        });
    }
    public override void Hide()
    {
        base.Hide();
        isTrue = false;
    }
}