/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_btn_gold : GButton
	{
		public Controller m_button;
		public GImage m_n2;
		public GImage m_n4;

		public const string URL = "ui://es6hjd4toha2xvw";

		public static UI_btn_gold CreateInstance()
		{
			return (UI_btn_gold)UIPackage.CreateObject("Room","btn_gold");
		}

		public UI_btn_gold()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n4 = (GImage)this.GetChildAt(1);
		}
	}
}