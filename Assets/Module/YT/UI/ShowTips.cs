using SendRedEnvelope;
using WT.UI;

public   class ShowTips :  WTUIPage<UI_showTips, SendRedEnvelopeCtrl>
{
    public ShowTips() : base(UIType.Dialog, UIMode.DoNothing, R.UI.SENDREDENVELOPE)
    {
    }
    public override void Awake()
    {
        UIPage.m_txt_pop.visible = false;
    }

    public void ShowCoins(long coin)
    {
        UIPage.m_txt_pop.visible = true;
        UIPage.m_txt_pop.text = "金币+" +coin;
        UIPage.m_show.Play();
        BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI,1,false);
    }
}