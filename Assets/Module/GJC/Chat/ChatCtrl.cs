using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;

public class ChatCtrl : BaseController, IHandlerReceive
{
    private bool uiMain = false;
    private float timeScale = 1.5f;
    /// <summary>
    ///  1:通杀场  2:万人场 3:经典场
    /// </summary>
    private int curRoom;
    private UIChat uiChat;
    private UIChat2 uiChat2;
    private UIChat3 uiChat3;
    private UIClassChat uiClassChat;
    private UIRoomChat uiRoomChat;
    private List<UICreatWord> list = new List<UICreatWord>();
    public override void InitAction()
    {
        //uiChat = GetUIPage<UIChat>();
        //uiChat.btnSend = BtnSend;
        //uiChat.btnShortCut = BtnShortCut;
        //uiChat.playInfo = PlayInfo;
        //popUp = CacheManager.Bullte;

        uiChat2 = GetUIPage<UIChat2>();
        uiChat2.btnSend = BtnSend;
        uiChat2.btnShortCut = BtnShortCut;
        uiChat2.playInfo = PlayInfo;
        uiChat2.btnSend2 = BtnSend2;
        uiChat2.btnSend3 = BtnSend3;
        uiChat2.hide = UIChat2Hide;

        //uiChat3 = GetUIPage<UIChat3>();
        //uiChat3.btnSend = BtnSend;
        //uiChat3.btnShortCut = BtnShortCut;
        //uiChat3.playInfo = PlayInfo;

        uiClassChat = GetUIPage<UIClassChat>();
        uiRoomChat = GetUIPage<UIRoomChat>();
        curRoom = -1;
    }
    //
    //万人场 水果机 通杀场 经典场 设置为flase
    //主场景甚至为true
    public void setHideUIMain(bool show)
    {
        this.uiMain = show;
    }



    public void ShowUIRoomChat()
    {
        ShowUI<UIRoomChat>();
    }

    public void HideUIRoomChat()
    {
        if (uiRoomChat != null && uiRoomChat.isActive())
        {
            uiRoomChat.Hide();
        }
    }


    private void UIChat2Hide()
    {

    }

    public void ResRoom()
    {
        curRoom = -1;
    }

    /// <summary>
    /// 设置当前所在房间
    /// </summary>
    /// <param name="room">4:水果机 3:经典场 2:万人场 1:通杀场</param>
    public void SetRoom(int room)
    {
        if (curRoom != room)
        {
            curRoom = room;
            ClearChatInfo();
        }
        //Debug.Log("当前房间号：" + curRoom + ",4:水果机 3:经典场 2:万人场 1:通杀场");
    }

    /// <summary>
    /// 清空缓存消息
    /// </summary>
    private void ClearChatInfo()
    {
        CacheManager.ClearChat();
    }


    public void ShowUIClassChat()
    {
        ShowUI<UIClassChat>();
    }
    /// <summary>
    /// 经典场界面隐藏
    /// </summary>
    public void HideUIClassCom()
    {
        uiClassChat.Hide();
        ResRoom();
    }

    /// <summary>
    /// 通杀场界面隐藏
    /// </summary>
    public void HideUIRoom()
    {
        ResRoom();
    }

    /// <summary>
    /// 万人场界面隐藏
    /// </summary>
    public void HideUITenCom()
    {
        ResRoom();
    }

    /// <summary>
    /// 聊天界面2
    /// </summary>
    /// <param name="room">4:水果机 3:经典场 2:万人场 1:通杀场</param>
    public void ShowUIChat2(int room)
    {
        Debug.Log("传入房间号：" + room + ",4:水果机 3:经典场 2:万人场 1:通杀场");
        ShowUI<UIChat2>();
        uiChat2.InitRoom(room);

        if (curRoom != room)
        {
            curRoom = room;
            ClearChatInfo();
        }
        Debug.Log("当前房间号：" + curRoom + ",4:水果机 3:经典场 2:万人场 1:通杀场");
    }



    /// <summary>
    /// 打开玩家信息简介面板
    /// </summary>
    /// <param name="userId"></param>
    private void PlayInfo(int userId)
    {
        GetController<UserInfoCtrl>().PlayInfo(userId);
    }



