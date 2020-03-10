/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Horn
{
	public partial class UI_HornCom : GComponent
	{
		public GImage m_n1;
		public GImage m_n2;
		public UI_btn_close m_btn_close;
		public UI_btn_sure m_btn_sure;
		public UI_btn_cancel m_btn_cancel;
		public GTextInput m_txt_info;
		public GTextField m_txt_title;

		public const string URL = "ui://njlb91jseuxv9";

		public static UI_HornCom CreateInstance()
		{
			return (UI_HornCom)UIPackage.CreateObject("Horn","HornCom");
		}

		public UI_HornCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n1 = (GImage)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
			m_btn_close = (UI_btn_close)this.GetChildAt(2);
			m_btn_sure = (UI_btn_sure)this.GetChildAt(3);
			m_btn_cancel = (UI_btn_cancel)this.GetChildAt(4);
			m_txt_info = (GTextInput)this.GetChildAt(5);
			m_txt_title = (GTextField)this.GetChildAt(6);
		}
	}
}