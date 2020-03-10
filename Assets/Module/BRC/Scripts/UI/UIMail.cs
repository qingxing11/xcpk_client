using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using Mail;
using FairyGUI;
using Newtonsoft;
public class UIMail : WTUIPage<UI_mail, MailCtrl>
{

    public Action<int> ActionReadMail;
    public Action<int> ActionGetAttach;
    public Action<int> ActionDelete;

    private int mailId=-1;

    private List<MailDataPO> userMailDataPOS;
    public UIMail() : base(UIType.PopUp, UIMode.DoNothing, R.UI.MAIL)
    {

    }

    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
        UIPage.m_btn_delete.onClick.Add(BtnOnClickDelete);
        UIPage.m_btn_get.onClick.Add(BtnOnClickGet);
    }

    internal void Init(List<MailDataPO> userMailDataPOS)
    {
        if (userMailDataPOS == null || userMailDataPOS.Count <= 0)
        {
            UIPage.m_list_mail.numItems = 0;
        }
        else
        {
            this.userMailDataPOS = userMailDataPOS;
            UIPage.m_list_mail.itemRenderer = SetIten;
            UIPage.m_list_mail.numItems = userMailDataPOS.Count;
        }
    }
    private void SetIten(int index, GObject item)
    {
        MailDataPO mailDataPO = userMailDataPOS[index];
        UI_item_mail uI_Item_Mail= (UI_item_mail)item;
        uI_Item_Mail.onClick.Add(() => { MailItemOnClick(mailDataPO); });
        if (mailDataPO.state == MailDataPO.STATE_已读)
        {
            uI_Item_Mail.m_c1.SetSelectedIndex(1);
        }
        else
        {
            uI_Item_Mail.m_c1.SetSelectedIndex(0);
        }
        uI_Item_Mail.m_text_time.text = mailDataPO.sendtime;
    }
    private void MailItemOnClick(MailDataPO mailDataPO)
    {
        this.mailId = mailDataPO.mailID;
        if(mailDataPO.state== MailDataPO.STATE_未读)
            ActionReadMail?.Invoke(mailDataPO.mailID);
        if (UIPage.m_c1.selectedIndex == 0)
            UIPage.m_c1.SetSelectedIndex(1);
        if (mailDataPO.attachState == MailDataPO.ATTACHSTATE_未领取)
        {
            Attach attach = JsonUtility.FromJson<Attach>(mailDataPO.attachContent);
            switch (attach.id)
            {
                case (int)LuckyType.VIP1: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_VIP1)); break;
                case (int)LuckyType.VIP2: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_VIP2)); break;
                case (int)LuckyType.VIP3: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_VIP3)); break;
                case (int)LuckyType.VIP4: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_VIP4)); break;
                case (int)LuckyType.VIP5: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_VIP5)); break;
                case (int)LuckyType.增时卡: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_ZENGSHI)); break;
                case (int)LuckyType.抢座卡: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_QIANGZUO)); break;
                case (int)LuckyType.改名卡: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_GAIMING)); break;
                case (int)LuckyType.金币: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_JINBI)); break;
                case (int)LuckyType.钻石: UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CHOUJIANG_ZHUANSHI)); break;
                default:
                    break;
            }
            UIPage.m_text_num.text = "X" + attach.num;
            UIPage.m_c2.SetSelectedIndex(0);
        }
        else if (mailDataPO.attachState == MailDataPO.ATTACHSTATE_已领取)
        {
            UIPage.m_c2.SetSelectedIndex(1);
        }
        UIPage.m_text_title.text = mailDataPO.title;
        UIPage.m_text_content.text = mailDataPO.content;
    }

    /// <summary>
    /// 删除邮件
    /// </summary>
    private void BtnOnClickDelete()
    {
        if(mailId!=-1)
        ActionDelete?.Invoke(this.mailId);
    }
    /// <summary>
    /// 领取附件
    /// </summary>
    private void BtnOnClickGet()
    {
        if (mailId != -1)
            ActionGetAttach?.Invoke(this.mailId);
    }

    internal void ReadAMail(int mailId)
    {
        for (int i = 0; i < userMailDataPOS.Count; i++)
        {
            MailDataPO mailDataPO = userMailDataPOS[i];
            if(mailId == mailDataPO.mailID)
            {
                mailDataPO.state = MailDataPO.STATE_已读;
                break;
            }
        }
        RefMailList();
    }
    internal void RemoveMail(int mailId)
    {
        for (int i = 0; i < userMailDataPOS.Count; i++)
        {
            MailDataPO mailDataPO = userMailDataPOS[i];
            if (mailId == mailDataPO.mailID)
            {
                userMailDataPOS.Remove(mailDataPO);
                break;
            }
        }
        RefMailList();
    }
    internal void GetAttach(int mailId)
    {
        for (int i = 0; i < userMailDataPOS.Count; i++)
        {
            MailDataPO mailDataPO = userMailDataPOS[i];
            if (mailId == mailDataPO.mailID)
            {
                mailDataPO.attachState = MailDataPO.ATTACHSTATE_已领取;
                UIPage.m_c2.SetSelectedIndex(1);
                break;
            }
        }
    }
    private void RefMailList()
    {
        if (userMailDataPOS == null || userMailDataPOS.Count <= 0)
        {
            UIPage.m_list_mail.numItems = 0;
        }
        else
        {
            UIPage.m_list_mail.itemRenderer = SetIten;
            UIPage.m_list_mail.numItems = userMailDataPOS.Count;
        }
    }
    public override void Refresh()
    {
        UIPage.m_c1.SetSelectedIndex(0);
    }
}
