/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_one : GComponent
	{
		public GImage m_n229;
		public GImage m_n230;

		public const string URL = "ui://l17p56hbsvekthb";

		public static UI_one CreateInstance()
		{
			return (UI_one)UIPackage.CreateObject("FruitMachine","one");
		}

		public UI_one()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n229 = (GImage)this.GetChildAt(0);
			m_n230 = (GImage)this.GetChildAt(1);
		}
	}
}