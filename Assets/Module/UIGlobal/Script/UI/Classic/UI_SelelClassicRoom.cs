/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_SelelClassicRoom : GComponent
	{
		public GImage m_bg;
		public UI_btn_room1 m_btn_room1;
		public UI_btn_room2 m_btn_room2;
		public UI_btn_room3 m_btn_room3;
		public UI_btn_room4 m_btn_room4;
		public UI_btn_back m_btn_back;
		public GTextField m_n7;
		public GTextField m_n8;
		public GTextField m_n9;
		public GTextField m_n10;
		public GTextField m_n11;
		public GTextField m_n12;
		public GTextField m_n13;
		public GTextField m_n14;
		public GImage m_n16;
		public GImage m_n15;
		public GTextField m_text_tips;

		public const string URL = "ui://x31qyfggj9pn1f";

		public static UI_SelelClassicRoom CreateInstance()
		{
			return (UI_SelelClassicRoom)UIPackage.CreateObject("Classic","SelelClassicRoom");
		}

		public UI_SelelClassicRoom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_bg = (GImage)this.GetChildAt(0);
			m_btn_room1 = (UI_btn_room1)this.GetChildAt(1);
			m_btn_room2 = (UI_btn_room2)this.GetChildAt(2);
			m_btn_room3 = (UI_btn_room3)this.GetChildAt(3);
			m_btn_room4 = (UI_btn_room4)this.GetChildAt(4);
			m_btn_back = (UI_btn_back)this.GetChildAt(5);
			m_n7 = (GTextField)this.GetChildAt(6);
			m_n8 = (GTextField)this.GetChildAt(7);
			m_n9 = (GTextField)this.GetChildAt(8);
			m_n10 = (GTextField)this.GetChildAt(9);
			m_n11 = (GTextField)this.GetChildAt(10);
			m_n12 = (GTextField)this.GetChildAt(11);
			m_n13 = (GTextField)this.GetChildAt(12);
			m_n14 = (GTextField)this.GetChildAt(13);
			m_n16 = (GImage)this.GetChildAt(14);
			m_n15 = (GImage)this.GetChildAt(15);
			m_text_tips = (GTextField)this.GetChildAt(16);
		}
	}
}