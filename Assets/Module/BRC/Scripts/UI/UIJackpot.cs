using System.Collections;
using FairyGUI;
using UnityEngine;
using WT.UI;
using Room;

public class UIJackpot : WTUIPage<UI_jackpot, JackpotCtrl>
{
    public UIJackpot() : base(UIType.PopUp, UIMode.DoNothing, R.UI.ROOM)
    {
    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
    }
    public void Init(JackpotData jackpotData, long allJackPot)
    {
        if (jackpotData.allJackpot != 0)
        {
            UIPage.m_text_allcoins.text = ToolClass.LongConverStr(jackpotData.allJackpot);
        }
        else
        {
            UIPage.m_text_allcoins.text = ToolClass.LongConverStr(allJackPot);
        }

        UIPage.m_text_coins.text = ToolClass.LongConverStr(jackpotData.lastJackpot);
        UIPage.m_text_nickname.text = jackpotData.lastName;
        UIPage.m_text_cardType.text = getCardTypeString(jackpotData.jackpotType);
        UIPage.m_text_time.text = MyTimeUtil.TimeToString(jackpotData.jackpotTime).Substring(5, 11);
        //Debug.LogError(MyTimeUtil.TimeToString(jackpotData.jackpotTime));
        if(string.IsNullOrEmpty(jackpotData.lastHeadIconUrl))
        //if (jackpotData.lastHeadIcon == null || jackpotData.lastHeadIcon.Length <= 0)
        {
            UIPage.m_n4.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
        }
        else
        {
            //Texture2D texture2D = HelperClass.DecodeTexture2d(jackpotData.lastHeadIcon, 128, 128);
            Texture2D texture2D = CacheManager.GetHeadIcon(jackpotData.lastHeadIconUrl);
           
          
            UIPage.m_n4.texture = new NTexture(Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero));
        }
        if (jackpotData.list_pokers != null)
        {
            UIPage.m_card.visible = true;
            UIPage.m_card.m_n0.texture = new NTexture(Pokers.GetPokerFace(jackpotData.list_pokers[0].value));
            UIPage.m_card.m_n1.texture = new NTexture(Pokers.GetPokerFace(jackpotData.list_pokers[1].value));
            UIPage.m_card.m_n2.texture = new NTexture(Pokers.GetPokerFace(jackpotData.list_pokers[2].value));
        }
        else
        {
            UIPage.m_card.visible = false;
        }
    }

    public string getCardTypeString(int type)
    {
        switch (type)
        {
            case (int)CardTypeEnum.CardTypeEnum_豹子: return "豹子";
            case (int)CardTypeEnum.CardTypeEnum_顺金: return "顺金";
        }
        return "";
    }
}