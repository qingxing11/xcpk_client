using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using Info;
using FairyGUI;

/// <summary>
/// 自己的信息面板
/// </summary>
public class UISelfInfo : WTUIPage<UI_selfInfo, UserInfoCtrl>
{
    public Action<string> ActionUpdateNickName;  //修改昵称
    public Action<int> ActionUpdateGender;       //修改性别
    public Action<string> ActionEditorSign;
    public Action ActionEditorHead;
    public Action<string> ActionError;

    public UISelfInfo() : base(UIType.Dialog, UIMode.DoNothing, R.UI.INFO)
    {
    }

    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_btn_editorNickname.onClick.Add(EditorNicknameOnClick);
        UIPage.m_btn_editorSign.onClick.Add(() => { UIPage.m_text_sign.RequestFocus(); });//编辑签名
        UIPage.m_head.onClick.Add(() => { ActionEditorHead?.Invoke(); });      //编辑头像
        UIPage.m_text_sign.onFocusOut.Add(SignFocusOut);          //编辑签名失去焦点


        UIPage.m_updateQueren.m_c1.SetSelectedIndex(CacheManager.gameData.roleId);
        UIPage.m_updateQueren.m_btn_baocun.onClick.Add(OnSendClick);
        UIPage.m_updateQueren.m_btn_return.onClick.Add(() => { UIPage.m_c2.SetSelectedIndex(0); });
        UIPage.m_updateQueren.m_btn_gender0.onClick.Add(() =>
        {
            ActionUpdateGender?.Invoke(0);
            UIPage.m_updateQueren.m_c1.SetSelectedIndex(0);
        });
        UIPage.m_updateQueren.m_btn_gender1.onClick.Add(() =>
        {
            ActionUpdateGender?.Invoke(1);
            UIPage.m_updateQueren.m_c1.SetSelectedIndex(1);
        });




       
    }

    

    internal void Init(bool isCanUpdape)
    {
        UIPage.m_btn_editorNickname.visible = isCanUpdape;
    }

    private void OnSendClick()
    {
        string nickName = UIPage.m_updateQueren.m_text_nickname.text;
        string pattern = "^[a-zA-Z0-9\u4e00-\u9fa5]{2,6}$";

        if (!System.Text.RegularExpressions.Regex.IsMatch(nickName, pattern))
        {
            ActionError?.Invoke("昵称必须是2到6位的字母数字汉字组合");
            return;
        }

        ActionUpdateNickName?.Invoke(nickName );
        UIPage.m_c2.SetSelectedIndex(0);
    }

    private void EditorNicknameOnClick()
    {
        if (UIPage.m_c2.selectedIndex == 0)
        {
            UIPage.m_c2.SetSelectedIndex(1);
        }
    }

    private void SignFocusOut()
    {
        if (UIPage.m_text_sign.text != CacheManager.gameData.sign)
        {
            ActionEditorSign?.Invoke(UIPage.m_text_sign.text);
        }
    }
    /// <summary>
    /// 设置性别
    /// </summary>
    public void SetGender()
    {
        if (CacheManager.gameData.roleId == 0)     //男生
        {
            UIPage.m_c1.SetSelectedIndex(0);
        }
        else        //女
        {
            UIPage.m_c1.SetSelectedIndex(1);
        }
    }
    public void SetHead()
    {
        Debug.Log("CacheManager.gameData.headIcon:" + CacheManager.gameData.headIconUrl);
        if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
        {
            Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
            UIPage.m_head.texture = new NTexture(t2d);  //设置头像
        }
        else
        {
            if (CacheManager.gameData.roleId == 0)     //男生
            {
                UIPage.m_head.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
            }
            else        //女
            {
                UIPage.m_head.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
            }
        }
    }

    public void SetHead(Texture2D t2d)
    {
        UIPage.m_head.texture = new NTexture(t2d);
    }

    //public void SetHead(Texture2D texture)
    //{
    //    Debug.Log("设置玩家头像");
    //    UIPage.m_head.texture = new NTexture(texture);
    //}

    /// <summary>
    /// 设置个性签名签名
    /// </summary>
    public void SetSign()
    {
        UIPage.m_text_sign.text = CacheManager.gameData.sign;
    }
    public void SetNickNameAndGender()
    {
        UIPage.m_text_nickname.text = CacheManager.gameData.nickName;
        UIPage.m_c1.SetSelectedIndex(CacheManager.gameData.roleId);
        UIPage.m_updateQueren.m_text_nickname.text = CacheManager.gameData.nickName;
    }
    public void SetLevel()
    {
        UIPage.m_text_level.text = CacheManager.gameData.playerLevel+"("+ ToolClass.Grading(CacheManager.gameData.playerLevel)+")";
    }
    public void SetExp()
    {
        UIPage.m_slid.value = CacheManager.gameData.exp *100/ CacheManager.getCostExp(CacheManager.gameData.playerLevel);
        UIPage.m_text_exp.text = CacheManager.gameData.exp + "/" + CacheManager.getCostExp(CacheManager.gameData.playerLevel);
    }
    public void SetVip()
    {
        Sprite vipSprite = null;
        switch (CacheManager.gameData.vipLv)
        {
            case 1:vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP1);break;
            case 2: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP2); break;
            case 3: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP3); break;
            case 4: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP4); break;
            case 5: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP5); break;
            default:
                break;
        }
        if (CacheManager.gameData.vipLv > 0)
            UIPage.m_vip.texture = new NTexture(vipSprite);
        else
            UIPage.m_vip.texture = null;
    }
    public void SetCards()
    {
        UIPage.m_text_gaiming.text = CacheManager.gameData.modifyNickName.ToString();
        UIPage.m_text_qiangzuo.text = CacheManager.gameData.robPos.ToString();
        UIPage.m_text_addTime.text = CacheManager.gameData.addTime.ToString();
    }
    public override void Refresh()
    {

        SetNickNameAndGender();       //昵称
        UIPage.m_text_id.text = CacheManager.gameData.userId.ToString();    //id
        UIPage.m_text_account.text = CacheManager.gameData.account;         //账号
        UIPage.m_text_sign.text = CacheManager.gameData.sign;

        SetGender();//设置性别
        SetSign();  //设置签名


        SetHead();  //设置头像

        SetCards(); //设置卡片

        UIPage.m_text_gaiming.text = CacheManager.gameData.modifyNickName.ToString();
        UIPage.m_text_qiangzuo.text = CacheManager.gameData.robPos.ToString();
        UIPage.m_text_addTime.text = CacheManager.gameData.addTime.ToString();

        UIPage.m_text_coins.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
        UIPage.m_text_masonry.text = ToolClass.LongConverStr(CacheManager.gameData.crystals);//砖石
        UIPage.m_text_shengchang.text = CacheManager.gameData.victoryNum.ToString();
        UIPage.m_text_shuchang.text = CacheManager.gameData.failureNum.ToString();
        if ((CacheManager.gameData.victoryNum + CacheManager.gameData.failureNum) == 0)
            UIPage.m_text_shenglv.text = @"0%";
        else
            UIPage.m_text_shenglv.text = (CacheManager.gameData.victoryNum*100/(CacheManager.gameData.victoryNum+ CacheManager.gameData.failureNum)).ToString("0.0")+"%";
        SetLevel(); //设置等级
        SetExp();//设置经验
        SetVip();//设置vip等级


    }

    public void UpdateHead()
    {
        Debug.LogError("刷新头像");
    }
}