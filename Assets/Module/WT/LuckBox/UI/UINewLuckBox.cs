using WT.UI;
using UnityEngine;
using System.Collections.Generic;
using NetLoading;
using NewLoding;
using Classic;
using System;

public class UINewLuckBox : WTUIPage<UI_NewLuckyBoxGif, LuckyBoxCtrl> 
{
    
    
    public UINewLuckBox() : base(UIType.Dialog, UIMode.DoNothing, R.UI.CLASSIC)
    {

    }
     
    public override void Awake()
    {
        
    }

    public override void Refresh()
    {
       
        //UIPage.m_luckbox_pos.selectedIndex = 5;

        object[] itemAndPos = (object[])data;
        Attach attach = (Attach)itemAndPos[0];
        int pos = (int)itemAndPos[1];

        UI_NewLuckyBoxOpen ui = GetBoxOpen(pos);
        Debug.Log("Show UINewLuckBox.pos:"+pos);
        UIPage.m_luckbox_pos.selectedIndex = pos;
       

        switch (attach.id)
        {
            case 0:
                ui.m_luckbox_open.selectedIndex = 0;
                ui.m_goldNum.text = "金币+"+attach.num;
                break;

            case 1:
                ui.m_luckbox_open.selectedIndex = 3;
                break;

            case 2:
                ui.m_luckbox_open.selectedIndex = 2;
                break;

            case 3:
                ui.m_luckbox_open.selectedIndex = 1;
                break;

            default:
                break;
        }
        ui.m_t0.Play(()=> {
            Hide();
        });

        if (CacheManager.selfPos == pos)
        {
            switch (attach.id)
            {
                case 0:
                    CacheManager.gameData.coins += attach.num;
                    BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI);
                    break;
                case 1:
                    CacheManager.gameData.addTime += 1;
                    break;
                case 2:
                    CacheManager.gameData.robPos += 1;
                    break;
                case 3:
                    CacheManager.gameData.modifyNickName += 1;
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (attach.id == 0)
            {
                CacheManager.ClassRoomPlayers[pos].coins += attach.num;
            }
        }

        GetUIPage<UIClassicRoom>().UpdateUserCoins(pos);
    }

    private UI_NewLuckyBoxOpen GetBoxOpen(int pos)
    {
        UI_NewLuckyBoxOpen ui = null;
        switch (pos)
        {
            case 0://自己
                ui = UIPage.m_pos0;
                break;

            case 1:
                ui = UIPage.m_pos1;
                break;

            case 2:
                ui = UIPage.m_pos2;
                break;

            case 3:
                ui = UIPage.m_pos3;
                break;

            case 4:
                ui = UIPage.m_pos4;
                break;

            default:
                break;
        }
        return ui;
    }
}