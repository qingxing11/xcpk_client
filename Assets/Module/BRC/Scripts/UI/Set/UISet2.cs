using Set;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UISet2 : WTUIPage<UI_set2, SetCtrl>
{
    public Action<int> ActionSoundValue;     //设置音效音量大小
    public Action<int> ActionMusicValue;     //设置音乐音量大小

    public Action<bool, int> ActionMusic;
    public UISet2() : base(UIType.Dialog, UIMode.HideOther, R.UI.SET)
    {

    }
    public override void Awake()
    {
        UIPage.m_Slider_sound.onChanged.Add(OnSoundValueClick);
        UIPage.m_Slider_music.onChanged.Add(OnMusicValueClick);
        UIPage.m_btn_sound.onClick.Add(BtnSoundOnClick);//音效开关
        UIPage.m_btn_music.onClick.Add(BtnMusicOnClick);//音乐开关
        UIPage.m_btn_close.onClick.Add(base.Hide);
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
            PlayerPrefs.SetInt("sound", 0);
        }
    }
    private void BtnMusicOnClick()
    {
        if (CacheManager.PlayMusic)
        {
            CacheManager.PlayMusic = false;
            UIPage.m_c_music.SetSelectedIndex(1);
            PlayerPrefs.SetInt("music", 1);
            ActionMusic?.Invoke(false, 0);
        }
        else
        {
            CacheManager.PlayMusic = true;
            UIPage.m_c_music.SetSelectedIndex(0);
            PlayerPrefs.SetInt("music", 0);
            ActionMusic?.Invoke(true, (int)UIPage.m_Slider_music.value);
        }
    }

    public override void Refresh()
    {
        UIPage.m_Slider_sound.value = CacheManager.soundValue * 100;
        UIPage.m_Slider_music.value = CacheManager.musicValue * 100;

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
    }
}