/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_fiveTen : GComponent
	{
		public GImage m_n233;
		public GImage m_n234;

		public const string URL = "ui://l17p56hbsvekthd";

		public static UI_fiveTen CreateInstance()
		{
			return (UI_fiveTen)UIPackage.CreateObject("FruitMachine","fiveTen");
		}

		public UI_fiveTen()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n233 = (GImage)this.GetChildAt(0);
			m_n234 = (GImage)this.GetChildAt(1);
		}
	}
}