    //public void ShowUIChat()
    //{
    //    ShowUI<UIChat>();

    //    if (curRoom != 0)
    //    {
    //        curRoom = 0;
    //        ClearChatInfo();
    //    }
    //}


    public void CreatTxt(string info, string nikeName, int vipLv, int userId)
    {
        string key = userId + ":" + MyTimeUtil.GetCurrTimeMM % 1000;
        UICreatWord ui = WTUIPage.ShowPage<UICreatWord>(key);
        ui.over = Over;
        ui.ShowTxt(info, nikeName, vipLv);
        ui.SetPosition(ui.Position.x, MyUtil.GetRandom(80, 300));
        ui.PlayEffect(key, timeScale);
        list.Add(ui);

    }


    public void Remove(UICreatWord ui)
    {
        if (list != null)
        {
            list.Remove(ui);
        }
    }
    private void Over(UICreatWord ui)
    {
        Remove(ui);
        WTUIPage.ClosePage(ui);
    }

    private void BtnShortCut(int infoIndex)
    {
        //Debug.Log("快捷消息："+info);
        AskShortCutRequest request = new AskShortCutRequest(infoIndex);
        SendMessage(request);
        Debug.Log(request);
    }

    private void BtnSend(string info, int curRoom)
    {
        Debug.Log("聊天消息：" + info + ",信息长度：" + info.Length);
        AskFenestraeChatRequest request = new AskFenestraeChatRequest(info, curRoom);
        SendMessage(request);
        //Debug.Log(request);
    }

