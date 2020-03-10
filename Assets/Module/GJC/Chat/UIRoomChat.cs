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

public class UIRoomChat : WTUIPage<UI_RoomChat2, ChatCtrl>
{
    private Dictionary<uint, Emoji> _emojies;//fairygui:表情列表
    private Tween tween;

    private int time = 3;

    public UIRoomChat() : base(UIType.PopUp, UIMode.DoNothing, R.UI.CHAT)
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
        UIPage.m_t5.visible = false;
        UIPage.m_t6.visible = false;
        UIPage.m_t7.visible = false;
    }

    private void HideAllTN()
    {
        UIPage.m_en0.visible = false;
        UIPage.m_en1.visible = false;
        UIPage.m_en2.visible = false;
        UIPage.m_en3.visible = false;
        UIPage.m_en4.visible = false;
        UIPage.m_en5.visible = false;
        UIPage.m_en6.visible = false;
        UIPage.m_en7.visible = false;
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
        int index = 8;
        if (CacheManager.ClassRoomPlayers != null)
        {
            foreach (PlayerSimpleData item in CacheManager.TablePlayers)
            {
                index--;
                if (item == null)
                {
                    //Debug.LogError("房间座位：item==null");
                    continue;
                }
                if (smallChatVO.UserId == item.userId)
                {
                    //Debug.Log("表情");
                    //UIPage.m_c1.selectedIndex = item.pos;
                    ShowEnjoy(index, smallChatVO.Info);
                }
            }
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

    private void ShowEnjoy(int pos, string info)
    {
        Debug.Log("座位pos：" + pos + "表情");
        Debug.Log("UIpage="+UIPage);
        switch (pos)
        {
            case 0:
                UIPage.m_en0.visible = true;
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

                if (UIPage.m_tn1.playing)
                {
                    UIPage.m_tn1.Stop();
                }
                UIPage.m_tn1.Play(() => { Over1(pos); });

                break;
            case 2:
                UIPage.m_en2.visible = true;
                UIPage.m_en2.url = GetUrl(info);

                if (UIPage.m_tn2.playing)
                {
                    UIPage.m_tn2.Stop();
                }
                UIPage.m_tn2.Play(() => { Over2(pos); });

                break;
            case 3:
                UIPage.m_en3.visible = true;
                UIPage.m_en3.url = GetUrl(info);

                if (UIPage.m_tn3.playing)
                {
                    UIPage.m_tn3.Stop();
                }
                UIPage.m_tn3.Play(() => { Over3(pos); });


                break;
            case 4:
                UIPage.m_en4.visible = true;
                UIPage.m_en4.url = GetUrl(info);

                if (UIPage.m_tn4.playing)
                {
                    UIPage.m_tn4.Stop();
                }
                UIPage.m_tn4.Play(() => { Over4(pos); });

                break;
            case 5:
                UIPage.m_en5.visible = true;
                UIPage.m_en5.url = GetUrl(info);

                if (UIPage.m_tn5.playing)
                {
                    UIPage.m_tn5.Stop();
                }
                UIPage.m_tn5.Play(() => { Over5(pos); });

                break;
            case 6:
                UIPage.m_en6.visible = true;
                UIPage.m_en6.url = GetUrl(info);

                if (UIPage.m_tn6.playing)
                {
                    UIPage.m_tn6.Stop();
                }
                UIPage.m_tn6.Play(() => { Over6(pos); });

                break;
            case 7:
                UIPage.m_en7.visible = true;
                UIPage.m_en7.url = GetUrl(info);
                Debug.Log("UIPage.m_en7.visible"+ UIPage.m_en7.visible);
                if (UIPage.m_tn7.playing)
                {
                    UIPage.m_tn7.Stop();
                }
                UIPage.m_tn7.Play(() => { Over7(pos); });

                break;
            default:
                break;
        }
    }

    private void Over7(int pos)
    {
        UIPage.m_tn7.PlayReverse(() => { HideEn(pos); });
    }
    private void Over6(int pos)
    {
        UIPage.m_tn6.PlayReverse(() => { HideEn(pos); });
    }
    private void Over5(int pos)
    {
        UIPage.m_tn5.PlayReverse(() => { HideEn(pos); });
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
            case 5:
                UIPage.m_en5.visible = false;
                break;
            case 6:
                UIPage.m_en6.visible = false;
                break;
            case 7:
                UIPage.m_en7.visible = false;
                break;
            default:
                break;
        }
    }

    public void ShowTxt(SmallChatVO smallChatVO)
    {
        //if (tween != null)
        //{
        //    tween.Kill();
        //}

        int index = 8;
        if (CacheManager.ClassRoomPlayers != null)
        {
            foreach (PlayerSimpleData item in CacheManager.TablePlayers)
            {
                index--;
                if (item == null)
                {
                    continue;
                }
                if (smallChatVO.UserId == item.userId)
                {
                    ShowTxt(index, smallChatVO.Info);
                    int pos = index;
                    
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
            case 5:
                UIPage.m_t5.visible = false;
                break;
            case 6:
                UIPage.m_t6.visible = false;
                break;
            case 7:
                UIPage.m_t7.visible = false;
                break;
            default:
                break;
        }
    }

    public void ShowTxt(int pos, string info)
    {
        //Debug.LogError("座位pos：" + pos + "消息" + info);
        Debug.Log("UIpage=" + UIPage);
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
            case 5:
                UIPage.m_t5.visible = true;
                GRichTextField tf5 = UIPage.m_txt5.asRichTextField;
                tf5.emojies = _emojies;
                tf5.text = UBBParser.inst.Parse(info);//消息内容
                UIPage.m_n5.height = UIPage.m_txt5.textHeight + 8;
                UIPage.m_n5.width = UIPage.m_txt5.textWidth + 8;
                break;
            case 6:
                UIPage.m_t6.visible = true;
                GRichTextField tf6 = UIPage.m_txt6.asRichTextField;
                tf6.emojies = _emojies;
                tf6.text = UBBParser.inst.Parse(info);//消息内容
                UIPage.m_n6.height = UIPage.m_txt6.textHeight + 8;
                UIPage.m_n6.width = UIPage.m_txt6.textWidth + 8;
                break;
            case 7:
                UIPage.m_t7.visible = true;
                GRichTextField tf7 = UIPage.m_txt7.asRichTextField;
                tf7.emojies = _emojies;
                tf7.text = UBBParser.inst.Parse(info);//消息内容
                UIPage.m_n7.height = UIPage.m_txt7.textHeight + 8;
                UIPage.m_n7.width = UIPage.m_txt7.textWidth + 8;
                break;
            default:
                break;
        }
    }



}
