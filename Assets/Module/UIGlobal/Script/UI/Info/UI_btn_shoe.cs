/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Info
{
	public partial class UI_btn_shoe : GButton
	{
		public Controller m_button;
		public GImage m_n1;
		public GImage m_n0;
		public GTextField m_title;

		public const string URL = "ui://5wbi0yeupd2ctc1";

		public static UI_btn_shoe CreateInstance()
		{
			return (UI_btn_shoe)UIPackage.CreateObject("Info","btn_shoe");
		}

		public UI_btn_shoe()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n1 = (GImage)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
			m_title = (GTextField)this.GetChildAt(2);
		}
	}
}