    private void BtnSend2(string info, bool emjoy, int curRoom)
    {
        //Debug.Log("聊天消息：" + info+",信息长度："+info.Length);
        AskFenestraeChatRequest request = new AskFenestraeChatRequest(info, emjoy, curRoom);
        SendMessage(request);
        Debug.Log(request);
    }
    private void BtnSend3(string info, bool shutCut, int index, int curRoom)
    {
        //Debug.Log("聊天消息：" + info+",信息长度："+info.Length);
        AskFenestraeChatRequest request = new AskFenestraeChatRequest(info, shutCut, index, curRoom,CacheManager.RunRoomId);
        SendMessage(request);
        Debug.Log(request);
    }
    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.Chat_快捷回复:
                    ShortCutResponseInfo(response.data);
                    break;
                case MsgType.Chat_小窗聊天:
                    FenestraeChatResponseInfo(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void ShowChat()
    {
        if (uiChat.isActive())
        {
            uiChat.ShowChat();
        }
    }

    private void FenestraeChatResponseInfo(byte[] data)
    {
        AskFenestraeChatResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AskFenestraeChatResponse>(data);
        Debug.Log("response:"+ response);
        switch (response.code)
        {
            case AskFenestraeChatResponse.SUCCESS:

                SmallChatVO smallChatVO = new SmallChatVO(response);

                CacheManager.AddSmallChat(smallChatVO, response.curRoom);
                TxtOrPos(smallChatVO, response.enjoy, response.curRoom);

                RefreshChat2();

                if (response.shutCut)
                {
                    PlayAudioClip(response.shutCutIndex);
                }
                break;
            case AskFenestraeChatResponse.Error_暂无聊天功能:
                GetController<TxtCtrl>().Show("暂无聊天功能！vip客户拥有");
                break;
            case AskFenestraeChatResponse.Error_频繁发送:
                GetController<TxtCtrl>().Show("发送消息太频繁！");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="index"></param>
    private void PlayAudioClip(int index)
    {
        string realPath = ConfigManager.Configs.DataShortCut2[index].Path;
        int realAudioIndex = 0;

        foreach (string path in R.AudioClip.path)
        {
            if (path.Equals(realPath))
            {
                break;
            }
            else
            {
                realAudioIndex++;
            }
        }
        BaseCanvas.PlaySound(realAudioIndex);
    }

    private void ShowChat3()
    {
        if (uiChat3.isActive())
        {
            uiChat3.ShowChat();
        }
    }


    private void TxtOrPos(SmallChatVO smallChatVO, bool enjoy,int  curRoom)
    {
        Debug.Log("聊天房间,curRoom：" + curRoom+ ",uiMain:"+ uiMain+ ",CacheManager.Bullte:"+ CacheManager.Bullte+ ",CacheManager.KillRoomTV:"+ CacheManager.KillRoomTV);
        if (uiMain)
        {
            return;
        }
      
        if (curRoom == 3)
        {
            if (uiClassChat.isActive())
            {
                if (enjoy)
                {
                    uiClassChat.ShowEnjoy(smallChatVO);
                }
                else
                {
                    uiClassChat.ShowTxt(smallChatVO);
                }
            }

        }
        //万人场聊天
        else if (curRoom == 2)
        {
            bool pop3 = IsTenRoom(smallChatVO.UserId);
            if (pop3)
            {
                if (uiClassChat.isActive())
                {
                    if (enjoy)
                    {
                        uiClassChat.ShowTenEnjoy(smallChatVO);
                    }
                    else
                    {
                        uiClassChat.ShowTenTxt(smallChatVO);
                    }
                }
                return;
            }
            if(smallChatVO.roomType==5)//万人场
                CreatTxt(smallChatVO.Info, smallChatVO.NikeName, smallChatVO.VipLv, smallChatVO.UserId);
        }
        //通杀场
        else if (curRoom == 1)
        {
            Debug.Log("收到聊天消息时通杀场情况，uiRoomChat.isActive()：" + uiRoomChat.isActive());
            if (uiRoomChat.isActive() && CacheManager.KillRoomTV == 0)
            {
                if (enjoy)
                {
                    uiRoomChat.ShowEnjoy(smallChatVO);
                }
                else
                {
                    uiRoomChat.ShowTxt(smallChatVO);
                }

                if (CacheManager.Bullte)
                {
                    Debug.Log("通杀弹幕...");
                    //if()
                    //通杀场
                    CreatTxt(smallChatVO.Info, smallChatVO.NikeName, smallChatVO.VipLv, smallChatVO.UserId);
                }
            }

            //bool pop2 = IsRoom(smallChatVO.UserId);
            //if (pop2)
            //{
               
            //    return;
            //}
          
           
        }
        else if (curRoom == 4)
        {
            Debug.Log("水果机聊天 弹幕开关 popUp=" + CacheManager.Bullte);
            if (smallChatVO.roomType == 6)//水果机
                CreatTxt(smallChatVO.Info, smallChatVO.NikeName, smallChatVO.VipLv, smallChatVO.UserId);
        }
    }

    private bool IsRoom(int userId)
    {
        if (CacheManager.TablePlayers == null)
        {
            return false;
        }
        foreach (var item in CacheManager.TablePlayers)
        {
            if (item != null&&item.userId == userId)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 是否是万人场座位玩家
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    private bool IsTenRoom(int userId)
    {
        if (CacheManager.TablePlayers == null)
        {
            return false;
        }
        int index = 0;
        foreach (var item in CacheManager.ManyPeopleRoomPlayers)
        {
            index++;
            if (item == null)
            {
                Debug.Log("万人场场座位" + (index - 1) + "为空");
                continue;
            }
            if (item.userId == userId)
            {
                return true;
            }
        }
        return false;
    }


    private void RefreshChat2()
    {
        //Debug.Log("uiChat2.isActive()"+ uiChat2.isActive());
        if (uiChat2.isActive())
        {
            uiChat2.ShowChat();
        }
    }

    private void ShortCutResponseInfo(byte[] data)
    {
        AskShortCutResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AskShortCutResponse>(data);
        switch (response.code)
        {
            case AskShortCutResponse.SUCCESS:
                Debug.Log("收到快捷回复:" + response);
                if (CacheManager.Bullte)
                {
                    Debug.LogError("收到快捷回复");
                    CreatTxt(response.info, response.nikeName, response.vipLv, response.userId);
                }
                break;
            case AskShortCutResponse.Error_暂无聊天功能:
                GetController<TxtCtrl>().Show("暂无聊天功能！vip客户拥有");
                break;
            default:
                break;
        }
    }

    public void CloseChat()
    {
        if (list != null)
        {
            while (list.Count>0)
            {
                Over(list[0]);
            }
        }
    }
}
