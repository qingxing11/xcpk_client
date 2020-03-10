/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_btn_kamisho : GButton
	{
		public Controller m_button;
		public GImage m_n3;
		public GImage m_n4;

		public const string URL = "ui://l17p56hbs3ji3";

		public static UI_btn_kamisho CreateInstance()
		{
			return (UI_btn_kamisho)UIPackage.CreateObject("FruitMachine","btn_kamisho");
		}

		public UI_btn_kamisho()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n3 = (GImage)this.GetChildAt(0);
			m_n4 = (GImage)this.GetChildAt(1);
		}
	}
}