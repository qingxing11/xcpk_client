using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBankerListCtrl : BaseController, IHandlerReceive
{
    private UIUpBankerList uiUpBankerList;
    public override void InitAction()
    {
        uiUpBankerList = GetUIPage<UIUpBankerList>();
        uiUpBankerList.ActionUpBank = SendUpBankRequest;
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.KillRoom_通杀场上庄:
                    ReceiveUpBanker(response.data);
                    break;
                case MsgType.KillRoom_通杀场下庄:
                    ReciveResignKillRoomBanker(response.data);
                    break;
                case MsgType.KillRoom_自己下庄:
                    GetController<RoomCtrl>().RefUpBankerBtn();
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    public void Show()
    {
        ShowUI<UIUpBankerList>();
        uiUpBankerList.Init();
    }

    #region Request
    private void SendUpBankRequest()
    {
        if (!BaseCanvas.GetController<RoomCtrl>().InUpBankerList() && (!GetController<RoomCtrl>().IsBanker()))      //申请上庄
        {
            ApplicationKillRoomBankerRequest request = new ApplicationKillRoomBankerRequest();
            SendMessage(request);
        }
        else                             //申请下庄
        {
            ResignKillRoomBankerRequest request = new ResignKillRoomBankerRequest();
            SendMessage(request);
        }
    }
    #endregion
    /// <summary>
    /// 申请上庄
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveUpBanker(byte[] data)
    {
        ApplicationKillRoomBankerResponse response=MySerializerUtil.DeSerializerFromProtobufNet<ApplicationKillRoomBankerResponse>(data);
        switch (response.code)
        {
            case ApplicationKillRoomBankerResponse.SUCCESS:
                CacheManager.List_bankerList = response.list_bankerList;
                GetController<RoomCtrl>().RefUpBankerBtn();
                uiUpBankerList.Init();
                GetController<MessageCtrl>().Show("申请上庄成功");
               
                break;
            case ApplicationKillRoomBankerResponse.ERROR_金币不足:
                Debug.LogError("金币不足");
                break;
            case ApplicationKillRoomBankerResponse.ERROR_上庄人数太多:
                Debug.LogError("上装人数太多");
                break;
            case ApplicationKillRoomBankerResponse.ERROR_申请上庄时已是庄家:
                Debug.LogError("ERROR_申请上庄时已是庄家");
                break;
            case ApplicationKillRoomBankerResponse.ERROR_申请上庄时人数太多:
                Debug.LogError("申请上庄时人数太多");
                break;
            case ApplicationKillRoomBankerResponse.ERROR_申请上庄时已在列表:
                Debug.LogError("申请上庄时已在列表");
                break;
            default:
                Debug.LogError("申请上庄发生未知错误");
                break;
        }
    }
    /// <summary>
    /// 申请下庄
    /// </summary>
    /// <param name="data"></param>
    private void ReciveResignKillRoomBanker(byte[] data)
    {
        ResignKillRoomBankerResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ResignKillRoomBankerResponse>(data);
        switch (response.code)
        {
            case ResignKillRoomBankerResponse.SUCCESS:
                if (CacheManager.List_bankerList != null)
                {
                    for (int i = 0; i < CacheManager.List_bankerList.Count; i++)
                    {
                        PlayerSimpleData playerSimpleData = CacheManager.List_bankerList[i];
                        CacheManager.List_bankerList.RemoveAt(i);
                        break;
                    }
                }

                if (BaseCanvas.GetController<RoomCtrl>().IsBanker())
                {
                    GetController<MessageCtrl>().Show("申请下桌成功，等待本局结束下桌");
                }
               
                GetController<RoomCtrl>().RefUpBankerBtn();
                uiUpBankerList.Init();
                break;
            case ResignKillRoomBankerResponse.ERROR_不是庄家:
                Debug.LogError("您不是庄家无法申请下庄");
                break;
            default:
                Debug.LogError("申请下庄失败，错误代码：" + response.code);
                break;
        }
    }

    public void Init()
    {
        if(uiUpBankerList!=null&& uiUpBankerList.isActive())
            uiUpBankerList.Init();
    }

    public void Hide()
    {
        if (uiUpBankerList != null && uiUpBankerList.isActive())
        {
            uiUpBankerList.Hide();
        }
    }
}
