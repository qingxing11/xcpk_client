using System;
using System.Collections.Generic;
using Chat;
using Config;
using FairyGUI;
using FairyGUI.Utils;
using Room;
using UnityEngine;
using WT.UI;

public class UIChat2 : WTUIPage<UI_Chat2, ChatCtrl>
{
    //4:水果机 3:经典场 2:万人场 1:通杀场


    public Action<string,int> btnSend;
    public Action<string,bool,int> btnSend2;
    public Action<string, bool,int,int> btnSend3;
    public Action<int> btnShortCut;
    public Action<int> playInfo;
    public Action hide;
    private Dictionary<int, DataShortCut2> dsc2;
    private Dictionary<int, DataShortCut> dsc;
    private Dictionary<int, DataShortCut3> dsc3;//水果机

    private Dictionary<uint, Emoji> _emojies;//fairygui:表情列表
    private Dictionary<uint, Emoji> _emojies2;//fairygui:表情列表
    private Dictionary<int, uint> listEmjoy;
    private int emojeyNum = 33;
    private GTextInput input;
    private int emjoyIndex = 0;
    private string info = "请输入聊天信息";
    private EventCallback1 callback;
    private EventCallback1 callback2;
    private int shutIndex;//快捷键索引
    private List<int> man;
    private List<int> woman;

    private int curRoom;

    public UIChat2() : base(UIType.Dialog, UIMode.DoNothing, R.UI.CHAT)
    {
    }

    public override void Awake()
    {
        shutIndex = 0;
        dsc2 = ConfigManager.Configs.DataShortCut2;
        dsc = ConfigManager.Configs.DataShortCut;
        dsc3= ConfigManager.Configs.DataShortCut3;
        man = new List<int>();
        woman = new List<int>();

        foreach (var item in dsc2)
        {
            if (item.Value.Role == EnumRole.man)
            {
                man.Add(item.Value.Id);
            }
            else
            {
                woman.Add(item.Value.Id);
            }
        }

        callback = IconOnClick;
        callback2 = IconOnClickR;
      

        UIPage.m_btn_close.onClick.Add(Hide);//关闭

        UIPage.m_list_chat.itemRenderer = ChatItemRenderer;//聊天界面
        UIPage.m_list_shortcut.itemRenderer = ShortCutItemRenderer;//快捷面板
        UIPage.m_list_shortcut.onClickItem.Add(OnClickShortCut);
        UIPage.m_list_shortcut.autoResizeItem = true;

        //UIPage.m_btn_chat.onClick.Add(BtnChat);//聊天按钮

        UIPage.m_btn_send.onClick.Add(BtnSen);//发送界面

        UIPage.m_txt_input.onClick.Add(InputOnClick);//输入文字
        UIPage.m_txt_input.onChanged.Add(InputChange);

        UIPage.m_txt_input.text = "";
        UIPage.m_list_shortcut.autoResizeItem = true;
        UIPage.m_list_chat.autoResizeItem = true;

        UIPage.m_list_emoji.onClickItem.Add(EmjoyOnClick);//点击表情
        input = UIPage.m_txt_input.asTextInput;

        EmjoyComInit();

    }

    public override void Refresh()
    {
        base.Refresh();
        
    }

    private void RefreshShutCutList()
    {
        if (curRoom == 3|| curRoom == 2)//经典场
        {
            if (CacheManager.gameData.roleId == EnumRole.man)
            {
                UIPage.m_list_shortcut.numItems = man.Count;
            }
            else
            {
                UIPage.m_list_shortcut.numItems = woman.Count;
            }
        }
        else if (curRoom == 1)
        {
            UIPage.m_list_shortcut.numItems = dsc.Count;
        }
        else if (curRoom == 4)
        {
            UIPage.m_list_shortcut.numItems = dsc3.Count;
        }
    }

    public void InitRoom(int room)
    {
        curRoom = room;
        RefreshShutCutList();
        ShowChat();
    }

    public override void Hide()
    {
        curRoom = 0;
        hide();
        base.Hide();
    }

