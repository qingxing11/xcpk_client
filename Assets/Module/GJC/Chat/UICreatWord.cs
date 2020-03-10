using FairyGUI;
using FairyGUI.Utils;
using Chat;
using System;
using System.Collections.Generic;
using WT.UI;
using UnityEngine;

public class UICreatWord : WTUIPage<UI_creatWord, ChatCtrl>
{
    public Action<UICreatWord> over;
    private Dictionary<uint, Emoji> _emojies;//fairygui:表情列表
    private Dictionary<uint, Emoji> _emojies2;//fairygui:表情列表
    private int emojeyNum = 33;
    public UICreatWord() : base(UIType.PopUp, UIMode.DoNothing, R.UI.CHAT)
    {

    }
    public override void Awake()
    {
        EmjoyComInit();
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
                //Debug.Log("biaoqing" + i + "    ." + url);
            }
            else
            {
                //Debug.Log("biaoqing");
            }
        }

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


    public void ShowTxt(string info, string nikeName, int vipLv)
    {
        //Debug.Log("ShowTxt");
        bool enjoy = false;
        int index = 0;
        foreach (var item in _emojies)
        {
            string name="";
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
                enjoy = true;

                if (index < 10)
                {
                    name = "1f6" + (index+33);
                }
                else
                {
                    name = "1f6" + (index+33);
                }
                info = Char.ConvertFromUtf32(Convert.ToInt32(name, 16));
            }

            index++;
        }

        if (vipLv<=0)
        {
            UIPage.m_c1.selectedIndex = 1;

            
            GRichTextField tf = UIPage.m_txt.asRichTextField;
            if (enjoy)
            {
                tf.emojies = _emojies2;
            }
            else
            {
                tf.emojies = _emojies;
            }
           
            tf.text = UBBParser.inst.Parse(info);//消息内容

            //tf.text = nikeName + ":" + tf.text;


            UIPage.m_n1.height = tf.height;
            UIPage.m_n1.width = tf.width;
        }
        else
        {
            UIPage.m_c1.selectedIndex = 0;
 
            UIPage.m_txt_name.text = nikeName+":";


            GRichTextField tf2 = UIPage.m_txt_vipLv.asRichTextField;
            if (enjoy)
            {
                tf2.emojies = _emojies2;
            }
            else
            {
                tf2.emojies = _emojies;
            }
            tf2.text = UBBParser.inst.Parse(info);
            tf2.position = UIPage.m_txt_name.position + new Vector3(UIPage.m_txt_name.width,0,0);

            string path = "GJC/Player/SpritePack/VIP2/vip" + vipLv;
            Sprite sprite = FileIO.LoadSprite(path);
            if (sprite!=null)
            {
                UIPage.m_icon_vipLv.texture = new NTexture(sprite.texture);
            }
            UIPage.m_n1.height = UIPage.m_n5.height+10;
            UIPage.m_n1.width =  UIPage.m_icon_vipLv.width+UIPage.m_txt_name.width+ tf2.textWidth+5;
          
        }

        
    }

    public void PlayEffect(string key,float timeScale)
    {
        UIPage.m_t0.Play(()=> { over(this); });
        UIPage.m_t0.timeScale = timeScale; //动效播放的速度将会是原来的一半。
    }

}
