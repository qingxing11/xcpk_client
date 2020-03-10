/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_btn_return_g1 : GButton
	{
		public Controller m_button;
		public GImage m_n2;

		public const string URL = "ui://l17p56hbq682t8w";

		public static UI_btn_return_g1 CreateInstance()
		{
			return (UI_btn_return_g1)UIPackage.CreateObject("FruitMachine","btn_return_g1");
		}

		public UI_btn_return_g1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
		}
	}
}