    private void IconOnClickR(EventContext context)
    {
        //Debug.Log("右");
        GLoader ui = (GLoader)context.sender;
        int index = UIPage.m_list_chat.GetChildIndex(ui.parent);
        SmallChatVO vo = CacheManager.chat_small[index];
        if (vo != null)
        {
            playInfo(vo.UserId);
        }
        //Debug.Log("第几个按钮点击 右：" + index);
    }

    private void IconOnClick(EventContext context)
    {
        //Debug.Log("左");
        GLoader ui = (GLoader)context.sender;
        int index = UIPage.m_list_chat.GetChildIndex(ui.parent);
        SmallChatVO vo = CacheManager.chat_small[index];
        if (vo != null)
        {
            playInfo(vo.UserId);
        }
        //Debug.Log("第几个按钮点击 左："+index);
    }

    private int number = 15;
    /// <summary>
    /// 输入框文字检测
    /// </summary>
    /// <param name="context"></param>
    private void InputChange(EventContext context)
    {
        string txt = UIPage.m_txt_input.text;
        if (UIPage.m_txt_input.text.Length > number)
        {
            UIPage.m_txt_input.text = txt.Substring(0, number);
        }
    }

    private void BtnChat(EventContext context)
    {
        UIPage.m_list_chat.numItems = CacheManager.chat_small.Count;
        UIPage.m_list_chat.autoResizeItem = true;
    }

    /// <summary>
    /// 表情面板初始化
    /// </summary>
    private void EmjoyComInit()
    {
        _emojies = new Dictionary<uint, Emoji>();
        for (uint i = 0x1f600; i < 0x1f633; i++)
        {
            string url = UIPackage.GetItemURL("Chat", Convert.ToString(i, 16));
            if (url != null)
            {
                _emojies.Add(i, new Emoji(url));
                //Debug.Log("biaoqing"+i+"    ."+url);
            }
            else
            {
                //Debug.Log("biaoqing");
            }
        }
        input.emojies = _emojies;


        _emojies2 = new Dictionary<uint, Emoji>();
        for (uint i = 0x1f633; i < 0x1f666; i++)
        {
            string url = UIPackage.GetItemURL("Chat", Convert.ToString(i, 16));
            if (url != null)
            {
                _emojies2.Add(i, new Emoji(url));
                //Debug.Log("biaoqing" + i + "    ." + url);
            }
            else
            {
                //Debug.Log("biaoqing");
            }
        }
    }

    private void EmjoyOnClick(EventContext context)
    {
        GButton item = (GButton)context.data;

        int index = UIPage.m_list_emoji.GetChildIndex(item);
        string name = "";
        if (index < 10)
        {
            name = "1f60" + (index);
        }
        else
        {
            name = "1f6" + (index);
        }
        //Debug.Log("点击表情：" + UIPackage.GetItemByURL(item.icon).name+", name:"+name);
        //input.ReplaceSelection(Char.ConvertFromUtf32(Convert.ToInt32(name, 16)));
        btnSend2(Char.ConvertFromUtf32(Convert.ToInt32(name, 16)),true,curRoom);
        emjoyIndex++;
        Hide();
    }

    private void OnClickShortCut(EventContext context)
    {
        //Debug.Log("点击快捷面板");
        UI_txtCom2 ui = (UI_txtCom2)context.data;
        int infoIndex = UIPage.m_list_shortcut.GetChildIndex(ui);

        string info = "";
        if (curRoom == 3 || curRoom == 2)
        {
            int index = 0;
            if (CacheManager.gameData.roleId == EnumRole.man)
            {
                index = man[infoIndex];
            }
            else
            {
                index = woman[infoIndex];
            }
            info = dsc2[index].Info;
            //PlayAudioClip(index);
            btnSend3(info, true, index, curRoom);
        }
        else if (curRoom == 1)
        {
            int index = UIPage.m_list_shortcut.GetChildIndex(ui);
            info = dsc[index + 1].Info;
            btnSend(info, curRoom);
        }
        else if (curRoom == 4)
        {
            int index = UIPage.m_list_shortcut.GetChildIndex(ui);
            info = dsc3[index + 1].Info;
            btnSend(info, curRoom);
        }
       
        //UIPage.m_txt_input.text = info;

        Hide();
    }

    

