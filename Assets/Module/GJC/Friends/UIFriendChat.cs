using Common;
using Config;
using FairyGUI;
using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIFriendChat : WTUIPage<UI_FriendChatCom, FriendCtrl>
{
    private List<FriendChatVO> infoList;//私人聊天消息
    public Action<int, string> sendInfo;//发送消息
    public Action<int> infoRead;//消息已读
    public UIFriendChat() : base(UIType.Dialog, UIMode.DoNothing, R.UI.COMMON)
    {
    }
    public override void Awake()
    {
        UIPage.m_list_info.itemRenderer = InfoItemRenderer;//消息列表
        UIPage.m_list_info.numItems = 0;
        UIPage.m_list_info.autoResizeItem = true;

        UIPage.m_list_friend.itemRenderer = FriendItemRenderer;//好友列表
        UIPage.m_list_info.numItems = 0;
        UIPage.m_list_friend.onClickItem.Add(FriendsOnClick);

        UIPage.m_btn_close.onClick.Add(Hide);//关闭
        UIPage.m_btn_send.onClick.Add(SendInfo);//发送
    }

    private void SendInfo(EventContext context)
    {
        string info = UIPage.m_txt_input.text;
        if (string.IsNullOrEmpty(info))
        {
            return;
        }
        int index = UIPage.m_list_friend.selectedIndex;
        if (index < 0)
        {
            return;
        }
        FriendsDataVO vo = CacheManager.dicFriendsList[index];


        UI_FrientListItem ui = (UI_FrientListItem)UIPage.m_list_friend.GetChildAt(index);
        if (ui.m_selectPoint.visible)
        {
            ui.m_selectPoint.visible = false;
            infoRead(vo.friendsData.id);
        }

        sendInfo(vo.friendsData.id, info);
    }


    public void RefreshSelectFriend(int select)
    {
        int count = CacheManager.dicFriendsList.Count;
        UIPage.m_list_friend.numItems = count;
        Debug.Log("选择=" + select);
        UIPage.m_list_friend.selectedIndex = select;
        FriendsOnClickItem();
    }


    /// <summary>
    /// 点击好友
    /// </summary>
    /// <param name="context"></param>
    private void FriendsOnClick(EventContext context)
    {
        UI_FrientListItem ui = (UI_FrientListItem)context.data;
        int userId = CacheManager.dicFriendsList[UIPage.m_list_friend.selectedIndex].friendsData.id;

        if (ui.m_selectPoint.visible)
        {
            ui.m_selectPoint.visible = false;
            infoRead(userId);
        }
        //刷新消息列表
        RefreshFriendInfo(userId);
    }

    /// <summary>
    /// 点击好友
    /// </summary>
    /// <param name="context"></param>
    private void FriendsOnClickItem()
    {
        UI_FrientListItem ui = (UI_FrientListItem)UIPage.m_list_friend.GetChildAt(UIPage.m_list_friend.selectedIndex);
        ui.m_selectPoint.visible = false;
        int userId = CacheManager.dicFriendsList[UIPage.m_list_friend.selectedIndex].friendsData.id;
        //刷新消息列表
        RefreshFriendInfo(userId);
        //SetReadInfo(userId);
    }


    /// <summary>
    /// 刷新消息列表
    /// </summary>
    private void RefreshFriendInfo(int userId)
    {
        int num = 0;
        if (CacheManager.dic_UserChatInfo != null)
        {
            CacheManager.dic_UserChatInfo.TryGetValue(userId, out infoList);
        }

        if (infoList != null)
        {
            num = infoList.Count;
        }
        UIPage.m_list_info.numItems = num;
        if (num > 0)
        {
            UIPage.m_list_info.scrollPane.ScrollToView(UIPage.m_list_info.GetChildAt(num - 1));
        }
    }

    /// <summary>
    /// 当前好友消息是否已读
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    private bool HaveNoRead(int userId)
    {
        if (CacheManager.dic_UserChatInfo == null)
        {
            return false;
        }
        List<FriendChatVO> info;
        CacheManager.dic_UserChatInfo.TryGetValue(userId, out info);
        if (info == null)
        {
            return false;
        }
        foreach (var item in info)
        {
            if (!item.read)
            {
                return true;
            }
        }
        return false;
    }


    public override void Refresh()
    {
        base.Refresh();

    }


    /// <summary>
    /// 消息列表
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    private void InfoItemRenderer(int index, GObject item)
    {
        UI_FriendChatInfo ui = (UI_FriendChatInfo)item;
        FriendChatVO vo = infoList[index];
        if (CacheManager.gameData.userId != vo.userId)
        {
            Left(vo, ui);
        }
        else
        {
            Right(vo, ui);
        }
    }


    private string ForMatChat(string chatStr)
    {
        int i = 15;
        while (i < chatStr.Length)
        {
            chatStr = chatStr.Insert(i, "\n");
            i += 15;
        }

        return chatStr;
    }
    /// <summary>
    /// 右
    /// </summary>
    /// <param name="vo"></param>
    /// <param name="ui"></param>
    private void Right(FriendChatVO vo, UI_FriendChatInfo ui)
    {
        ui.m_c1.selectedIndex = 1;
        ui.m_txt_right.text = ForMatChat(vo.info);
        //Debug.LogError(ForMatChat(vo.info));
        //ui.m_txt_right.text = "12345678921\ndfsfdsfsd";
        ui.m_n3.width = ui.m_txt_right.textWidth + 60;
        ui.m_n3.height = ui.m_txt_right.textHeight + 18;
        ui.height = ui.m_n3.height;
        if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
        {
            Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
           
            ui.m_right_icon.texture = new NTexture(t2d);
        }
        else
        {
            if (CacheManager.gameData.roleId == 0)
                ui.m_right_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
            else
                ui.m_right_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
        }
        if (CacheManager.gameData.vipLv > 0)
        {
            ui.m_right_vip.texture = new NTexture(FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP" + CacheManager.gameData.vipLv));
        }
        else
            ui.m_right_vip.texture = null;
    }

    /// <summary>
    /// 左
    /// </summary>
    /// <param name="vo"></param>
    /// <param name="ui"></param>
    private void Left(FriendChatVO vo, UI_FriendChatInfo ui)
    {
        ui.m_c1.selectedIndex = 0;
        ui.m_txt_left.text = ForMatChat(vo.info);
        ui.m_n2.width = ui.m_txt_left.textWidth + 60;
        ui.m_n2.height = ui.m_txt_left.textHeight + 18;
        ui.height = ui.m_n2.height;

        FriendsData friendsData = null;
        if (CacheManager.dicFriendsList != null && CacheManager.dicFriendsList.Count > 0)
        {
            foreach (FriendsDataVO item in CacheManager.dicFriendsList)
            {
                if (item.friendsData.id == vo.userId)
                {
                    friendsData = item.friendsData;
                    break;
                }
            }
        }
        if (friendsData != null)
        {
            if (friendsData.vipLv > 0)
            {
                ui.m_left_vip.texture = new NTexture(FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP" + friendsData.vipLv));
            }
            else
                ui.m_left_vip.texture = null;

            Sprite sprite;
            if (string.IsNullOrEmpty(friendsData.headIconUrl))
            {
                if (friendsData.roleId == 0)
                {
                    sprite = FileIO.LoadSprite(R.SpritePack.HEAD_MAN);
                }
                else
                {
                    sprite = FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN);
                }
            }
            else
            {
                //Texture2D texture2D = friendsData.headIconImg.DecodeTexture2d(100, 100);
                Texture2D texture2D = CacheManager.GetHeadIcon(friendsData.headIconUrl);
                sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
            }
            if (sprite != null)
                ui.m_left_icon.texture = new NTexture(sprite);

        }
        else
        {
            ui.m_left_vip = null;
            ui.m_left_icon.texture = null;
        }
    }

    /// <summary>
    /// 好友列表
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    private void FriendItemRenderer(int index, GObject item)
    {
        UI_FrientListItem ui = (UI_FrientListItem)item;
        FriendsDataVO vo = CacheManager.dicFriendsList[index];
        ui.m_c2.selectedIndex = vo.stateOnLine ? 0 : 1;//在线

        Sprite sprite = null;

        if (string.IsNullOrEmpty(vo.friendsData.headIconUrl))
        {
            if (vo.friendsData.roleId == 0)
            {
                sprite = FileIO.LoadSprite(R.SpritePack.HEAD_MAN);
            }
            else
            {
                sprite = FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN);
            }
        }
        else
        {
            //Texture2D texture2D = vo.friendsData.headIconImg.DecodeTexture2d(100, 100);
            Texture2D texture2D = CacheManager.GetHeadIcon(vo.friendsData.headIconUrl);
            sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
        }

        if (sprite != null)
        {
            ui.m_icon.texture = new NTexture(sprite.texture);//头像  vo.friendsData.icon
        }

        ui.m_txt_lv.text = "LV." + vo.friendsData.lv;
        //todo 等级分vip/lv
        if (vo.friendsData.vipLv > 0)
        {
            Sprite vipSprite = FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP" + vo.friendsData.vipLv);//等级头像
            ui.m_lv_icon.texture = new NTexture(vipSprite.texture);//等级图标
        }
        else
        {
            ui.m_lv_icon.texture = null;
        }
        ui.m_txt_nike.text = vo.friendsData.nickName;//昵称
        ui.m_txt_ID.text = vo.friendsData.id.ToString();//ID

        int userId = vo.friendsData.id;
        ui.m_selectPoint.visible = HaveNoRead(userId);
    }


    public void RefreshList(int friendId)
    {
        int select = UIPage.m_list_friend.selectedIndex;
        int selectUserId = CacheManager.dicFriendsList[UIPage.m_list_friend.selectedIndex].friendsData.id;
        if (selectUserId == friendId)
        {
            UI_FrientListItem ui = (UI_FrientListItem)UIPage.m_list_friend.GetChildAt(select);
            ui.m_selectPoint.visible = true;
            RefreshFriendInfo(friendId);
        }
        else
        {
            int index = 0;
            foreach (var item in CacheManager.dicFriendsList)
            {
                if (item.friendsData.id == friendId)
                {
                    break;
                }
                index++;
            }
            UI_FrientListItem ui = (UI_FrientListItem)UIPage.m_list_friend.GetChildAt(index);
            Debug.LogError("point:" + ui.m_selectPoint.visible);
            ui.m_selectPoint.visible = true;
        }
    }

    /// <summary>
    /// 刷新好友在线状态
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="state"></param>
    public void RefreshFriendState(int userId, bool state)
    {
        if (CacheManager.dicFriendsList == null)
        {
            return;
        }
        int index = 0;
        foreach (var item in CacheManager.dicFriendsList)
        {
            if (item.friendsData.id == userId)
            {
                break;
            }
            index++;
        }
        UI_FrientListItem ui = (UI_FrientListItem)UIPage.m_list_friend.GetChildAt(index);
        ui.m_c2.selectedIndex = state ? 0 : 1;//在线
    }


    public void ResInputText()
    {
        UIPage.m_txt_input.text = "";
    }
}
