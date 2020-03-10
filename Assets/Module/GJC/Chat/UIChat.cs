using System;
using System.Collections.Generic;
using Chat;
using Config;
using FairyGUI;
using FairyGUI.Utils;
using Room;
using UnityEngine;
using WT.UI;

public class UIChat : WTUIPage<UI_Chat, ChatCtrl>
{
    public Action<string> btnSend;
    public Action<int> btnShortCut;
    public Action<int> playInfo;
    private Dictionary<int, DataShortCut> dsc;
    private Dictionary<uint, Emoji> _emojies;//fairygui:表情列表
    private Dictionary<int, uint> listEmjoy;
    private int emojeyNum = 33;
    private GTextInput input;
    private int emjoyIndex = 0;
    private string info = "请输入聊天信息";
    private EventCallback1 callback;
    private EventCallback1 callback2;
    public UIChat() : base(UIType.PopUp, UIMode.DoNothing, R.UI.CHAT)
    {
    }

    public override void Awake()
    {
        callback = IconOnClick;
        callback2 = IconOnClickR;

        dsc =ConfigManager.Configs.DataShortCut;

        UIPage.m_btn_close.onClick.Add(Hide);//关闭

        UIPage.m_list_chat.itemRenderer = ChatItemRenderer;//聊天界面
        UIPage.m_list_shortcut.itemRenderer = ShortCutItemRenderer;//快捷面板
        UIPage.m_list_shortcut.onClickItem.Add(OnClickShortCut);
        UIPage.m_list_shortcut.autoResizeItem = true;

        UIPage.m_btn_chat.onClick.Add(BtnChat);//聊天按钮

        UIPage.m_btn_send.onClick.Add(BtnSen);//发送界面

        UIPage.m_txt_input.onClick.Add(InputOnClick);//输入文字
        UIPage.m_txt_input.onChanged.Add(InputChange);

        UIPage.m_list_shortcut.numItems = dsc.Count;
        UIPage.m_txt_input.text = "";
        UIPage.m_list_shortcut.autoResizeItem = true;
        UIPage.m_list_chat.autoResizeItem = true;

        UIPage.m_list_emoji.onClickItem.Add(EmjoyOnClick);//点击表情
        input = UIPage.m_txt_input.asTextInput;

        EmjoyComInit();

    }

    private void IconOnClickR(EventContext context)
    {
         Debug.Log("右");
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
         Debug.Log("左");
        GLoader ui = (GLoader)context.sender;
        int index = UIPage.m_list_chat.GetChildIndex(ui.parent);
        SmallChatVO vo = CacheManager.chat_small[index];
        if (vo!=null)
        {
            playInfo(vo.UserId);
        }
        //Debug.Log("第几个按钮点击 左："+index);
    }

    private int number = 30;
    /// <summary>
    /// 输入框文字检测
    /// </summary>
    /// <param name="context"></param>
    private void InputChange(EventContext context)
    {
        //string txt = UIPage.m_txt_input.text;
        //if (UIPage.m_txt_input.text.Length> number)
        //{
        //    UIPage.m_txt_input.text = txt.Substring(0, number);
        //}
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
        for (uint i = 0x1f633; i < 0x1f666; i++)
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
    }

    private void EmjoyOnClick(EventContext context)
    {
        GButton item = (GButton)context.data;
       
        int index = UIPage.m_list_emoji.GetChildIndex(item);
        string name = "";
        if (index < 10)
        {
            name= "1f6" + (index+33);
        }
        else
        {
            name= "1f6"+ (index+33);
        }
        //Debug.Log("点击表情：" + UIPackage.GetItemByURL(item.icon).name+", name:"+name);
        input.ReplaceSelection(Char.ConvertFromUtf32(Convert.ToInt32(name, 16)));
        emjoyIndex++;
    }

    private void OnClickShortCut(EventContext context)
    {
        //Debug.Log("点击快捷面板");
        UI_txtCom ui = (UI_txtCom)context.data;
        int infoIndex =UIPage.m_list_shortcut.GetChildIndex(ui)+1;
        //if (infoIndex<=0)
        //{
        //    Debug.Log("infoIndex="+ infoIndex);
        //    return;
        //}
        //btnShortCut(infoIndex);

        string info = ConfigManager.Configs.DataShortCut[infoIndex].Info;
        UIPage.m_txt_input.text = info;
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
        btnSend(txt);
        emjoyIndex = 0;
        UIPage.m_txt_input.text = "";
    }

