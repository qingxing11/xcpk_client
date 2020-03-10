/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
	public partial class UI_shopitem12 : GComponent
	{
		public GImage m_n8;
		public GImage m_n10;
		public UI_btn_item m_btn_jinbi;
		public GImage m_n20;
		public GTextField m_title;

		public const string URL = "ui://el2yavg6anim73";

		public static UI_shopitem12 CreateInstance()
		{
			return (UI_shopitem12)UIPackage.CreateObject("Shop","shopitem12");
		}

		public UI_shopitem12()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n8 = (GImage)this.GetChildAt(0);
			m_n10 = (GImage)this.GetChildAt(1);
			m_btn_jinbi = (UI_btn_item)this.GetChildAt(2);
			m_n20 = (GImage)this.GetChildAt(3);
			m_title = (GTextField)this.GetChildAt(4);
		}
	}
}