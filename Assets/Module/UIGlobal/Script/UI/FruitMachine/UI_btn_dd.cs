/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_btn_dd : GButton
	{
		public Controller m_c1;
		public GImage m_n2;
		public GImage m_n3;

		public const string URL = "ui://l17p56hbd4j8tbf";

		public static UI_btn_dd CreateInstance()
		{
			return (UI_btn_dd)UIPackage.CreateObject("FruitMachine","btn_dd");
		}

		public UI_btn_dd()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n3 = (GImage)this.GetChildAt(1);
		}
	}
}