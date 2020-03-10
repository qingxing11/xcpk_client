using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectClassicCtrl : BaseController, IHandlerReceive
{
    private UISelectClassic uiSelectClassic;
    public override void InitAction()
    {
        uiSelectClassic = GetUIPage<UISelectClassic>();
        uiSelectClassic.ActionSelectRoom = SendSelectRequest;
    }

    public void Show()
    {
        ShowUI<UISelectClassic>();
    }
    private void SendSelectRequest(int type)
    {
        EnterBeginnerRequest request = new EnterBeginnerRequest
        {
            type = type,
        };
        SendMessage(request);
    }


    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.classic_进入新手场:
                    ReceiveEnterBeginner(response.data);

                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    //Debug.Log("进入经典场");
    private void ReceiveEnterBeginner(byte[] data)
    {
        EnterBeginnerResponse response = MySerializerUtil.DeSerializerFromProtobufNet<EnterBeginnerResponse>(data);
        switch (response.code)
        {
            case EnterBeginnerResponse.SUCCESS:
                CacheManager.LeaveKillRoom();
                GetController<RoomCtrl>().HideOn();
                CacheManager.classRoomState = response.state;
                CacheManager.list_allBet.Clear();
                if (response.list_allBet != null)
                {
                    CacheManager.list_allBet = response.list_allBet;
                }


                GetController<RoomCtrl>().ClearAllCoins();
                CacheManager.RunRoomId = 1;
                CacheManager.selfPos = response.pos;
                CacheManager.classicType = response.type;
                CacheManager.actionPos = ToolClass.AbsToRel(response.actionPos);
                CacheManager.actionTime = response.actionTime;
                for (int i = 0; i < 5; i++)
                {
                    CacheManager.ClassRoomPlayers[i] = null;
                }

                for (int i = 0; i < response.list_tablePlayer.Count; i++)
                {
                    PlayerSimpleData playerSimpleData = response.list_tablePlayer[i];
                    ToolClass.GetHead(playerSimpleData);
                    if (playerSimpleData != null)
                    {
                        playerSimpleData.sprites.Clear();
                        int pos = ToolClass.AbsToRel(playerSimpleData.classicGamepos);
                        CacheManager.ClassRoomPlayers[pos] = playerSimpleData;
                        CacheManager.ClassRoomRoleId[pos] = playerSimpleData.roleId;
                        ToolClass.SetRankSprite(playerSimpleData);
                    }
                }
                CacheManager.classRoomBankerPos = response.bankerPos;
                GetController<ClassicRoomCtrl>().Show(0);
                GetController<ShopBoxCtrl>().Show();
                BaseCanvas.PlayBGM(R.AudioClip.GAME_BGM);
                CacheManager.classicRoomState = 2;
                uiSelectClassic.Hide();
                break;
            case EnterBeginnerResponse.ERROR_金币不足:
                Debug.LogError("金币不够");
                break;
            case EnterBeginnerResponse.ERROR_金币过多:
                Debug.LogError("ERROR_金币过多");
                break;
            case EnterBeginnerResponse.ERROR_进入房间错误:
                Debug.LogError("进入房间错误");
                break;
            default:
                break;
        }
    }
}