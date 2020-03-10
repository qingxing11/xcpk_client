/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_btn_UpBanker : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n3;

		public const string URL = "ui://l17p56hbue6ctep";

		public static UI_btn_UpBanker CreateInstance()
		{
			return (UI_btn_UpBanker)UIPackage.CreateObject("FruitMachine","btn_UpBanker");
		}

		public UI_btn_UpBanker()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n3 = (GImage)this.GetChildAt(2);
		}
	}
}