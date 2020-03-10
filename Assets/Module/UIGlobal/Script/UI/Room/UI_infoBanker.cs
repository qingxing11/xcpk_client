/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_infoBanker : GComponent
	{
		public UI_headbanker m_head;
		public GImage m_n17;
		public GImage m_n19;
		public GTextField m_text_nickname;
		public GTextField m_gold;
		public GImage m_n15;
		public GLoader m_vip;
		public GList m_icon_list;

		public const string URL = "ui://es6hjd4t9nncxwi";

		public static UI_infoBanker CreateInstance()
		{
			return (UI_infoBanker)UIPackage.CreateObject("Room","infoBanker");
		}

		public UI_infoBanker()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_head = (UI_headbanker)this.GetChildAt(0);
			m_n17 = (GImage)this.GetChildAt(1);
			m_n19 = (GImage)this.GetChildAt(2);
			m_text_nickname = (GTextField)this.GetChildAt(3);
			m_gold = (GTextField)this.GetChildAt(4);
			m_n15 = (GImage)this.GetChildAt(5);
			m_vip = (GLoader)this.GetChildAt(6);
			m_icon_list = (GList)this.GetChildAt(7);
		}
	}
}