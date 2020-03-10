/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_btn_khc : GButton
	{
		public Controller m_c1;
		public GImage m_n1;
		public GImage m_n0;

		public const string URL = "ui://l17p56hbd4j8tbe";

		public static UI_btn_khc CreateInstance()
		{
			return (UI_btn_khc)UIPackage.CreateObject("FruitMachine","btn_khc");
		}

		public UI_btn_khc()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n1 = (GImage)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
		}
	}
}