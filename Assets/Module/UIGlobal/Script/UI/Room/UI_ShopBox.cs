/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_ShopBox : GComponent
	{
		public Controller m_c1;
		public UI_btn_conrol m_btn_conrol;
		public GImage m_n5;
		public UI_btn_shop m_btn_shop;
		public UI_btn_box m_btn_box;
		public GImage m_n6;

		public const string URL = "ui://es6hjd4tt37kxz8";

		public static UI_ShopBox CreateInstance()
		{
			return (UI_ShopBox)UIPackage.CreateObject("Room","ShopBox");
		}

		public UI_ShopBox()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_btn_conrol = (UI_btn_conrol)this.GetChildAt(0);
			m_n5 = (GImage)this.GetChildAt(1);
			m_btn_shop = (UI_btn_shop)this.GetChildAt(2);
			m_btn_box = (UI_btn_box)this.GetChildAt(3);
			m_n6 = (GImage)this.GetChildAt(4);
		}
	}
}