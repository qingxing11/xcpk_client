/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_selfInfo : GComponent
	{
		public GImage m_n6;
		public GImage m_n12;
		public GLoader m_head;
		public GTextField m_text_nickname;
		public GTextField m_text_selfgold;
		public GTextField m_text_gold;
		public GImage m_n7;
		public GLoader m_n9;
		public GLoader m_vip;
		public GList m_icon_list;
		public UI_barHeng m_bar;
		public Transition m_t_win;

		public const string URL = "ui://x31qyfggeyzr25";

		public static UI_selfInfo CreateInstance()
		{
			return (UI_selfInfo)UIPackage.CreateObject("Classic","selfInfo");
		}

		public UI_selfInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n6 = (GImage)this.GetChildAt(0);
			m_n12 = (GImage)this.GetChildAt(1);
			m_head = (GLoader)this.GetChildAt(2);
			m_text_nickname = (GTextField)this.GetChildAt(3);
			m_text_selfgold = (GTextField)this.GetChildAt(4);
			m_text_gold = (GTextField)this.GetChildAt(5);
			m_n7 = (GImage)this.GetChildAt(6);
			m_n9 = (GLoader)this.GetChildAt(7);
			m_vip = (GLoader)this.GetChildAt(8);
			m_icon_list = (GList)this.GetChildAt(9);
			m_bar = (UI_barHeng)this.GetChildAt(10);
			m_t_win = this.GetTransitionAt(0);
		}
	}
}