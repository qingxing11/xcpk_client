/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_jackpot : GComponent
	{
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GTextField m_text_nickname;
		public GImage m_n5;
		public GLoader m_n4;
		public GTextField m_text_cardType;
		public GTextField m_text_time;
		public GTextField m_text_allcoins;
		public UI_btn_close2 m_btn_close;
		public GTextField m_text_coins;
		public UI_cards2 m_card;

		public const string URL = "ui://es6hjd4thm3axxr";

		public static UI_jackpot CreateInstance()
		{
			return (UI_jackpot)UIPackage.CreateObject("Room","jackpot");
		}

		public UI_jackpot()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
			m_text_nickname = (GTextField)this.GetChildAt(3);
			m_n5 = (GImage)this.GetChildAt(4);
			m_n4 = (GLoader)this.GetChildAt(5);
			m_text_cardType = (GTextField)this.GetChildAt(6);
			m_text_time = (GTextField)this.GetChildAt(7);
			m_text_allcoins = (GTextField)this.GetChildAt(8);
			m_btn_close = (UI_btn_close2)this.GetChildAt(9);
			m_text_coins = (GTextField)this.GetChildAt(10);
			m_card = (UI_cards2)this.GetChildAt(11);
		}
	}
}