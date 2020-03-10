/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_gt_g : GButton
	{
		public Controller m_button;
		public GGraph m_n0;
		public GGraph m_n1;
		public GTextField m_title;

		public const string URL = "ui://du637vw1hxskt82";

		public static UI_btn_gt_g CreateInstance()
		{
			return (UI_btn_gt_g)UIPackage.CreateObject("Main","btn_gt_g");
		}

		public UI_btn_gt_g()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GGraph)this.GetChildAt(0);
			m_n1 = (GGraph)this.GetChildAt(1);
			m_title = (GTextField)this.GetChildAt(2);
		}
	}
}