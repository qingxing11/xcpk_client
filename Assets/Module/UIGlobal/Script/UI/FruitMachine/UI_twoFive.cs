/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_twoFive : GComponent
	{
		public GImage m_n231;
		public GImage m_n232;

		public const string URL = "ui://l17p56hbsvekthc";

		public static UI_twoFive CreateInstance()
		{
			return (UI_twoFive)UIPackage.CreateObject("FruitMachine","twoFive");
		}

		public UI_twoFive()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n231 = (GImage)this.GetChildAt(0);
			m_n232 = (GImage)this.GetChildAt(1);
		}
	}
}