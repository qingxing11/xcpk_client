using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreCtrl : BaseController
{
    public UIMore uiMore;
    public override void InitAction()
    {
        uiMore = GetUIPage<UIMore>();
        uiMore.ActionFruit = ShowFruitTV;
        uiMore.ActionKill = SendEnterKillRoomRequest;
        uiMore.ActionTenThousand = SendEnterTenThousand;
    }

    private void SendEnterTenThousand()
    {
        CacheManager.manyPeopleId = 1;
        GetController<TenThousandRoomCtrl>().SendEnterManyPeopleRoom();
    }

    public void Show(int index)
    {
        ShowUI<UIMore>();
        uiMore.Init(index);
    }
    private void ShowFruitTV()
    {
        GetController<FruitMechineCtrl>().ShowUIFruitMechine(2);
    }
    private void SendEnterKillRoomRequest()
    {
        CacheManager.KillRoomTV = 1;
        EnterKillRoomRequest request = new EnterKillRoomRequest();
        SendMessage(request);
    }
    public void Hide()
    {
        if (uiMore!=null&& uiMore.isTrue)
        {
            uiMore.Hide();
        }
    }

    public void Hide2()
    {
        if (uiMore != null && uiMore.isTrue)
        {
            uiMore.Hide2();
        }
    }

    public void HideTV()
    {
        GetController<FruitMechineCtrl>().HideTV();
        GetController<TenThousandRoomCtrl>().HideTV();
        GetController<RoomCtrl>().HideTV();
        Hide();
      
    }
}