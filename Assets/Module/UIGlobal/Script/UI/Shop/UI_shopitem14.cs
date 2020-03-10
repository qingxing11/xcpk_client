/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
	public partial class UI_shopitem14 : GComponent
	{
		public GImage m_n8;
		public GImage m_n12;
		public UI_btn_item m_btn_jinbi;
		public GImage m_n18;
		public GTextField m_n19;
		public GImage m_n20;
		public GTextField m_title;

		public const string URL = "ui://el2yavg6anim75";

		public static UI_shopitem14 CreateInstance()
		{
			return (UI_shopitem14)UIPackage.CreateObject("Shop","shopitem14");
		}

		public UI_shopitem14()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n8 = (GImage)this.GetChildAt(0);
			m_n12 = (GImage)this.GetChildAt(1);
			m_btn_jinbi = (UI_btn_item)this.GetChildAt(2);
			m_n18 = (GImage)this.GetChildAt(3);
			m_n19 = (GTextField)this.GetChildAt(4);
			m_n20 = (GImage)this.GetChildAt(5);
			m_title = (GTextField)this.GetChildAt(6);
		}
	}
}