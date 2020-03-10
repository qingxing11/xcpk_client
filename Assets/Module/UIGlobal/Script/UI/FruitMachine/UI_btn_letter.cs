/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_btn_letter : GButton
	{
		public Controller m_button;
		public GImage m_n5;

		public const string URL = "ui://l17p56hbq682t90";

		public static UI_btn_letter CreateInstance()
		{
			return (UI_btn_letter)UIPackage.CreateObject("FruitMachine","btn_letter");
		}

		public UI_btn_letter()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n5 = (GImage)this.GetChildAt(0);
		}
	}
}