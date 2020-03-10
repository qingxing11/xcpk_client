using Chat;
using FairyGUI;
using Notice;
using Set;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIGlobalNotic : WTUIPage<UI_GlobalNotice, GlobalNoticCtrl>
{
    public UIGlobalNotic() : base(UIType.PopUp, UIMode.DoNothing, R.UI.NOTICE)
    {
    }
     
    public override void Awake()
    {
        
    }
  
    private List<HornInfoVO> infoList = new List<HornInfoVO>();

    public void NoticPlay(HornInfoVO vo)
    {
        infoList.Add(vo);
        PlayAll();
    }

    private void PlayAll()
    {
        if (UIPage.m_t1.playing || UIPage.m_t2.playing)
        {
            PlayAllSecond();//再来消息
            return;
        }

        if (UIPage.m_t2.playing)
        {
            PlayAllOne();//来消息
            return;
        }

        if (infoList == null || infoList.Count == 0)
        {
            ResetNotie();
            return;
        }
        
        Movie();
    }

    /// <summary>
    /// 动效1
    /// </summary>
    private void Movie()
    {
        UIPage.visible = true;
        UIPage.m_n5.visible = true;
        UIPage.m_n8.visible = false;

        HornInfoVO vo = infoList[0];
        Sprite sp = null;
        if (vo.vipLv > 0)
        {
            string vipName = "GJC/Player/SpritePack/VIP2/vip" + vo.vipLv;
            sp = FileIO.LoadSprite(vipName);
        }
        if (sp != null)
        {
            UIPage.m_n4.texture = new NTexture(sp.texture);
        }

        string info;
        if (vo.nikeName == "系统")
        {
            info = "[color=#FF0000]" + vo.nikeName + ":" + "[/color]" + vo.info;
        }
        else if (vo.role == 0)
        {
            info = "[color=##5888B0]" + vo.nikeName + ":" + "[/color]" + vo.info;
        }
        else
        {
            info = "[color=#BB7493]" + vo.nikeName + ":" + "[/color]" + vo.info;
        }
        //Debug.Log("滚动条收到消息：" + info + ",等级：" + vo.vipLv);

        UIPage.m_n2.text = info;
        infoList.RemoveAt(0);

        float w0 = 385 + UIPage.m_n3.width;
        float w = UIPage.m_n2.textWidth + UIPage.m_n3.width;
        Debug.Log("UIPage.m_n2.textWidth="+ UIPage.m_n2.textWidth+ ",UIPage.m_n3.width="+ UIPage.m_n3.width);
        float time = 385 / w;
        UIPage.m_t1.SetValue("over", -w, 0);
        //UIPage.m_t1.timeScale = 0.5f;// time > 1 ? 1 : time;
        Debug.Log("滚动条收到消息：t1 play");

        //float def_time = UIPage.m_t1.GetDuration();
        float offer = w0/ w;
        Debug.Log("offer=" + offer);
        UIPage.m_t1.timeScale = offer;// time > 1 ? 1 : time;
        //UIPage.m_t1.SetDuration(offer*8);
        UIPage.m_t1.Play(() => {
            Debug.Log("滚动条收到消息：t1 play end");
            UIPage.visible = false;
            UIPage.m_n5.visible = false;
            PlayAll();
        });
    }

    /// <summary>
    ///重置小广播面板
    /// </summary>
    private void ResetNotie()
    {
        UIPage.visible = false;
        UIPage.m_n2.text = "";
        UIPage.m_n4.texture = null;
        UIPage.m_n6.text = "";
        UIPage.m_n7.texture = null;
    }

    /// <summary>
    /// 处理动效2
    /// </summary>
    private void CancelMovieTwo()
    {
        if (UIPage.m_t2.playing)
        {
            UIPage.m_n8.visible = false;
            UIPage.m_n6.text = "";
            UIPage.m_n7.texture = null;
            UIPage.m_t2.Stop();
        }
    }

    /// <summary>
    /// 处理动效1
    /// </summary>
    private void CancelMovie1()
    {
        if (UIPage.m_t1.playing)
        {
            UIPage.m_n5.visible = false;
            UIPage.m_n2.text = "";
            UIPage.m_n4.texture = null;
            UIPage.m_t1.Stop();
        }
    }

    /// <summary>
    /// 播放动效1
    /// </summary>
    private void PlayAllOne()
    {
        CancelMovieTwo();
        Movie();
    }

    private void PlayAllSecond()
    {
        CancelMovie1();
        CancelMovieTwo();
        Movie2();
    }

    /// <summary>
    /// 动效2
    /// </summary>
    private void Movie2()
    {
        UIPage.visible = true;
        UIPage.m_n8.visible = true;
        UIPage.m_n5.visible = false;

        HornInfoVO vo = infoList[0];

        if (vo.vipLv > 0)
        {
            string vipName = "GJC/Player/SpritePack/VIP2/vip" + vo.vipLv;
            Sprite sp = FileIO.LoadSprite(vipName);
            if (sp != null)
            {
                UIPage.m_n7.texture = new NTexture(sp.texture);
            }
        }
         
        string info;
       
        if (vo.nikeName == "系统")
        {

            info = "[color=#FF0000]" + vo.nikeName + ":" + "[/color]" + vo.info;
        }
        else if (vo.role == 0)
        {
            info = "[color=##5888B0]" + vo.nikeName + ":" + "[/color]" + vo.info;
        }
        else
        {
            info = "[color=#BB7493]" + vo.nikeName + ":" + "[/color]" + vo.info;
        }
 
        info = info.Replace("\n", "");
        UIPage.m_n6.text = info;
        infoList.RemoveAt(0);

        //float timeScale = 373 / UIPage.m_n6.textWidth;
        float w = UIPage.m_n6.textWidth;
        UIPage.m_t2.SetValue("over", -w, 0);

        UIPage.m_t2.timeScale = 373/ w;
        UIPage.m_t2.SetHook("upover", UpOverCallBack);
        Debug.Log("滚动条收到消息：t2 play");
        UIPage.m_t2.Play(() => {
            Debug.Log("滚动条收到消息：t2 play end");
            UIPage.visible = false;
            UIPage.m_n8.visible = false;

            PlayAll();
        });
    }
        
    private void UpOverCallBack()
    {
        Debug.Log("滚动条收到消息：t2 upover UpOverCallBack");

        //float timeScale = 373 / UIPage.m_n6.textWidth;
      
        //float w = UIPage.m_n6.textWidth + UIPage.m_n3.width;
        //Debug.Log("UpOverCallBack：UIPage.m_n6.text=" + UIPage.m_n6.text + ",w="+ w);
        //Debug.Log("UpOverCallBack：UIPage.m_n6.textWidth=" + UIPage.m_n6.textWidth + ",timeScale=" + timeScale);
        //UIPage.m_t2.SetValue("over", -w, 0);

        //UIPage.m_t2.timeScale = 1;// timeScale/* > 1 ? 1 : timeScale*/;//数越大越快，越小越慢
    }
}