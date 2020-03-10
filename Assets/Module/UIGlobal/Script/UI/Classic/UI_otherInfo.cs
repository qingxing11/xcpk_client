/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_otherInfo : GComponent
	{
		public Controller m_c1;
		public Controller m_c2;
		public GImage m_n8;
		public GImage m_n10;
		public GLoader m_head;
		public GTextField m_text_nickname;
		public GTextField m_text_gold;
		public GImage m_n7;
		public GTextField m_text_selfgold;
		public GLoader m_n13;
		public GLoader m_vip;
		public GList m_icon_list;
		public GImage m_n16;
		public UI_bar m_bar;
		public Transition m_t_win;

		public const string URL = "ui://x31qyfggeyzr28";

		public static UI_otherInfo CreateInstance()
		{
			return (UI_otherInfo)UIPackage.CreateObject("Classic","otherInfo");
		}

		public UI_otherInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_c2 = this.GetControllerAt(1);
			m_n8 = (GImage)this.GetChildAt(0);
			m_n10 = (GImage)this.GetChildAt(1);
			m_head = (GLoader)this.GetChildAt(2);
			m_text_nickname = (GTextField)this.GetChildAt(3);
			m_text_gold = (GTextField)this.GetChildAt(4);
			m_n7 = (GImage)this.GetChildAt(5);
			m_text_selfgold = (GTextField)this.GetChildAt(6);
			m_n13 = (GLoader)this.GetChildAt(7);
			m_vip = (GLoader)this.GetChildAt(8);
			m_icon_list = (GList)this.GetChildAt(9);
			m_n16 = (GImage)this.GetChildAt(10);
			m_bar = (UI_bar)this.GetChildAt(11);
			m_t_win = this.GetTransitionAt(0);
		}
	}
}