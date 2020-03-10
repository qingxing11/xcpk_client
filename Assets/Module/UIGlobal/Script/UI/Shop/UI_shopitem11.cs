/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
	public partial class UI_shopitem11 : GComponent
	{
		public GImage m_n8;
		public GImage m_n9;
		public UI_btn_item m_btn_jinbi;
		public GTextField m_title;
		public GImage m_n18;

		public const string URL = "ui://el2yavg6anim72";

		public static UI_shopitem11 CreateInstance()
		{
			return (UI_shopitem11)UIPackage.CreateObject("Shop","shopitem11");
		}

		public UI_shopitem11()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n8 = (GImage)this.GetChildAt(0);
			m_n9 = (GImage)this.GetChildAt(1);
			m_btn_jinbi = (UI_btn_item)this.GetChildAt(2);
			m_title = (GTextField)this.GetChildAt(3);
			m_n18 = (GImage)this.GetChildAt(4);
		}
	}
}