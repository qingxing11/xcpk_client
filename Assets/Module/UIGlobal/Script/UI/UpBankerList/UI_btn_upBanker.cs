/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UpBankerList
{
	public partial class UI_btn_upBanker : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GTextField m_title;

		public const string URL = "ui://septv56pvun814";

		public static UI_btn_upBanker CreateInstance()
		{
			return (UI_btn_upBanker)UIPackage.CreateObject("UpBankerList","btn_upBanker");
		}

		public UI_btn_upBanker()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_title = (GTextField)this.GetChildAt(2);
		}
	}
}