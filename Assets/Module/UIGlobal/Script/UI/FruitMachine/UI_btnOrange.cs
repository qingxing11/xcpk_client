/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_btnOrange : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;

		public const string URL = "ui://l17p56hbd4j8te8";

		public static UI_btnOrange CreateInstance()
		{
			return (UI_btnOrange)UIPackage.CreateObject("FruitMachine","btnOrange");
		}

		public UI_btnOrange()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
		}
	}
}