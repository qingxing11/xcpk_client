/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
	public partial class UI_shopitem13 : GComponent
	{
		public GImage m_n8;
		public GImage m_n11;
		public UI_btn_item m_btn_jinbi;
		public GImage m_n18;
		public GImage m_n19;
		public GTextField m_n20;
		public GImage m_n21;
		public GTextField m_title;

		public const string URL = "ui://el2yavg6anim74";

		public static UI_shopitem13 CreateInstance()
		{
			return (UI_shopitem13)UIPackage.CreateObject("Shop","shopitem13");
		}

		public UI_shopitem13()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n8 = (GImage)this.GetChildAt(0);
			m_n11 = (GImage)this.GetChildAt(1);
			m_btn_jinbi = (UI_btn_item)this.GetChildAt(2);
			m_n18 = (GImage)this.GetChildAt(3);
			m_n19 = (GImage)this.GetChildAt(4);
			m_n20 = (GTextField)this.GetChildAt(5);
			m_n21 = (GImage)this.GetChildAt(6);
			m_title = (GTextField)this.GetChildAt(7);
		}
	}
}