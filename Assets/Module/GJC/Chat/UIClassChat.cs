using Chat;
using DG.Tweening;
using FairyGUI;
using FairyGUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;

public class UIClassChat : WTUIPage<UI_ClassChat, ChatCtrl>
{
    private Dictionary<uint, Emoji> _emojies;//fairygui:表情列表
    private Tween tween;

    private int time = 3;

    public UIClassChat() : base(UIType.PopUp, UIMode.DoNothing, R.UI.CHAT)
    {
    }

    public override void Awake()
    {
        //UIPage.m_c1.selectedIndex = 5;

        EmjoyComInit();
    }

    public override void Refresh()
    {
        base.Refresh();
        HideAllT();
        HideAllTN();
    }

    private void HideAllT()
    {
        UIPage.m_t0.visible = false;
        UIPage.m_t1.visible = false;
        UIPage.m_t2.visible = false;
        UIPage.m_t3.visible = false;
        UIPage.m_t4.visible = false;
    }

    private void HideAllTN()
    {
        UIPage.m_en0.visible = false;
        UIPage.m_en1.visible = false;
        UIPage.m_en2.visible = false;
        UIPage.m_en3.visible = false;
        UIPage.m_en4.visible = false;
    }




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
    }

    public void ShowEnjoy(SmallChatVO smallChatVO)
    {
        int index = 0;
        if (CacheManager.ClassRoomPlayers != null)
        {
            foreach (PlayerSimpleData item in CacheManager.ClassRoomPlayers)
            {
                index++;
                if (item == null)
                {
                    //Debug.LogError("房间座位：item==null");
                    continue;
                }
                if (smallChatVO.UserId == item.userId)
                {
                    //Debug.Log("表情");
                    //UIPage.m_c1.selectedIndex = item.pos;
                    ShowEnjoy(index - 1, smallChatVO.Info);
                }
            }
        }
    }

    private void ShowEnjoy(int pos, string info)
    {
        Debug.Log("座位pos：" + pos + "表情");
        switch (pos)
        {
            case 0:
                UIPage.m_en0.visible = true;
                //GRichTextField tf = UIPage.m_en0.asRichTextField;
                //tf.emojies = _emojies;
                //tf.text = UBBParser.inst.Parse(info);//消息内容
                //Debug.Log(" tf.text" + tf.text);
                UIPage.m_en0.url = GetUrl(info);

                if (UIPage.m_tn0.playing)
                {
                    UIPage.m_tn0.Stop();
                }
                UIPage.m_tn0.Play(() => { Over(pos); });

                break;
            case 1:
                UIPage.m_en1.visible = true;
                UIPage.m_en1.url = GetUrl(info);
                //GRichTextField tf1 = UIPage.m_en1.asRichTextField;
                //tf1.emojies = _emojies;
                //tf1.text = UBBParser.inst.Parse(info);//消息内容
                //UIPage.m_n1.height = UIPage.m_txt1.textHeight + 8;
                //UIPage.m_n1.width = UIPage.m_txt1.textWidth + 8;

                if (UIPage.m_tn1.playing)
                {
                    UIPage.m_tn1.Stop();
                }
                UIPage.m_tn1.Play(() => { Over1(pos); });

                break;
            case 2:
                UIPage.m_en2.visible = true;
                UIPage.m_en2.url = GetUrl(info);
                //GRichTextField tf2 = UIPage.m_en2.asRichTextField;
                //tf2.emojies = _emojies;
                //tf2.text = UBBParser.inst.Parse(info);//消息内容

                if (UIPage.m_tn2.playing)
                {
                    UIPage.m_tn2.Stop();
                }
                UIPage.m_tn2.Play(() => { Over2(pos); });

                break;
            case 3:
                UIPage.m_en3.visible = true;
                UIPage.m_en3.url = GetUrl(info);
                //GRichTextField tf3 = UIPage.m_en3.asRichTextField;
                //tf3.emojies = _emojies;
                //tf3.text = UBBParser.inst.Parse(info);//消息内容

                if (UIPage.m_tn3.playing)
                {
                    UIPage.m_tn3.Stop();
                }
                UIPage.m_tn3.Play(() => { Over3(pos); });


                break;
            case 4:
                UIPage.m_en4.visible = true;
                UIPage.m_en4.url = GetUrl(info);
                //GRichTextField tf4 = UIPage.m_en4.asRichTextField;
                //tf4.emojies = _emojies;
                //tf4.text = UBBParser.inst.Parse(info);//消息内容

                if (UIPage.m_tn4.playing)
                {
                    UIPage.m_tn4.Stop();
                }
                UIPage.m_tn4.Play(() => { Over4(pos); });

                break;
            default:
                break;
        }
    }

    private string GetUrl(string info)
    {
        for (uint index = 0; index < 33; index++)
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
            if (Char.ConvertFromUtf32(Convert.ToInt32(name, 16)) == info)
            {
                //Debug.Log("相等");
                return UIPackage.GetItemURL("Chat", name);
            }
        }
        return null;
    }

    private void Over4(int pos)
    {
        UIPage.m_tn4.PlayReverse(() => { HideEn(pos); });
    }

    private void Over3(int pos)
    {
        UIPage.m_tn3.PlayReverse(() => { HideEn(pos); });
    }

    private void Over2(int pos)
    {
        UIPage.m_tn2.PlayReverse(() => { HideEn(pos); });
    }

    private void Over1(int pos)
    {
        UIPage.m_tn1.PlayReverse(() => { HideEn(pos); });
    }

    private void Over(int pos)
    {
        UIPage.m_tn0.PlayReverse(() => { HideEn(pos); });
    }

    private void HideEn(int pos)
    {
        switch (pos)
        {
            case 0:
                UIPage.m_en0.visible = false;
                break;
            case 1:
                UIPage.m_en1.visible = false;
                break;
            case 2:
                UIPage.m_en2.visible = false;
                break;
            case 3:
                UIPage.m_en3.visible = false;
                break;
            case 4:
                UIPage.m_en4.visible = false;
                break;
            default:
                break;
        }
    }

    public void ShowTxt(SmallChatVO smallChatVO)
    {
        if (CacheManager.ClassRoomPlayers != null)
        {
            foreach (PlayerSimpleData item in CacheManager.ClassRoomPlayers)
            {
                if (item == null)
                {
                    continue;
                }
                if (smallChatVO.UserId == item.userId)
                {
                    int pos = -1;
                    if (CacheManager.RunRoomId == 5)//万人场
                    {
                        pos = ToolClass.AbsToRel(item.manyGamepos);
                    }else
                        pos = ToolClass.AbsToRel(item.classicGamepos);
                    //string info = "我是玩家：" + item.userId + ",我在座位：" + pos + "我的消息是：\n" + smallChatVO.Info;
                    string info = smallChatVO.Info;
                    ShowTxt(pos, info);

                    tween = DOTween.To(() => time, (value) => { }, 0, time).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        HideTxt(pos);
                    });
                }
            }
        }
    }

    private void HideTxt(int pos)
    {
        Debug.Log("隐藏" + pos);
        switch (pos)
        {
            case 0:
                UIPage.m_t0.visible = false;
                break;
            case 1:
                UIPage.m_t1.visible = false;
                break;
            case 2:
                UIPage.m_t2.visible = false;
                break;
            case 3:
                UIPage.m_t3.visible = false;
                break;
            case 4:
                UIPage.m_t4.visible = false;
                break;
            default:
                break;
        }
    }

    public void ShowTxt(int pos, string info)
    {
        Debug.Log("座位pos：" + pos + "消息" + info);
        switch (pos)
        {
            case 0:
                UIPage.m_t0.visible = true;
                GRichTextField tf = UIPage.m_txt0.asRichTextField;
                tf.emojies = _emojies;
                tf.text = UBBParser.inst.Parse(info);//消息内容
                UIPage.m_n0.height = UIPage.m_txt0.textHeight + 8;
                UIPage.m_n0.width = UIPage.m_txt0.textWidth + 8;

                //if (UIPage.m_t00.playing)
                //{
                //    UIPage.m_t00.Stop();
                //}
                //UIPage.m_t00.Play(()=> { HideTxt(pos); });

                break;
            case 1:
                UIPage.m_t1.visible = true;
                GRichTextField tf1 = UIPage.m_txt1.asRichTextField;
                tf1.emojies = _emojies;
                tf1.text = UBBParser.inst.Parse(info);//消息内容
                UIPage.m_n1.height = UIPage.m_txt1.textHeight + 8;
                UIPage.m_n1.width = UIPage.m_txt1.textWidth + 8;

                //if (UIPage.m_t01.playing)
                //{
                //    UIPage.m_t01.Stop();
                //}
                //UIPage.m_t01.Play(() => { HideTxt(pos); });

                break;
            case 2:
                UIPage.m_t2.visible = true;
                GRichTextField tf2 = UIPage.m_txt2.asRichTextField;
                tf2.emojies = _emojies;
                tf2.text = UBBParser.inst.Parse(info);//消息内容
                UIPage.m_n2.height = UIPage.m_txt2.textHeight + 8;
                UIPage.m_n2.width = UIPage.m_txt2.textWidth + 8;

                //if (UIPage.m_t02.playing)
                //{
                //    UIPage.m_t02.Stop();
                //}
                //UIPage.m_t02.Play(() => { HideTxt(pos); });

                break;
            case 3:
                UIPage.m_t3.visible = true;
                GRichTextField tf3 = UIPage.m_txt3.asRichTextField;
                tf3.emojies = _emojies;
                tf3.text = UBBParser.inst.Parse(info);//消息内容
                UIPage.m_n3.height = UIPage.m_txt3.textHeight + 8;
                UIPage.m_n3.width = UIPage.m_txt3.textWidth + 8;

                //if (UIPage.m_t03.playing)
                //{
                //    UIPage.m_t03.Stop();
                //}
                //UIPage.m_t03.Play(() => { HideTxt(pos); });


                break;
            case 4:
                UIPage.m_t4.visible = true;
                GRichTextField tf4 = UIPage.m_txt4.asRichTextField;
                tf4.emojies = _emojies;
                tf4.text = UBBParser.inst.Parse(info);//消息内容
                UIPage.m_n4.height = UIPage.m_txt4.textHeight + 8;
                UIPage.m_n4.width = UIPage.m_txt4.textWidth + 8;

                //if (UIPage.m_t04.playing)
                //{
                //    UIPage.m_t04.Stop();
                //}
                //UIPage.m_t04.Play(() => { HideTxt(pos); });

                break;
            default:
                break;
        }
    }

    public void ShowTenEnjoy(SmallChatVO smallChatVO)
    {
        int index = 0;
        if (CacheManager.ClassRoomPlayers != null)
        {
            foreach (PlayerSimpleData item in CacheManager.ManyPeopleRoomPlayers)
            {
                index++;
                if (item == null)
                {
                    //Debug.LogError("房间座位：item==null");
                    continue;
                }
                if (smallChatVO.UserId == item.userId)
                {
                    //Debug.Log("表情");
                    //UIPage.m_c1.selectedIndex = item.pos;
                    ShowEnjoy(index - 1, smallChatVO.Info);
                }
            }
        }
    }

    public void ShowTenTxt(SmallChatVO smallChatVO)
    {
        if (CacheManager.RunRoomId == 5)//万人场
        {
            if (CacheManager.ManyPeopleRoomPlayers != null)
            {
                foreach (PlayerSimpleData item in CacheManager.ManyPeopleRoomPlayers)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (smallChatVO.UserId == item.userId)
                    {
                        int pos = ToolClass.AbsToRelThous(item.manyGamepos);
                        string info = smallChatVO.Info;
                        ShowTxt(pos, info);

                        tween = DOTween.To(() => time, (value) => { }, 0, time).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            HideTxt(pos);
                        });
                    }
                }
            }
        }
        else
        {
            if (CacheManager.ClassRoomPlayers != null)
            {
                foreach (PlayerSimpleData item in CacheManager.ClassRoomPlayers)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (smallChatVO.UserId == item.userId)
                    {
                        int pos = ToolClass.AbsToRel(item.classicGamepos);
                        string info = smallChatVO.Info;
                        ShowTxt(pos, info);

                        tween = DOTween.To(() => time, (value) => { }, 0, time).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            HideTxt(pos);
                        });
                    }
                }
            }
        }
    }
}
