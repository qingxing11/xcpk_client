using WT.UI;
using Guaguale;
using UnityEngine;
using System;
using System.Collections.Generic;

public class UIggl : WTUIPage<UI_GglMenu,GGLCtrl> 
{
    public Action<int> actionClickGame;

    public UIggl() : base(UIType.PopUp, UIMode.DoNothing, R.UI.GUAGUALE)
    {

    }



    public override void Awake()
    {
        base.Awake();
        
        UIPage.m_btn_game0.onClick.Add(()=> {
            actionClickGame(0);
            Debug.Log("game0");
        });

        UIPage.m_btn_game1.onClick.Add(() => {
            actionClickGame(1);
            Debug.Log("game1");
        });

        UIPage.m_btn_game2.onClick.Add(() => {
            actionClickGame(2);
            Debug.Log("game2");
        });

        UIPage.m_btn_exit.onClick.Add(()=> {
            
            BaseCanvas.StopBGM();
            BaseCanvas.PlayBGM(R.AudioClip.GAME_BGM);
            Hide();
        });
         
        window.rotation = -90;
        Vector2 scale = window.scale;
        window.SetScale(scale.y, scale.x);
        window.y = window.width * scale.y;
    }

    private List<HornInfoVO> infoList = new List<HornInfoVO>();
    public void NoticPlay(HornInfoVO vo)
    {
        infoList.Add(vo);
        PlayAll();
    }

    private void PlayAll()
    {
        //if (UIPage.m_.m_notice.m_t1.playing)
        //{
        //    PlayAllSecond();//再来消息
        //    return;
        //}
        //if (UIPage.m_room.m_notice.m_t2.playing)
        //{
        //    PlayAllOne();//再来消息
        //    return;
        //}

        //if (infoList == null || infoList.Count == 0)
        //{
        //    ResetNotie();
        //    return;
        //}
        //Movie();
    }

    public override void Refresh()
    {
         
        RefreshTextGold();
        BaseCanvas.PlayBGM(R.AudioClip.GGL_BG);
    }

    public void RefreshTextGold()
    {
        UIPage.m_text_gold.text = CacheManager.gameData.coins + "";
    }
}