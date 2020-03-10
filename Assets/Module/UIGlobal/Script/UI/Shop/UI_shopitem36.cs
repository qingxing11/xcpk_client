/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
	public partial class UI_shopitem36 : GComponent
	{
		public Controller m_c1;
		public GImage m_n8;
		public UI_btn_item m_btn_jinbi;
		public GImage m_n17;
		public GTextField m_n19;
		public GImage m_n22;

		public const string URL = "ui://el2yavg6vo2v7p";

		public static UI_shopitem36 CreateInstance()
		{
			return (UI_shopitem36)UIPackage.CreateObject("Shop","shopitem36");
		}

		public UI_shopitem36()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n8 = (GImage)this.GetChildAt(0);
			m_btn_jinbi = (UI_btn_item)this.GetChildAt(1);
			m_n17 = (GImage)this.GetChildAt(2);
			m_n19 = (GTextField)this.GetChildAt(3);
			m_n22 = (GImage)this.GetChildAt(4);
		}
	}
}