/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Info
{
	public partial class UI_btn_cheers : GButton
	{
		public Controller m_button;
		public GImage m_n1;
		public GTextField m_title;
		public GImage m_n5;

		public const string URL = "ui://5wbi0yeupd2ctc5";

		public static UI_btn_cheers CreateInstance()
		{
			return (UI_btn_cheers)UIPackage.CreateObject("Info","btn_cheers");
		}

		public UI_btn_cheers()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n1 = (GImage)this.GetChildAt(0);
			m_title = (GTextField)this.GetChildAt(1);
			m_n5 = (GImage)this.GetChildAt(2);
		}
	}
}