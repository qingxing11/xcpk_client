/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_btn_jbld : GButton
	{
		public Controller m_c1;
		public GImage m_n2;
		public GImage m_n3;

		public const string URL = "ui://l17p56hbd4j8tbg";

		public static UI_btn_jbld CreateInstance()
		{
			return (UI_btn_jbld)UIPackage.CreateObject("FruitMachine","btn_jbld");
		}

		public UI_btn_jbld()
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