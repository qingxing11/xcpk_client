/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_tree : GButton
	{
		public Controller m_button;
		public GImage m_n4;
		public GImage m_n5;

		public const string URL = "ui://du637vw1fdzr48";

		public static UI_btn_tree CreateInstance()
		{
			return (UI_btn_tree)UIPackage.CreateObject("Main","btn_tree");
		}

		public UI_btn_tree()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n4 = (GImage)this.GetChildAt(0);
			m_n5 = (GImage)this.GetChildAt(1);
		}
	}
}