    private void InputOnClick(EventContext context)
    {
        //UIPage.m_txt_input.text = "";
    }

    private void BtnSen(EventContext context)
    {
        string txt = UIPage.m_txt_input.text;
        if (string.IsNullOrEmpty(txt))
        {
            return;
        }
        btnSend(txt,curRoom);
        emjoyIndex = 0;
        UIPage.m_txt_input.text = "";

        Hide();
    }

    private void ShortCutItemRenderer(int index, GObject item)
    {
        UI_txtCom2 ui = (UI_txtCom2)item;

        if (curRoom==3||curRoom==2)
        {
            int realIndex = 0;
            if (CacheManager.gameData.roleId == EnumRole.man)
            {
                //Debug.Log("index:" + index);
                realIndex = man[index];
                //Debug.Log("realIndex:"+ realIndex);
            }
            else
            {
                realIndex = woman[index];
            }

            ui.m_txt_title.text = dsc2[realIndex].Info;
            //ui.height = ui.m_txt_title.height;
        }
        else if(curRoom == 1)
        {
            ui.m_txt_title.text = dsc[index + 1].Info;
            //ui.height = ui.m_txt_title.textHeight;
        }
        else if(curRoom == 4)
        {
            ui.m_txt_title.text = dsc3[index + 1].Info;
        }
    }


    private void ChatItemRenderer(int index, GObject item)
    {
        UI_chatCom2 ui = (UI_chatCom2)item;

        SmallChatVO vo = null;
        switch (curRoom)
        {
            case 1:
                vo = CacheManager.chat_small[index];
                Debug.Log("通杀场消息"+vo);
                break;
            case 2:
                vo = CacheManager.chat_ten[index];
                Debug.Log("万人场消息" + vo);
                break;
            case 3:
                vo = CacheManager.chat_classic[index];
                Debug.Log("经典场消息" + vo);
                break;
            case 4:
                vo = CacheManager.chat_FruitMechine[index];
                Debug.Log("水果机消息" + vo);
                break;
            default:
                break;
        }

        Debug.Log(vo+ ",CacheManager.gameData.userId="+ CacheManager.gameData.userId);
        if (vo.UserId == CacheManager.gameData.userId)
        {
            ui.m_c1.selectedIndex = 1;
            Right(ui, vo);
            //Debug.Log("右");
            ui.m_icon_r.onClick.Add(IconOnClickR);
        }
        else
        {
            ui.m_c1.selectedIndex = 0;
            Left(ui, vo);
            ui.m_icon.onClick.Add(IconOnClick);
            //Debug.Log("左");
        }
    }
    private string GetEnjoy(string info)
    {
        //bool enjoy = false;
        int index = 0;
        foreach (var item in _emojies)
        {
            string name = "";
            if (index < 10)
            {
                name = "1f60" + (index);
            }
            else
            {
                name = "1f6" + (index);
            }
            string _info = Char.ConvertFromUtf32(Convert.ToInt32(name, 16));
            if (_info == info)
            {
                //enjoy = true;

                if (index < 10)
                {
                    name = "1f6" + (index + 33);
                }
                else
                {
                    name = "1f6" + (index + 33);
                }
                return  Char.ConvertFromUtf32(Convert.ToInt32(name, 16));
            }

            index++;
        }
        return info;
    }
    private void Left(UI_chatCom2 ui, SmallChatVO vo)
    {
        string info = GetEnjoy(vo.Info);
        bool enjoy = info.Equals(vo.Info);

        GRichTextField tf = ui.m_txt_title.asRichTextField;
        if (enjoy)
        {
            tf.emojies = _emojies;
        }
        else
        {
            tf.emojies = _emojies2;
        }
       
        tf.text = UBBParser.inst.Parse(info);//消息内容

        Sprite sprite = null;

        if (string.IsNullOrEmpty(vo.headIconUrl))
        //if (vo.headIcon == null || vo.headIcon.Length <= 0)
        {
            int path = R.SpritePack.HEAD_MAN;
            if (vo.RoelId == 0)
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
            Texture2D texture2D = CacheManager.GetHeadIcon(vo.headIconUrl);
            //Texture2D texture2D = HelperClass.DecodeTexture2d(vo.headIcon, 100, 100);
            sprite=Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
        }

        if (sprite != null)
        {
            ui.m_icon.texture = new NTexture(sprite.texture);//头像
        }

        if (vo.VipLv > 0)
        {
            ui.m_c2.selectedIndex = 0;

            Sprite vipSprite = FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP" + vo.VipLv);//等级头像
            ui.m_vipLv_icon.texture = new NTexture(vipSprite.texture);

            ui.m_nike.text = vo.NikeName;//名字
        }
        else
        {
            ui.m_c2.selectedIndex = 1;

            ui.m_nikeName.text = "LV" + vo.Lv + "  " + vo.NikeName;//等级+名字
        }
        ui.height = 35 + tf.textHeight;
        ui.m_n13.height = tf.textHeight+14*2;
        ui.m_n13.width = tf.textWidth + 8*2;
    }

