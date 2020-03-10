using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using Set;
using FairyGUI;

public class UISet : WTUIPage<UI_set, SetCtrl>
{
    public Action<bool,int> ActionMusic;

    public Action ActionUpdatePwd;      //修改密码
    public Action ActionFindPwd;        //找回密码
    public Action ActionBindPhone;      //绑定手机
    public Action ActionChangeAcc;      //切换账号
    public Action ActionPerfectAcc;     //完善账号
    public Action<int> ActionSoundValue;     //设置音效音量大小
    public Action<int> ActionMusicValue;     //设置音乐音量大小
    public Action<bool> ActionBullet;

    public UISet() : base(UIType.Dialog, UIMode.HideOther, R.UI.SET)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
        UIPage.m_btn_sound.onClick.Add(BtnSoundOnClick);//音效开关
        UIPage.m_btn_music.onClick.Add(BtnMusicOnClick);//音乐开关
        UIPage.m_btn_bulltkai.onClick.Add(BtnBullerOnClickKai);  //弹幕开
        UIPage.m_btn_bulltguan.onClick.Add(BtnBullerOnClickGuan);//弹幕关
        UIPage.m_btn_XGMM.onClick.Add(()=> { ActionUpdatePwd?.Invoke(); });
        UIPage.m_btn_ZHMM.onClick.Add(() => { ActionFindPwd?.Invoke(); });
        UIPage.m_btn_BDSJ.onClick.Add(() => { ActionBindPhone?.Invoke(); });
        UIPage.m_btn_QHZH.onClick.Add(() => { ActionChangeAcc?.Invoke(); });
        UIPage.m_btn_WSZH.onClick.Add(() => { ActionPerfectAcc?.Invoke(); });
        UIPage.m_Slider_sound.onChanged.Add(OnSoundValueClick);
        UIPage.m_Slider_music.onChanged.Add(OnMusicValueClick);

        if (CacheManager.Bullte)
        {
            UIPage.m_c_bullet.SetSelectedIndex(0);
        }
        else
        {
            UIPage.m_c_bullet.SetSelectedIndex(1);
        }
    }

    private void OnSoundValueClick()
    {
        ActionSoundValue?.Invoke((int)UIPage.m_Slider_sound.value);
    }
    private void OnMusicValueClick()
    {
        ActionMusicValue?.Invoke((int)UIPage.m_Slider_music.value);
    }

    private void BtnSoundOnClick()
    {
        if (CacheManager.PlaySound)
        {
            CacheManager.PlaySound = false;
            UIPage.m_c_sound.SetSelectedIndex(1);
            PlayerPrefs.SetInt("sound",1);
        }
        else
        {
            CacheManager.PlaySound = true;
            UIPage.m_c_sound.SetSelectedIndex(0);
            PlayerPrefs.SetInt("sound",0);
        }
    }
    private void BtnMusicOnClick()
    {
        if (CacheManager.PlayMusic)
        {
            CacheManager.PlayMusic = false;
            UIPage.m_c_music.SetSelectedIndex(1);
            PlayerPrefs.SetInt("music", 1);
            ActionMusic?.Invoke(false,0);
        }
        else
        {
            CacheManager.PlayMusic = true;
            UIPage.m_c_music.SetSelectedIndex(0);
            PlayerPrefs.SetInt("music",0);
            ActionMusic?.Invoke(true,(int)UIPage.m_Slider_music.value);
        }
    }
    private void BtnBullerOnClickKai()
    {
        UIPage.m_c_bullet.SetSelectedIndex(0);

        ActionBullet?.Invoke(true);
    }
    private void BtnBullerOnClickGuan()
    {
        UIPage.m_c_bullet.SetSelectedIndex(1);
        ActionBullet?.Invoke(false);
    }
    public override void Refresh()
    {
        UIPage.m_Slider_music.value = CacheManager.musicValue * 100;
        UIPage.m_Slider_sound.value = CacheManager.soundValue * 100;
        if (CacheManager.gameData.mobile_num != null && CacheManager.gameData.mobile_num.Length == 11)
        {
            UIPage.m_text_phoneNum.text = CacheManager.gameData.mobile_num;
            UIPage.m_text_phoneNum.touchable = false;
        }

        if (CacheManager.PlayMusic)
        {
            UIPage.m_c_music.SetSelectedIndex(0);
        }
        else
        {
            UIPage.m_c_music.SetSelectedIndex(1);
        }
        if (CacheManager.PlaySound)
        {
            UIPage.m_c_sound.SetSelectedIndex(0);
        }
        else
        {
            UIPage.m_c_sound.SetSelectedIndex(1);
        }

        UIPage.m_text_accound.text = CacheManager.gameData.account;
        if (!string.IsNullOrEmpty( CacheManager.gameData.mobile_num) )
        {
            UIPage.m_text_phoneNum.text = CacheManager.gameData.mobile_num;
        }
    }

    internal void Init(int index)
    {
        UIPage.m_c1.SetSelectedIndex(index);
    }
}
