/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_rankBtn : GButton
	{
		public Controller m_c1;
		public GTextField m_title;
		public GImage m_n4;
		public GTextField m_text_nickname;
		public GTextField m_text_call;
		public GTextField m_n12;
		public GImage m_n13;
		public GImage m_n14;
		public GImage m_n15;
		public GTextField m_text_rank;

		public const string URL = "ui://du637vw110z9t5k";

		public static UI_rankBtn CreateInstance()
		{
			return (UI_rankBtn)UIPackage.CreateObject("Main","rankBtn");
		}

		public UI_rankBtn()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_title = (GTextField)this.GetChildAt(0);
			m_n4 = (GImage)this.GetChildAt(1);
			m_text_nickname = (GTextField)this.GetChildAt(2);
			m_text_call = (GTextField)this.GetChildAt(3);
			m_n12 = (GTextField)this.GetChildAt(4);
			m_n13 = (GImage)this.GetChildAt(5);
			m_n14 = (GImage)this.GetChildAt(6);
			m_n15 = (GImage)this.GetChildAt(7);
			m_text_rank = (GTextField)this.GetChildAt(8);
		}
	}
}