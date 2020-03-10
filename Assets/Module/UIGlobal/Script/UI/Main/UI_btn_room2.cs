/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_room2 : GButton
	{
		public Controller m_button;
		public GImage m_n2;
		public GImage m_n3;

		public const string URL = "ui://du637vw1dwi1t60";

		public static UI_btn_room2 CreateInstance()
		{
			return (UI_btn_room2)UIPackage.CreateObject("Main","btn_room2");
		}

		public UI_btn_room2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n3 = (GImage)this.GetChildAt(1);
		}
	}
}