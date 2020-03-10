using Common;
using Config;
using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;

public class UIFriend : WTUIPage<UI_Friend, FriendCtrl>
{
    private string ID;//查找好友ID
    public Action<int> lookFriend;
    public Action<string> addFriend;
    public Action<int> refush;//拒绝
    public Action<int> agree;//同意
    public Action<int> infoRead;//消息已读
    public Action<int> addInfoRead;//添加消息已读
    public Action<int> deleteInfo;//删除系统消息
    public Action<int> deleteFriend;//删除好友
    public Action close;
    public Action refreshIcon;//刷新Icon
    public Action<int> btnChatCom;//打开聊天界面

    public EventCallback1 eventCallback;

    public EventCallback1 btnChat;

    private int onClickNum=0;//点击次数
    private UI_FriendCom2 curUI;
    public UIFriend() : base(UIType.Dialog, UIMode.DoNothing, R.UI.COMMON)
    {
    }
    public override void Awake()
    {
        UIPage.m_list_info.itemRenderer = InfoItemRenderer;
        UIPage.m_list_info.numItems = 0;
        UIPage.m_list_info.onClickItem.Add(ItemInfoOnClick);
        UIPage.m_btn_info.onClick.Add(Info);
        //UIPage.m_list_info.onClickItem.Add();

        UIPage.m_btn_addfriend2.onClick.Add(AddfriendTwo);

        UIPage.m_list_friend.itemRenderer = FriendItemRenderer;
        UIPage.m_list_friend.onClickItem.Add(FriendsOnClick);
        UIPage.m_friendcom.m_btn_addFriend.onClick.Add(SendAddFriend);

        UIPage.m_btn_friend.onClick.Add(Frined);
        UIPage.m_btn_look.onClick.Add(Look);
        UIPage.m_btn_addFriend.onClick.Add(AddFriend);
        UIPage.m_btn_close.onClick.Add(()=> {
            Hide();
            close();
            });
        UIPage.m_btn_hide.onClick.Add(() => {
            Hide();
            close();
        });

        UIPage.m_infoIcon.visible = false;
        UIPage.m_friendsIcon.visible = false;
        //UIPage.m_addFriendsIcon.visible = false;
        eventCallback = DeleteFriend;
        btnChat = BtnChat;

    }

    /// <summary>
    /// 聊天
    /// </summary>
    /// <param name="context"></param>
    private void BtnChat(EventContext context)
    {
        GButton gButton =(GButton) context.sender;
        int index = UIPage.m_list_friend.GetChildIndex(gButton.parent);
        btnChatCom(index);
    }

    private void FriendsOnClick(EventContext context)
    {
        UI_FriendCom2 ui =(UI_FriendCom2)context.data;

        if (curUI!=ui)
        {
            if (curUI!=null)
            {
                curUI.m_btn_chat.visible = false;
                curUI.m_btn_delete.visible = false;
            }
            onClickNum = 0;
            curUI = ui;
        }
        else
        {
            onClickNum++;
        }
        if (onClickNum%2==0)
        {
            ui.m_btn_chat.visible = true;
            ui.m_btn_delete.visible = false;
        }
        else
        {
            ui.m_btn_chat.visible = false;
            ui.m_btn_delete.visible = true;
        }
       
        refreshIcon();
    }

    private void DeleteFriend(EventContext context)
    {
        if(context==null)
            Debug.LogError("DeleteFriend context is null");
        else
            Debug.LogError("DeleteFriend context is not null");

        GButton btn = (GButton)context.sender;

        //UI_btn_removeFriend btn= (UI_btn_removeFriend)context.sender;
        int index = UIPage.m_list_friend.GetChildIndex(btn.parent);

        if (index<0)
        {
            Debug.LogError("DeleteFriend index="+index);
            return;
        }
        FriendsDataVO vo = CacheManager.dicFriendsList[index];
        if (vo!=null)
        {
            deleteFriend(vo.friendsData.id);
        }
    }

    public void RefrashIcon(bool info)
    {
        UIPage.m_infoIcon.visible = info;
        //UIPage.m_friendsIcon.visible = friends;
        //UIPage.m_addFriendsIcon.visible = addFriends;
    }

    public void RefrashfriendsIcon(bool friends)
    {
        UIPage.m_friendsIcon.visible = friends;
    }


