/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Info
{
	public partial class UI_Set : GComponent
	{
		public Controller m_ctrl_sex;
		public GImage m_n38;
		public GImage m_n39;
		public UI_btn_close m_btn_close;

		public const string URL = "ui://5wbi0yeuaeenta1";

		public static UI_Set CreateInstance()
		{
			return (UI_Set)UIPackage.CreateObject("Info","Set");
		}

		public UI_Set()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ctrl_sex = this.GetControllerAt(0);
			m_n38 = (GImage)this.GetChildAt(0);
			m_n39 = (GImage)this.GetChildAt(1);
			m_btn_close = (UI_btn_close)this.GetChildAt(2);
		}
	}
}