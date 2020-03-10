using FairyGUI;
using Guaguale;
using System;
using System.Collections.Generic;
using UnityEngine;
 
using WT.UI;

public class UIGGLGame : WTUIPage<UI_GglGame, GGLCtrl> 
{
    public Action<int, int> showBugMenu;
    public Action action_reward;

    private bool isJiShu = false;//是否是急速
    private bool isKaiJiangState = false;// 是否是刮奖状态
    private int index = 0;

    private GameObject gglMask;

    public static bool isStartGgl = false;
    public UIGGLGame() : base(UIType.PopUp, UIMode.DoNothing, R.UI.GUAGUALE)
    {

    }
    public void SetState(bool isGuaJiang)
    {
        isKaiJiangState = isGuaJiang;
    }
    private bool GetState()
    {
        return isKaiJiangState;
    }
    public override void Awake()
    {
        gglMask = FileIO.LoadPrefab(R.Prefab.GGL);

        UIPage.m_button_back.onClick.Add(()=> {
            ClickBack();           
        });
        UIPage.m_btn_jiShu.onClick.Add(() =>
        {
            isJiShu = !isJiShu;
            if (isJiShu)
            {
                UIPage.m_btn_jiShu.m_button.selectedIndex = 1;
            }
        });

        UIPage.m_btn_money.visible = false;
        UIPage.m_btn_money.draggable = true;
        UIPage.onTouchBegin.Add(() =>
        {
            if (GetState())
            {
                UIPage.m_btn_money.visible = true;
            }
        });
        UIPage.onTouchEnd.Add(() =>
        {
            if (GetState())
            {
                UIPage.m_btn_money.visible = false;
            }
        });

        UIPage.m_btn_MyBuy.onClick.Add(() =>
        {
            showBugMenu.Invoke(1, index);
        });
        UIPage.m_Btn_OneBuy.onClick.Add(() =>
        {
            showBugMenu.Invoke(2, index);
        });

        UIPage.m_btn_reward.onClick.Add(()=> {
            ClickReward();
        });


        window.rotation = -90;
        Vector2 scale = window.scale;
        window.SetScale(scale.y, scale.x);
        window.y = window.width * scale.y;
    }

    private void ClickBack()
    {
        BaseCanvas.StopBGM();
        BaseCanvas.PlayBGM(R.AudioClip.GAME_BGM);
        if (gglMask != null)
        GameObject.Destroy(gglMask);
        Hide();
    }

    private void ClickReward()
    {
        if (gglMask != null) UnityEngine.Object.Destroy(gglMask);
        isStartGgl = false;
        action_reward();

        GameObject obj = GameObject.Find("AllCameras/BrushCamera");
        Camera camera = obj.GetComponent<Camera>();
        camera.targetTexture.Release();

        foreach (var item in DrawMask.GetAllDestroy())
        {
            GameObject.Destroy(item);
        }
        DrawMask.ClearDestroy();
    }

    public void SetGameIndex(int index)
    {
        this.index = index;
    }


