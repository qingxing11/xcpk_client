/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_btn_guan : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://4f5tb9ztvun89q";

		public static UI_btn_guan CreateInstance()
		{
			return (UI_btn_guan)UIPackage.CreateObject("Set","btn_guan");
		}

		public UI_btn_guan()
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