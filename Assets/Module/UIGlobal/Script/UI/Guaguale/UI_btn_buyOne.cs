/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_btn_buyOne : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://rjmn7jeuzq2w68";

		public static UI_btn_buyOne CreateInstance()
		{
			return (UI_btn_buyOne)UIPackage.CreateObject("Guaguale","btn_buyOne");
		}

		public UI_btn_buyOne()
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