    public void SetQiInfo(List<int> list_lucky, List<GGLLotteryChessVO> list_ggl,int money)
    {
        if (!isActive())
        {
            return;
        }
         
        UIPage.m_c1.selectedIndex = 1;

        UIPage.m_loader_qizhi1.texture = new NTexture(FileIO.LoadSprite(GetPicturePath(list_lucky[0])));
        UIPage.m_loader_qizhi2.texture = new NTexture(FileIO.LoadSprite(GetPicturePath(list_lucky[1])));
 
        for (int i = 0; i < list_ggl.Count; i++)
        {
            UI_QiZhiItem qiZi = UIPage.GetChild("qizhiItem" + (i + 1)) as UI_QiZhiItem;
            qiZi.m_c1.selectedIndex = 0;
       
            qiZi.m_icon.texture = new NTexture(FileIO.LoadSprite(GetPicturePath(list_ggl[i].chessId)));
            qiZi.m_txt_money.text = "$" + list_ggl[i].money;
            if (list_lucky[0] == list_ggl[i].chessId || list_lucky[1] == list_ggl[i].chessId) {
                //红色圈圈
                qiZi.m_c1.selectedIndex = 1;
            }
        }
         
        if (UIPage.m_btn_jiShu.m_button.selectedIndex == 1)//急速
        {
            action_reward();
        }
        else
        {
            gglMask = FileIO.LoadPrefab(R.Prefab.GGL);
            gglMask = UnityEngine.Object.Instantiate(gglMask);
             
            Vector2 scale = window.scale;

            gglMask.transform.localScale = new Vector3(scale.y, scale.x,1);
            //Debug.Log("scaleX:" + scale.x+ ",scaleY:"+ scale.y);
            //gglMask.transform.localScale = new Vector3(scaleY, scaleX, 1);


            isStartGgl = true;
        }
    }
    /// <summary>
    /// CHESS_兵   CHESS_红炮 CHESS_红车 CHESS_红马 CHESS_红相  CHESS_红士
    /// CHESS_帅   CHESS_卒 
    /// CHESS_黑炮 CHESS_黑车 CHESS_黑马 CHESS_黑相  CHESS_黑士 CHESS_将  
    /// </summary>
    /// <param name="cardId"></param>
    /// <returns></returns>

    private int GetPicturePath(int cardId)
    {
        switch (cardId)
        {
            case 0: return R.SpritePack.GGL_XIANGQIHB;
            case 1: return R.SpritePack.GGL_XIANGQIHP;
            case 2: return R.SpritePack.GGL_XIANGQIHJ;
            case 3: return R.SpritePack.GGL_XIANGQIHM;
            case 4: return R.SpritePack.GGL_XIANGQIHX;
            case 5: return R.SpritePack.GGL_XIANGQIHS;
            case 6: return R.SpritePack.GGL_XIANGQIHSHUAI;
            case 7: return R.SpritePack.GGL_XIANGQIHEIZ;
            case 8: return R.SpritePack.GGL_XIANGQIHEIP;
            case 9: return R.SpritePack.GGL_XIANGQIHEIJU;
            case 10: return R.SpritePack.GGL_XIANGQIHEIMA;
            case 11: return R.SpritePack.GGL_XIANGQIHEIXIANG;
            case 12: return R.SpritePack.GGL_XIANGQIHEISHI;
            case 13: return R.SpritePack.GGL_XIANGQIHEIJIANG;

        }
        return -1;
    }

    internal void ShowReward0()
    {
        UIPage.m_c2.selectedIndex = 1;
    }

    internal void ChangeToGame()
    {
        UIPage.m_c1.selectedIndex = 0;
    }

    public override void Refresh()
    {
        WTUIPage.ShowPage<UIGlobalNotic>().SetPosition(32 + 50,480 -  82).SetRotate(-90);

       

        UIPage.m_c1.selectedIndex = 0;
        GameObject obj = GameObject.Find("AllCameras/BrushCamera");
        Camera camera = obj.GetComponent<Camera>();
        camera.targetTexture.Release();
        RefreshTextGold();

        Debug.Log("BaseCanvas.GetController<GGLCtrl>().GameIndex:"+ BaseCanvas.GetController<GGLCtrl>().GameIndex);
        switch (BaseCanvas.GetController<GGLCtrl>().GameIndex)
        {
            case 0:
                UIPage.m_txt_title.text = "1千/";
                break;

            case 1:
                UIPage.m_txt_title.text = "1万/";
                break;

            case 2:
                UIPage.m_txt_title.text = "10万/";
                break;

            default:
                break;
        }
    }

    public void RefreshTextGold()
    {
        UIPage.m_c2.selectedIndex = 0;
        UIPage.m_txt_money.text = CacheManager.gameData.coins+"";
    }
}