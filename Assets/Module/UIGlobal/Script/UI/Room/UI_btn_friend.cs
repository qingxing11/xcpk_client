/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_btn_friend : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://es6hjd4tftl2y31";

		public static UI_btn_friend CreateInstance()
		{
			return (UI_btn_friend)UIPackage.CreateObject("Room","btn_friend");
		}

		public UI_btn_friend()
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