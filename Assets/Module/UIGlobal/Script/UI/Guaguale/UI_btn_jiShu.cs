/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_btn_jiShu : GButton
	{
		public Controller m_button;
		public Controller m_c1;
		public GImage m_n2;
		public GImage m_n0;
		public GImage m_n1;
		public GGroup m_n3;

		public const string URL = "ui://rjmn7jeuzq2w6a";

		public static UI_btn_jiShu CreateInstance()
		{
			return (UI_btn_jiShu)UIPackage.CreateObject("Guaguale","btn_jiShu");
		}

		public UI_btn_jiShu()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_c1 = this.GetControllerAt(1);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
			m_n1 = (GImage)this.GetChildAt(2);
			m_n3 = (GGroup)this.GetChildAt(3);
		}
	}
}