    private void ShortCutItemRenderer(int index, GObject item)
    {
        UI_txtCom ui=(UI_txtCom)item;
        ui.m_txt_title.text = dsc[index + 1].Info;
        ui.height = ui.m_txt_title.height;

    }


    private void ChatItemRenderer(int index, GObject item)
    {
        UI_chatCom ui = (UI_chatCom)item;
        SmallChatVO vo = CacheManager.chat_small[index];
        //Debug.Log(vo+ ",CacheManager.gameData.userId="+ CacheManager.gameData.userId);
        if (vo.UserId==CacheManager.gameData.userId)
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

    private void Left(UI_chatCom ui, SmallChatVO vo)
    {
        string info = UBBParser.inst.Parse(vo.Info);
        GRichTextField tf = ui.m_txt_title.asRichTextField;
        tf.emojies = _emojies;
        tf.text = UBBParser.inst.Parse(info);//消息内容

        Sprite sprite = null;
        if(string.IsNullOrEmpty(vo.headIconUrl))
        //if (vo.headIcon==null||vo.headIcon.Length<=0)
        {
            Debug.Log(vo.HeadId + "_" + vo.RoelId);
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
            Texture2D t2d = CacheManager.GetHeadIcon(vo.headIconUrl);
          
            sprite = Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), Vector2.zero);
        }

        if (sprite != null)
        {
            ui.m_icon.texture = new NTexture(sprite.texture);//头像
        }

        if (vo.VipLv > 0)
        {
            ui.m_c2.selectedIndex = 0;

            Sprite vipSprite = FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP" + vo.VipLv);//等级头像
            ui.m_vipLv_icon_r.texture = new NTexture(vipSprite.texture);

            ui.m_nike.text = vo.NikeName;//名字
        }
        else
        {
            ui.m_c2.selectedIndex = 1;

            ui.m_nikeName.text = "LV" + vo.Lv + "  " + vo.NikeName;//等级+名字
        }
        ui.height = 35 + tf.textHeight;
        ui.m_n12.height = ui.height;
    }

    private void Right(UI_chatCom ui, SmallChatVO vo)
    {
        string info = UBBParser.inst.Parse(vo.Info);
        GRichTextField tf = ui.m_txt_title_r.asRichTextField;
        tf.emojies = _emojies;
        tf.text = UBBParser.inst.Parse(info);//消息内容

        Sprite sprite = null;
        if (string.IsNullOrEmpty(vo.headIconUrl))
        //if (vo.headIcon==null||vo.headIcon.Length<=0)
        {
            Debug.Log(vo.HeadId + "_" + vo.RoelId);
            int path = R.SpritePack.HEAD_MAN;
            if (vo.RoelId==0)
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
            Texture2D t2d = CacheManager.GetHeadIcon(vo.headIconUrl);
            //Texture2D texture2D = HelperClass.DecodeTexture2d(vo.headIcon, 100, 100);
            sprite = Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), Vector2.zero);
        }

        if (sprite != null)
        {
            ui.m_icon_r.texture = new NTexture(sprite.texture);
        }

        if (vo.VipLv > 0)
        {
            ui.m_c3.selectedIndex = 0;

            Sprite vipSprite = FileIO.LoadSprite("GJC/Player/SpritePack/VIP/VIP"+vo.VipLv);//等级头像
            ui.m_vipLv_icon_r.texture = new NTexture(vipSprite.texture);

            ui.m_nike_r.text = vo.NikeName;//名字

            ui.m_nikeName_r.visible = false;
        }
        else
        {
            ui.m_c3.selectedIndex = 1;
            ui.m_nikeName_r.text = vo.NikeName+ " "+"LV" + vo.Lv ;//等级+名字
        }
        ui.height = 35 + tf.textHeight;
        ui.m_n12.height = ui.height;
    }

    public void ShowChat()
    {
        if (UIPage.m_c1.selectedIndex==0)
        {
            UIPage.m_list_chat.numItems = CacheManager.chat_small.Count;
            UIPage.m_list_chat.autoResizeItem = true;
        }
    }
}
