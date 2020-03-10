/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_xgmm : GComponent
	{
		public GImage m_n11;
		public GImage m_bg0;
		public GImage m_bg1;
		public GImage m_n7;
		public GImage m_n8;
		public UI_btn_ok m_btn_ok;
		public UI_btn_close m_btn_close;
		public GTextInput m_text_oldPwd;
		public GTextInput m_text_newPwd1;
		public GImage m_n12;
		public GTextInput m_text_newPwd2;
		public GImage m_n16;
		public GImage m_n17;
		public GImage m_n18;
		public GImage m_n20;

		public const string URL = "ui://4f5tb9ztdpct9e";

		public static UI_xgmm CreateInstance()
		{
			return (UI_xgmm)UIPackage.CreateObject("Set","xgmm");
		}

		public UI_xgmm()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n11 = (GImage)this.GetChildAt(0);
			m_bg0 = (GImage)this.GetChildAt(1);
			m_bg1 = (GImage)this.GetChildAt(2);
			m_n7 = (GImage)this.GetChildAt(3);
			m_n8 = (GImage)this.GetChildAt(4);
			m_btn_ok = (UI_btn_ok)this.GetChildAt(5);
			m_btn_close = (UI_btn_close)this.GetChildAt(6);
			m_text_oldPwd = (GTextInput)this.GetChildAt(7);
			m_text_newPwd1 = (GTextInput)this.GetChildAt(8);
			m_n12 = (GImage)this.GetChildAt(9);
			m_text_newPwd2 = (GTextInput)this.GetChildAt(10);
			m_n16 = (GImage)this.GetChildAt(11);
			m_n17 = (GImage)this.GetChildAt(12);
			m_n18 = (GImage)this.GetChildAt(13);
			m_n20 = (GImage)this.GetChildAt(14);
		}
	}
}