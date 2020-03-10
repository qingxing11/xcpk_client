/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Tree
{
	public partial class UI_btn_treeget : GButton
	{
		public Controller m_button;
		public GImage m_n4;
		public GImage m_n3;
		public GImage m_n5;

		public const string URL = "ui://erft97svv6d6w";

		public static UI_btn_treeget CreateInstance()
		{
			return (UI_btn_treeget)UIPackage.CreateObject("Tree","btn_treeget");
		}

		public UI_btn_treeget()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n4 = (GImage)this.GetChildAt(0);
			m_n3 = (GImage)this.GetChildAt(1);
			m_n5 = (GImage)this.GetChildAt(2);
		}
	}
}