/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Info
{
	public partial class UI_Update : GComponent
	{
		public Controller m_c1;
		public GImage m_n12;
		public GImage m_n19;
		public GImage m_n5;
		public GImage m_n6;
		public UI_btn_xiugai m_btn_gender0;
		public UI_btn_xiugai m_btn_gender1;
		public GImage m_n8;
		public GImage m_n13;
		public GImage m_n14;
		public GImage m_n15;
		public UI_btn_return m_btn_return;
		public UI_btn_baocun m_btn_baocun;
		public GTextInput m_text_nickname;

		public const string URL = "ui://5wbi0yeubh6ftco";

		public static UI_Update CreateInstance()
		{
			return (UI_Update)UIPackage.CreateObject("Info","Update");
		}

		public UI_Update()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n12 = (GImage)this.GetChildAt(0);
			m_n19 = (GImage)this.GetChildAt(1);
			m_n5 = (GImage)this.GetChildAt(2);
			m_n6 = (GImage)this.GetChildAt(3);
			m_btn_gender0 = (UI_btn_xiugai)this.GetChildAt(4);
			m_btn_gender1 = (UI_btn_xiugai)this.GetChildAt(5);
			m_n8 = (GImage)this.GetChildAt(6);
			m_n13 = (GImage)this.GetChildAt(7);
			m_n14 = (GImage)this.GetChildAt(8);
			m_n15 = (GImage)this.GetChildAt(9);
			m_btn_return = (UI_btn_return)this.GetChildAt(10);
			m_btn_baocun = (UI_btn_baocun)this.GetChildAt(11);
			m_text_nickname = (GTextInput)this.GetChildAt(12);
		}
	}
}