    private void Right(UI_chatCom2 ui, SmallChatVO vo)
    {
        string info = GetEnjoy(vo.Info);
        bool enjoy = info.Equals(vo.Info);

        GRichTextField tf = ui.m_txt_title_r.asRichTextField;
        if (enjoy)
        {
            tf.emojies = _emojies;
        }
        else
        {
            tf.emojies = _emojies2;
        }
        tf.text = UBBParser.inst.Parse(info);//消息内容

        Sprite sprite = null;

        if (string.IsNullOrEmpty(vo.headIconUrl))
        //if (vo.headIcon == null || vo.headIcon.Length <= 0)
        {
            int path = R.SpritePack.HEAD_MAN;
            if (vo.RoelId == 0)
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
            Texture2D texture2D = CacheManager.GetHeadIcon(vo.headIconUrl);
            //Texture2D texture2D = HelperClass.DecodeTexture2d(vo.headIcon, 100, 100);
            sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
        }

        if (sprite != null)
        {
            ui.m_icon_r.texture = new NTexture(sprite.texture);
        }

        if (vo.VipLv > 0)
        {
            ui.m_c3.selectedIndex = 0;

            Sprite vipSprite = FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP" + vo.VipLv);//等级头像
            ui.m_vipLv_icon_r.texture = new NTexture(vipSprite.texture);

            ui.m_nike_r.text = vo.NikeName;//名字

            ui.m_nikeName_r.visible = false;
        }
        else
        {
            ui.m_c3.selectedIndex = 1;
            ui.m_nikeName_r.text = vo.NikeName + " " + "LV" + vo.Lv;//等级+名字
        }
        ui.height = 35 + tf.textHeight;
        ui.m_n15.height = tf.textHeight+ 14 * 2;
        ui.m_n15.width = tf.textWidth + 8*2;
    }

    public void ShowChat()
    {
        switch (curRoom)
        {
            case 1:
                if (CacheManager.chat_small != null)
                {
                    UIPage.m_list_chat.numItems = CacheManager.chat_small.Count;
                }
                else
                {
                    UIPage.m_list_chat.numItems = 0;
                }
                break;
            case 2:
                if (CacheManager.chat_ten != null)
                {
                    UIPage.m_list_chat.numItems = CacheManager.chat_ten.Count;
                }
                else
                {
                    UIPage.m_list_chat.numItems = 0;
                }
                break;
            case 3:
                if (CacheManager.chat_classic != null)
                {
                    UIPage.m_list_chat.numItems = CacheManager.chat_classic.Count;
                }
                else
                {
                    UIPage.m_list_chat.numItems = 0;
                }
                break;
            case 4:
                if (CacheManager.chat_FruitMechine != null)
                {
                    UIPage.m_list_chat.numItems = CacheManager.chat_FruitMechine.Count;
                }
                else
                {
                    UIPage.m_list_chat.numItems = 0;
                }
                break;
            default:
                break;
        }
        
        UIPage.m_list_chat.autoResizeItem = true;
    }
}