    private void ItemInfoOnClick(EventContext context)
    {
        Debug.Log("点击");
        UI_titleCom ui = (UI_titleCom)context.data;
        
        if (ui.m_c1.selectedIndex==0)
        {
            int index = UIPage.m_list_info.GetChildIndex(ui);
            //Debug.Log("////////index:" + index);
            int num = index - CacheManager.dicAddFriends.Count;
            if (num<0)
            {
                Debug.LogError("ItemInfoOnClick出错"+num);
                return;
            }

            //Debug.Log("////////index:" + num+ ",CacheManager.dicFriendsInfo="+ CacheManager.dicFriendsInfo.Count + ", CacheManager.dicFriendsInfo[num]="+ CacheManager.dicFriendsInfo[num]);
            int userId = CacheManager.dicFriendsInfo[num].userId;
            if (CacheManager.dicFriendsInfo[num].read == EnumReadInfoState.未读)
            {
                infoRead(userId);
                ui.m_btn_delete.visible = false;
            }
            else
            {
                ui.m_btn_delete.visible = !(ui.m_btn_delete.visible);
            }
            //bool state = ui.m_btn_delete.visible;
            //Debug.Log("state:="+state);
            //Debug.Log("userId:"+ userId+ " ui.m_btn_delete.visible=" + ui.m_btn_delete.visible);
            ui.m_btn_delete.onClick.Add(()=> deleteInfo(userId));
        }

        refreshIcon();
    }

    public override void Refresh()
    {
        base.Refresh();
        ID = "";
        UIPage.m_info.visible = false;
    }
    private void InfoItemRenderer(int index, GObject item)
    {
        UI_titleCom ui=(UI_titleCom)item;
       
        if (index<CacheManager.dicAddFriends.Count)//添加好友
        {
            ui.m_c1.selectedIndex = 1;//同意界面

            AddFriendsVO addFriendsVO = CacheManager.dicAddFriends[index];
            ui.m_txt_addFriendInfo.text = addFriendsVO.nickName+"请求添加您为好友！";

            Sprite sprite = null;
            if (string.IsNullOrEmpty(addFriendsVO.icon))
            {
                Debug.Log("vo.friendsData.roleId:" + addFriendsVO.roleId);
                int path = R.SpritePack.HEAD_MAN;
                if (addFriendsVO.roleId == 0)
                {
                    path = R.SpritePack.HEAD_MAN;
                }
                else
                {
                    path = R.SpritePack.HEAD_WOMAN;
                }
                sprite = FileIO.LoadSprite(path);//头像
            }
            else
            {

            }
            if (sprite != null)
            {
                ui.m_icon.texture = new NTexture(sprite.texture);//头像 
            }

            //todo 等级分vip/lv
            if (addFriendsVO.vipLv > 0)
            {
                ui.m_c2.selectedIndex = 1;

                Sprite vipSprite = FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP" + addFriendsVO.vipLv);//等级头像
                ui.m_lv_icon.texture = new NTexture(vipSprite.texture);//等级图标
            }
            else
            {
                ui.m_c2.selectedIndex = 1;//普通等级

                ui.m_txt_lv.text = "Lv" + addFriendsVO.lv;//普通等级
            }
            ui.m_txt_ID.text = "ID:"+addFriendsVO.id;
            ui.m_txt_nike.text = "昵称："+addFriendsVO.nickName;

            ui.m_icon_title.visible =! addFriendsVO.readState;//提示图标
            ui.m_btn_refuse.onClick.Add(()=>refush(addFriendsVO.id));
            ui.m_btn_sure.onClick.Add(()=>agree(addFriendsVO.id));

            Debug.Log("添加好友：" + addFriendsVO);
        }
        else//消息
        {
            ui.m_c1.selectedIndex = 0;//系统消息
            FriendInfoVO vo = CacheManager.dicFriendsInfo[ index- CacheManager.dicAddFriends.Count];

            bool state = false;
            bool show = true;
            switch (vo.read)
            {
                case EnumReadInfoState.已读:
                    state = true;
                    break;
                case EnumReadInfoState.未读:
                    state = true;
                    break;
                default:
                    show = true;
                    break;
            }
            if (show)
            {
                ui.m_txt_info.text = vo.info;//消息
                ui.m_icon_title.visible = !state;//提示图标
                ui.m_btn_delete.visible = false;
            }
            Debug.Log("系统消息："+vo.info);
        }
    }
    /// <summary>
    /// 刷新好友在线状态
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="state"></param>
    public void RefreshFriendState(int userId, bool state)
    {
        if (CacheManager.dicFriendsList==null)
        {
            return;
        }
        int index = 0;
        foreach (var item in CacheManager.dicFriendsList)
        {
            if (item.friendsData.id==userId)
            {
                break;
            }
            index++;
        }
        UI_FriendCom2 ui = (UI_FriendCom2)UIPage.m_list_friend.GetChildAt(index);
        ui.m_c2.selectedIndex = state ? 0 : 1;
    }

    private void Info(EventContext context)
    {
        RefrashInfoList();
    }

    private void AddfriendTwo(EventContext context)
    {
        UIPage.m_c1.selectedIndex = 1;
        AddFriend();
        //UIPage.m_btn_addFriend.selected = true;
    }

    private void FriendItemRenderer(int index, GObject item)
    {
        UI_FriendCom2 ui=(UI_FriendCom2) item;
        FriendsDataVO vo = CacheManager.dicFriendsList[index];
        //Debug.Log(index+"************"+vo);
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
            Texture2D texture2D = CacheManager.GetHeadIcon(vo.friendsData.headIconUrl);
            //Texture2D texture2D = vo.friendsData.headIconImg.DecodeTexture2d(100, 100);
            sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
        }
        if (sprite!=null)
        {
            ui.m_icon.texture = new NTexture(sprite.texture);//头像  vo.friendsData.icon
        }

