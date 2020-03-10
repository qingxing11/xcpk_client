/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_btn_shop : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://es6hjd4tt37kxzk";

		public static UI_btn_shop CreateInstance()
		{
			return (UI_btn_shop)UIPackage.CreateObject("Room","btn_shop");
		}

		public UI_btn_shop()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
		}
	}
}