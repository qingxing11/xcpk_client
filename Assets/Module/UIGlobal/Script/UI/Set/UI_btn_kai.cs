/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_btn_kai : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://4f5tb9ztvun89r";

		public static UI_btn_kai CreateInstance()
		{
			return (UI_btn_kai)UIPackage.CreateObject("Set","btn_kai");
		}

		public UI_btn_kai()
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