/**
* 命名空间: Assets.Module.UIGuanDan.Script
* 功 能： N/A
* 类 名： UISystemMessage
* 作用：系统信息 面板
* Ver 变更日期 负责人 刘辉
* V0.01 2018/3/13 15:51:12 
* Copyright (c) 2017 NanJingDianYing.
*/
using System;
using WT.UI;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UISystemMessage:WTUIPage
{
    public UISystemMessage()
        : base(UIType.PopUp, UIMode.HideOther)
    {
       
    }

    GameObject emails;
   


    /// <summary>
    /// 点击退出
    /// </summary>
    public void ClickButton_Exit()
    {
        Hide();
    }

    public override void Refresh()
    {
      
    }

    protected override void InitLanguage()
    {
        
    }
}
