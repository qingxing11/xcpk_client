/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Safebox
{
	public partial class UI_SafeBoxCom2 : GComponent
	{
		public GImage m_n4;
		public GImage m_n1;
		public GImage m_n3;
		public GImage m_n5;
		public GImage m_n6;
		public GImage m_n7;
		public GTextInput m_txt_input;
		public GTextField m_txt_boxBalance;
		public GTextField m_txt_cashBalance;
		public UI_btn_outPut m_btn_Fetch;
		public UI_btn_close m_btn_Close;

		public const string URL = "ui://ey7bc1rckv8w3i";

		public static UI_SafeBoxCom2 CreateInstance()
		{
			return (UI_SafeBoxCom2)UIPackage.CreateObject("Safebox","SafeBoxCom2");
		}

		public UI_SafeBoxCom2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n4 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n3 = (GImage)this.GetChildAt(2);
			m_n5 = (GImage)this.GetChildAt(3);
			m_n6 = (GImage)this.GetChildAt(4);
			m_n7 = (GImage)this.GetChildAt(5);
			m_txt_input = (GTextInput)this.GetChildAt(6);
			m_txt_boxBalance = (GTextField)this.GetChildAt(7);
			m_txt_cashBalance = (GTextField)this.GetChildAt(8);
			m_btn_Fetch = (UI_btn_outPut)this.GetChildAt(9);
			m_btn_Close = (UI_btn_close)this.GetChildAt(10);
		}
	}
}