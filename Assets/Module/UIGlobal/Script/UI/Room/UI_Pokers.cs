/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_Pokers : GComponent
	{
		public GImage m_card_back1;
		public GImage m_card_back2;
		public GImage m_card_back3;
		public GTextField m_text_gold0;
		public GTextField m_text_gold1;
		public GTextField m_text_gold2;
		public GTextField m_text_gold3;
		public UI_cards m_cards0;
		public UI_cards m_cards1;
		public UI_cards m_cards2;
		public UI_cards m_cards3;
		public UI_cards m_cards4;
		public GLoader m_CardType0;
		public GLoader m_CardType1;
		public GLoader m_CardType2;
		public GLoader m_CardType3;
		public GLoader m_CardType4;
		public GLoader m_winordef0;
		public GLoader m_winordef1;
		public GLoader m_winordef2;
		public GLoader m_winordef3;
		public Transition m_CardsAnim0;
		public Transition m_CardsAnim1;
		public Transition m_CardsAnim2;
		public Transition m_CardsAnim3;
		public Transition m_CardsAnim4;

		public const string URL = "ui://es6hjd4tfkhrxz3";

		public static UI_Pokers CreateInstance()
		{
			return (UI_Pokers)UIPackage.CreateObject("Room","Pokers");
		}

		public UI_Pokers()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_card_back1 = (GImage)this.GetChildAt(0);
			m_card_back2 = (GImage)this.GetChildAt(1);
			m_card_back3 = (GImage)this.GetChildAt(2);
			m_text_gold0 = (GTextField)this.GetChildAt(3);
			m_text_gold1 = (GTextField)this.GetChildAt(4);
			m_text_gold2 = (GTextField)this.GetChildAt(5);
			m_text_gold3 = (GTextField)this.GetChildAt(6);
			m_cards0 = (UI_cards)this.GetChildAt(7);
			m_cards1 = (UI_cards)this.GetChildAt(8);
			m_cards2 = (UI_cards)this.GetChildAt(9);
			m_cards3 = (UI_cards)this.GetChildAt(10);
			m_cards4 = (UI_cards)this.GetChildAt(11);
			m_CardType0 = (GLoader)this.GetChildAt(12);
			m_CardType1 = (GLoader)this.GetChildAt(13);
			m_CardType2 = (GLoader)this.GetChildAt(14);
			m_CardType3 = (GLoader)this.GetChildAt(15);
			m_CardType4 = (GLoader)this.GetChildAt(16);
			m_winordef0 = (GLoader)this.GetChildAt(17);
			m_winordef1 = (GLoader)this.GetChildAt(18);
			m_winordef2 = (GLoader)this.GetChildAt(19);
			m_winordef3 = (GLoader)this.GetChildAt(20);
			m_CardsAnim0 = this.GetTransitionAt(0);
			m_CardsAnim1 = this.GetTransitionAt(1);
			m_CardsAnim2 = this.GetTransitionAt(2);
			m_CardsAnim3 = this.GetTransitionAt(3);
			m_CardsAnim4 = this.GetTransitionAt(4);
		}
	}
}