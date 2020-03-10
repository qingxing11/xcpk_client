/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_btn_sub : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://rjmn7jeuzq2w6f";

		public static UI_btn_sub CreateInstance()
		{
			return (UI_btn_sub)UIPackage.CreateObject("Guaguale","btn_sub");
		}

		public UI_btn_sub()
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