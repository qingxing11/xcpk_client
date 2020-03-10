/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lottery
{
	public partial class UI_btn_duigou : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://czzshd91lt201m";

		public static UI_btn_duigou CreateInstance()
		{
			return (UI_btn_duigou)UIPackage.CreateObject("Lottery","btn_duigou");
		}

		public UI_btn_duigou()
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