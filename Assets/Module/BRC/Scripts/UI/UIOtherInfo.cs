using Info;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using FairyGUI;

/// <summary>
/// 其他人的信息面板
/// </summary>
public class UIOtherInfo : WTUIPage<UI_otherInfo, UserInfoCtrl>
{

    private PlayerSimpleData otherPlayerData;
    public Action<int, int,int> ActionGif;

    public UIOtherInfo() : base(UIType.PopUp, UIMode.DoNothing, R.UI.INFO)
    {
    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
        UIPage.m_btn_flower.onClick.Add(() => { GifOnClick(0); });
        UIPage.m_btn_cheers.onClick.Add(() => { GifOnClick(1); });
        UIPage.m_btn_kiss.onClick.Add(() => { GifOnClick(2); });
        UIPage.m_btn_egg.onClick.Add(() => { GifOnClick(3); });
        UIPage.m_btn_shoe.onClick.Add(() => { GifOnClick(4); });
        UIPage.m_btn_bomb.onClick.Add(() => { GifOnClick(5); });
    }
    private void GifOnClick(int emojiId)
    {
        if (CacheManager.banker.userId == CacheManager.gameData.userId)
        {
            Debug.Log("庄家不可发送收费表情");
            BaseCanvas.GetController<MessageCtrl>().Show("你当前不可以发送表情");
            return;
        }
      
        ActionGif.Invoke(emojiId, otherPlayerData.userId, CacheManager.RunRoomId);
        base.Hide();
    }

    public void Init(PlayerSimpleData playerSimpleData)
    {
        otherPlayerData = playerSimpleData;
        if (playerSimpleData != null)
        {
            UIPage.m_text_nickname.text = playerSimpleData.nickName;
            UIPage.m_text_id.text = playerSimpleData.userId.ToString();
            UIPage.m_text_gold.text = ToolClass.LongConverStr(playerSimpleData.coins);

            UIPage.m_head.texture = new NTexture(playerSimpleData.headIcon);

            if (playerSimpleData.userId == 100000)
            {
                UIPage.m_head.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_SYSTEM));
            }
            UIPage.m_c1.SetSelectedIndex(playerSimpleData.roleId);
            UIPage.m_text_level.text = playerSimpleData.lv + "(" + ToolClass.Grading(CacheManager.gameData.playerLevel) + ")";
            UIPage.m_text_masonry.text = playerSimpleData.crystals.ToString();
            UIPage.m_text_sign.text = playerSimpleData.sign;
            UIPage.m_text_shengNum.text = playerSimpleData.victoryNum.ToString();
            UIPage.m_text_fuNum.text = playerSimpleData.failureNum.ToString();


            switch (playerSimpleData.vipLv)
            {
                case 0: UIPage.m_vip.texture = null; break;
                case 1: UIPage.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP1)); break;
                case 2: UIPage.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP2)); break;
                case 3: UIPage.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP3)); break;
                case 4: UIPage.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP4)); break;
                case 5: UIPage.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP5)); break;
                default:
                    UIPage.m_vip.texture = null;
                    break;
            }
        }
        else
        {
            Debug.LogError("该座位玩家为空");
        }
    }
}