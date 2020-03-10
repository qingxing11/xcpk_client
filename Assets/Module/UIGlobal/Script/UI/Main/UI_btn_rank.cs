/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_rank : GButton
	{
		public Controller m_button;
		public GImage m_n6;
		public GImage m_n7;

		public const string URL = "ui://du637vw1fdzr43";

		public static UI_btn_rank CreateInstance()
		{
			return (UI_btn_rank)UIPackage.CreateObject("Main","btn_rank");
		}

		public UI_btn_rank()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n6 = (GImage)this.GetChildAt(0);
			m_n7 = (GImage)this.GetChildAt(1);
		}
	}
}