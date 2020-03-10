/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
	public partial class UI_shopitem23 : GComponent
	{
		public GImage m_n8;
		public UI_btn_item m_btn_jinbi;
		public GImage m_n18;
		public GTextField m_title;

		public const string URL = "ui://el2yavg6anim7b";

		public static UI_shopitem23 CreateInstance()
		{
			return (UI_shopitem23)UIPackage.CreateObject("Shop","shopitem23");
		}

		public UI_shopitem23()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n8 = (GImage)this.GetChildAt(0);
			m_btn_jinbi = (UI_btn_item)this.GetChildAt(1);
			m_n18 = (GImage)this.GetChildAt(2);
			m_title = (GTextField)this.GetChildAt(3);
		}
	}
}