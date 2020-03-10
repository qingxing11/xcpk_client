/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_btn_red : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://es6hjd4te9doxzn";

		public static UI_btn_red CreateInstance()
		{
			return (UI_btn_red)UIPackage.CreateObject("Room","btn_red");
		}

		public UI_btn_red()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
		}
	}
}