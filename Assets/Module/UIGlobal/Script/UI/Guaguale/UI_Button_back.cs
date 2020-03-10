/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_Button_back : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://rjmn7jeuec6rt";

		public static UI_Button_back CreateInstance()
		{
			return (UI_Button_back)UIPackage.CreateObject("Guaguale","Button_back");
		}

		public UI_Button_back()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
		}
	}
}