        //todo 等级分vip/lv
        if (vo.friendsData.vipLv > 0)
        {
            ui.m_c1.selectedIndex = 0;

            Sprite vipSprite = FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP" + vo.friendsData.vipLv);//等级头像
            ui.m_lv_icon.texture = new NTexture(vipSprite.texture);//等级图标
        }
        else
        {
            ui.m_c1.selectedIndex = 1;//普通等级

            ui.m_txt_lv.text = "Lv" + vo.friendsData.lv;//等级
        }
        ui.m_txt_nike.text = vo.friendsData.nickName;//昵称
        ui.m_txt_ID.text = vo.friendsData.id.ToString();//ID
        ui.m_btn_delete.visible = false;
        ui.m_btn_delete.onClick.Add(eventCallback);

        ui.m_c2.selectedIndex = vo.stateOnLine ? 0 : 1;
        ui.m_btn_chat.onClick.Add(btnChat);
    }

    private void SendAddFriend(EventContext context)
    {
        if (string.IsNullOrEmpty(ID))
        {
            return;
        }
        addFriend(ID);
    }

    private void Frined()
    {
        RefrushFriendsList();
    }

    public void RefrushFriendsList()
    {
        if (UIPage.m_c1.selectedIndex !=0)
        {
            return;
        }
        int count = CacheManager.dicFriendsList.Count;
        Debug.Log("好友列表："+ count);
        bool haveFriend = (count > 0);
        //UIPage.m_c1.selectedIndex = 0;//好友列表
        if (!haveFriend)
        {
            UIPage.m_txt_fri_title.visible = true;
            UIPage.m_txt_fri_title.text = "您还没有好友！";
            UIPage.m_btn_addfriend2.visible = true;
            UIPage.m_list_friend.numItems = 0;
        }
        else
        {
            UIPage.m_txt_fri_title.visible = false;
            UIPage.m_btn_addfriend2.visible = false;
            Debug.Log("刷新好友" + count);
            UIPage.m_list_friend.numItems = count;//刷新列表
        }
    }

    private void Look(EventContext context)
    {
        string txt = UIPage.m_txt_input.text;
        if (string.IsNullOrEmpty(txt))
        {
            UIPage.m_txt_input.text = "";
            return;
        }
        //Debug.Log("txt" + txt);
        foreach (char ch in txt)
        {
            if (ch<'0'||ch>'9')
            {
                UIPage.m_txt_input.text = "";
                return;
            }
        }
        //Debug.Log("txt"+ txt);
        
        int userId = int.Parse(txt);
        lookFriend(userId);
    }

    private void AddFriend()
    {
        UIPage.m_txt_input.text = "";
        UIPage.m_friendcom.visible = false;
    }

    public void ShowFriendCom(FriendsDataVO vo)
    {
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
            UIPage.m_friendcom.m_icon.texture = new NTexture(sprite.texture);//头像 
        }

        //todo 等级分vip/lv
        if (vo.friendsData.vipLv > 0)
        {
            UIPage.m_friendcom.m_c1.selectedIndex = 0;

            Sprite vipSprite = FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP" + vo.friendsData.vipLv);//等级头像
            UIPage.m_friendcom.m_lv_icon.texture = new NTexture(vipSprite.texture);//等级图标
        }
        else
        {
            UIPage.m_friendcom.m_c1.selectedIndex = 1;//普通等级

            UIPage.m_friendcom.m_txt_lv.text = "Lv" + vo.friendsData.lv;//普通等级
        }
        UIPage.m_friendcom.m_txt_nike.text = vo.friendsData.nickName;//昵称
        UIPage.m_friendcom.m_txt_ID.text = "ID:"+vo.friendsData.id;//id

        UIPage.m_friendcom.visible = true;
        ID = UIPage.m_friendcom.m_txt_ID.text;
    }
    public void CloseFriendCom()
    {
        ID = "";
        UIPage.m_friendcom.visible = false;
    }

    public void RefrashInfoList()
    {
        if (UIPage.m_c1.selectedIndex!=2)//消息通知
        {
            return;
        }
        int num = 0;
        if (CacheManager.dicAddFriends!=null)
        {
            num += CacheManager.dicAddFriends.Count;
        }
        if (CacheManager.dicFriendsInfo != null)
        {
            num += CacheManager.dicFriendsInfo.Count;
        }
        UIPage.m_list_info.numItems = num;
    }

    public void ShowInfo(string info)
    {
        if (UIPage.m_t0.playing)
        {
            UIPage.m_t0.Stop();
        }
        UIPage.m_info.visible = true;
        UIPage.m_txt_info.text = info;
        UIPage.m_t0.Play(()=> { UIPage.m_info.visible = false; });
    }
}
