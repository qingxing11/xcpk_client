using FairyGUI;
using Set;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using WT.UI;
/// <summary>
/// 绑定手机
/// </summary>
public class UIBindPhone : WTUIPage<UI_bdsj, SetCtrl>
{
    public Action<string> ActionGetCode;
    public Action<int> ActionBind;
    public UIBindPhone() : base(UIType.Dialog, UIMode.HideOther, R.UI.SET)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
        UIPage.m_btn_send.onClick.Add(BtnSendOnClick);
        UIPage.m_btn_ok.onClick.Add(BtnOnClick);
    }

    private void BtnSendOnClick()
    {
        //需要检查手机号码
        ActionGetCode?.Invoke(UIPage.m_text_phoneNum.text);
    }

    private void BtnOnClick()
    {
        int codeNum = 0;
        string phoneNumStr = UIPage.m_text_phoneNum.text;
        try
        {
            codeNum = int.Parse(UIPage.m_text_code.text);
        }
        catch (Exception)
        {
            Debug.LogError("验证码转换错误");
        }
        ActionBind?.Invoke(codeNum);
    }
    public IEnumerator GetCode(int timer)
    {
        UIPage.m_text_timer.visible = true;
        UIPage.m_btn_send.grayed = true ;
        UIPage.m_btn_send.touchable = false;
        while (timer >= 0)
        {
            UIPage.m_text_timer.text = (timer--).ToString();
            yield return new WaitForSeconds(1f);
        }
        UIPage.m_text_timer.visible = false;
        UIPage.m_btn_send.grayed = false;
        UIPage.m_btn_send.touchable = true;
        yield return null;
    }
}
