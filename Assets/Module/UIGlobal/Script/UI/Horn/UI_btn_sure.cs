/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Horn
{
	public partial class UI_btn_sure : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://njlb91jseuxvb";

		public static UI_btn_sure CreateInstance()
		{
			return (UI_btn_sure)UIPackage.CreateObject("Horn","btn_sure");
		}

		public UI_btn_sure()
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