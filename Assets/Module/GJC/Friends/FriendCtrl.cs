using Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class FriendCtrl : BaseController,IHandlerReceive
{
    private UIFriend uiFriend;
    private UIAddFriendCom uiAddFriendCom;
    private UIFriendChat uiFriendChat;
    
    public override void InitAction()
    {
        uiFriend = GetUIPage<UIFriend>();
        uiFriend.lookFriend = LookFriend;
        uiFriend.addFriend = AddFriend;
        uiFriend.agree = SendSure;
        uiFriend.refush = SendRefuse;
        uiFriend.infoRead = InfoRead;
        uiFriend.addInfoRead = AddInfoRead;
        uiFriend.deleteInfo = DeleteInfo;
        uiFriend.close = Close;
        uiFriend.deleteFriend = DeleteFriend;
        uiFriend.refreshIcon = RefrashIcon;
        uiFriend.btnChatCom = BtnChatCom;

        uiAddFriendCom = GetUIPage<UIAddFriendCom>();

        uiFriendChat = GetUIPage<UIFriendChat>();
        uiFriendChat.sendInfo = SendInfo;
        uiFriendChat.infoRead = InfoRead;
    }

    private void SendInfo(int friendId, string info)
    {
        Debug.Log("向"+ friendId+"发送消息："+ info);
        FriendChatRequest request = new FriendChatRequest(CacheManager.gameData.userId,friendId, info);
        SendMessage(request);
    }

    /// <summary>
    /// 打开聊天界面
    /// </summary>
    /// <param name="index"></param>
    private void BtnChatCom(int index)
    {
        ShowUI<UIFriendChat>();
        uiFriendChat.RefreshSelectFriend(index);
    }

    private void DeleteFriend(int otherId)
    {
        DeleteFriendRequest request = new DeleteFriendRequest(otherId);
        SendMessage(request);
    }

    private void Close()
    {
        GetController<MainSceneCtrl>().ShowIcon(CacheManager.ShowIcon());
    }

    public void RefrashIcon()
    {
        bool info = CacheManager.ShowIcon();
        if (uiFriend.isActive())
        {
            uiFriend.RefrashIcon(info);
        }
        GetController<MainSceneCtrl>().RefreshRedPonit(info);
        GetController<TenThousandRoomCtrl>().RefreshRedPonit(info);
        GetController<FruitMechineCtrl>().RefreshRedPonit(info);
    }




    private void DeleteInfo(int userId)
    {
        DeleteInfoRequest request = new DeleteInfoRequest(userId);
        SendMessage(request);
        Debug.Log("发送已阅读：" + request);
       
    }

    private void AddInfoRead(int userId)
    {
        ReadAddInfoRequest request = new ReadAddInfoRequest(userId);
        SendMessage(request);
    }

    private void InfoRead(int userId)
    {
        ReadInfoRequest request = new ReadInfoRequest(userId);
        SendMessage(request);
        Debug.Log("发送已阅读：" + request);
        CacheManager.SetInfoState(userId,EnumReadInfoState.已读);
        //RefrashInfoList();
    }

    //拒绝
    private void SendRefuse(int userId)
    {
        AddFriendAgreeRequest request = new AddFriendAgreeRequest(userId,false);
        SendMessage(request);
        //AddInfoRead(userId);
    }

    //同意
    private void SendSure(int userId)
    {
        AddFriendAgreeRequest request = new AddFriendAgreeRequest(userId, true);
        SendMessage(request);
        //AddInfoRead(userId);
    }

    private void AddFriend(string txt)
    {
        Debug.Log("添加好友：" + txt);
        int userId = int.Parse(txt.Split(':')[1]);
        AddFriendsRequest request = new AddFriendsRequest(userId);
        SendMessage(request);
    }

    private void LookFriend(int userId)
    {
        Debug.Log("查找好友："+ userId);
        LookFriendsRequest request = new LookFriendsRequest(userId);
        SendMessage(request);
    }

    public void ShowUIFriend()
    {
        ShowUI<UIFriend>();
        SendAskFriend();
        RefrashIcon();
    }

    private void SendAskFriend()
    {
        AskFriendsRequest request = new AskFriendsRequest();
        SendMessage(request);
    }

    /// <summary>
    /// 刷新消息通知列表
    /// </summary>
    public void RefrashInfoList()
    {
        if (uiFriend.isActive())
        {
            uiFriend.RefrashInfoList();
            RefrashIcon();
        }
    }

    /// <summary>
    /// 刷新好友列表
    /// </summary>
    public void RefrashFriendsList()
    {
        if (uiFriend.isActive())
        {
            uiFriend.RefrushFriendsList();
            //uiFriend.RefrashfriendsIcon(true);
        }
    }

    public Response RunServerReceive(Response response)
    {
        if (response!=null)
        {
            switch (response.msgType)
            {
                case MsgType.ASKFRIENDS:
                    AskfriendsMessage(response.data);
                    break;
                case MsgType.Look_查找好友:
                    LookfriendsMessage(response.data);
                    break;
                case MsgType.ADDFRIENDS:
                    AddFriendsMessage(response.data);
                    break;
                case MsgType.Agree_同意添加好友:
                    AgreeFriendsMessage(response.data);
                    break;
                case MsgType.Delete_删除消息:
                    DeleteInfoMessage(response.data);
                    break;
                case MsgType.Delete_删除好友:
                    DeleteFriendMessage(response.data);
                    break;
                case MsgType.ChatInfo_好友聊天消息:
                    PushFriendChatMessage(response.data);
                    break;
                case MsgType.ChatInfo_好友聊天状态:
                    FriendChatInfoMessage(response.data);
                    break;
                case MsgType.ChatInfo_好友聊天:
                    FriendChatMessage(response.data);
                    break;
                case MsgType.Push_好友玩家状态:
                    PushPlayerOnLineMessage(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    /// <summary>
    /// 玩家上线，或离线
    /// </summary>
    /// <param name="data"></param>
    private void PushPlayerOnLineMessage(byte[] data)
    {
        PushPlayerOnLineResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushPlayerOnLineResponse>(data);
        switch (response.code)
        {
            case PushPlayerOnLineResponse.SUCCESS:
                int userId = response.userId;
                bool state = response.state;
                CacheManager.FriendStateChange(userId, state);
                if (uiFriend.isActive())
                {
                    uiFriend.RefreshFriendState(userId, state);
                }
                if (uiFriendChat.isActive())
                {
                    uiFriendChat.RefreshFriendState(userId, state);
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 好友聊天消息
    /// </summary>
    /// <param name="data"></param>
    private void FriendChatMessage(byte[] data)
    {
        FriendChatResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FriendChatResponse>(data);
        switch (response.code)
        {
            case FriendChatResponse.SUCCESS:
                if(response.vo.userId!=CacheManager.gameData.userId)
                    GetController<MainSceneCtrl>().RefreshRedPonit(true);
                Debug.Log(response.ToString());
                FriendChatVO vo = response.vo;
                if (vo==null)
                {
                    return;
                }
                CacheManager.AddFriendChatInfo(vo);

                //刷新列表
                if (uiFriendChat.isActive())
                {
                    int friendKey = vo.userId;
                    if (vo.userId == CacheManager.gameData.userId)
                    {
                        friendKey = vo.receiveUserId;
                    }
                    uiFriendChat.RefreshList(friendKey);

                    if (vo.userId == CacheManager.gameData.userId)
                    {
                        uiFriendChat.ResInputText();
                    }

                }

                
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 好友聊天状态
    /// </summary>
    /// <param name="data"></param>
    private void FriendChatInfoMessage(byte[] data)
    {
        FriendChatInfoResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FriendChatInfoResponse>(data);
        switch (response.code)
        {
            case FriendChatInfoResponse.SUCCESS:
                int friendId = response.friendId;
                SetReadInfo(friendId);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 刷新消息已读
    /// </summary>
    /// <param name="userId"></param>
    private void SetReadInfo(int userId)
    {
        if (CacheManager.dic_UserChatInfo == null)
        {
            return;
        }
        List<FriendChatVO> info;
        CacheManager.dic_UserChatInfo.TryGetValue(userId, out info);
        foreach (var item in info)
        {
            if (!item.read)
            {
                item.read = true;
            }
        }
    }
        /// <summary>
        /// 推送好友聊天消息
        /// </summary>
        /// <param name="data"></param>
    private void PushFriendChatMessage(byte[] data)
    {
        PushFriendChatInfoResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushFriendChatInfoResponse>(data);
        switch (response.code)
        {
            case PushFriendChatInfoResponse.SUCCESS:
                List<FriendChatVO> list = response.list;
                if (list==null)
                {
                    return;
                }
                CacheManager.AddFriendChatInfo(list);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 删除好友
    /// </summary>
    /// <param name="data"></param>
    private void DeleteFriendMessage(byte[] data)
    {
        DeleteFriendResponse response = MySerializerUtil.DeSerializerFromProtobufNet<DeleteFriendResponse>(data);
        switch (response.code)
        {
            case DeleteFriendResponse.SUCCESS:
                CacheManager.RemoveFriendsList(response.userId);
                RefrashFriendsList();
                if (CacheManager.gameData.userId==response.askUserId)
                {
                    GetController<TxtCtrl>().Show("删除好友成功！");
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 删除消息
    /// </summary>
    /// <param name="data"></param>
    private void DeleteInfoMessage(byte[] data)
    {
        DeleteInfoResponse response = MySerializerUtil.DeSerializerFromProtobufNet<DeleteInfoResponse>(data);
        switch (response.code)
        {
            case DeleteInfoResponse.SUCCESS:
                CacheManager.RemoveFriendsInfo(response.userId);
                RefrashInfoList();
                //RefrashIcon();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 请求好友列表
    /// </summary>
    /// <param name="data"></param>
    private void AskfriendsMessage(byte[] data)
    {
        AskFriendsResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AskFriendsResponse>(data);
        switch (response.code)
        {
            case AskFriendsResponse.SUCCESS:
                List<FriendsDataVO> list = response.friends_list;
                if (list == null || list.Count == 0)
                {
                    return;
                }
                foreach (FriendsDataVO vo in list)
                {
                    CacheManager.AddFriendsList(vo);
                }
                RefrashFriendsList();
                break;
            default:
                //Debug.LogError(" 请求好友列表");
                break;
        }
    }

   
    /// <summary>
    /// 同意/拒绝 添加好友
    /// </summary>
    /// <param name="data"></param>
    private void AgreeFriendsMessage(byte[] data)
    {
        AddFriendAgreeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AddFriendAgreeResponse>(data);
        switch (response.code)
        {
            case AddFriendAgreeResponse.SUCCESS:
                FriendsDataVO vo = response.vo;
                ShowInfo(response.info.info);
                CacheManager.RemoveAddFriendEvent(response.info.userId);
                if (vo!=null)
                {
                    CacheManager.AddFriendsList(vo);
                    RefrashFriendsList();
                }
                RefrashInfoList();
                break;
            default:
                //Debug.LogError(" 同意/拒绝 添加好友");
                break;
        }
    }


    public void ShowInfo(string info)
    {
        uiFriend.ShowInfo(info);
    }
    /// <summary>
    /// 添加好友
    /// </summary>
    /// <param name="data"></param>
    private void AddFriendsMessage(byte[] data)
    {
        AddFriendsResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AddFriendsResponse>(data);
        switch (response.code)
        {
            case AddFriendsResponse.SUCCESS:
                AddFriendsVO vo = response.vo;
                if (vo.id!=CacheManager.gameData.userId)
                {
                    CacheManager.AddFriendEvent(vo);
                    RefrashInfoList();
                    RefrashIcon();
                    //GetController<TxtCtrl>().Show("等待对方同意！");
                }
                else
                {
                    GetController<TxtCtrl>().Show("等待对方同意！");
                }
                break;
            case AddFriendsResponse.Error_已经添加好友:
                GetController<TxtCtrl>().Show("已添加好友！");
                break;
            case AddFriendsResponse.Error_重复请求添加:
                GetController<TxtCtrl>().Show("重复添加好友！");
                break;
            case AddFriendsResponse.Error_超过好友上限:
                GetController<TxtCtrl>().Show("超过好友上限,不可以添加！");
                Debug.LogError("AddFriendsResponse.Error_超过好友上限,不可以添加！");
                break;
            default:
                GetController<TxtCtrl>().Show("未知错误！");
                Debug.LogError(" 添加好友错误");
                break;
        }
    }

    /// <summary>
    /// 查找好友
    /// </summary>
    /// <param name="data"></param>
    public void LookfriendsMessage(byte[] data)
    {
        LookFriendsResponse response = MySerializerUtil.DeSerializerFromProtobufNet<LookFriendsResponse>(data);
        switch (response.code)
        {
            case LookFriendsResponse.SUCCESS:
                uiFriend.ShowFriendCom(response.vo);
                break;
            case LookFriendsResponse.ERROR_查无此人:
                uiFriend.CloseFriendCom();
                break;
            default:
                Debug.LogError("查找好友错误");
                break;
        }
    }
}
