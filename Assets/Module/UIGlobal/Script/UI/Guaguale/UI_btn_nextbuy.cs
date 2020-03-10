/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_btn_nextbuy : GButton
	{
		public Controller m_button;
		public GImage m_n2;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://rjmn7jeuzq2w6o";

		public static UI_btn_nextbuy CreateInstance()
		{
			return (UI_btn_nextbuy)UIPackage.CreateObject("Guaguale","btn_nextbuy");
		}

		public UI_btn_nextbuy()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
			m_n1 = (GImage)this.GetChildAt(2);
		}
	}
}