/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Safebox
{
	public partial class UI_btn_OperatingRecord : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://ey7bc1rcv4v91s";

		public static UI_btn_OperatingRecord CreateInstance()
		{
			return (UI_btn_OperatingRecord)UIPackage.CreateObject("Safebox","btn_OperatingRecord");
		}

		public UI_btn_OperatingRecord()
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