/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Safebox
{
	public partial class UI_SafeBoxCom : GComponent
	{
		public Controller m_c1;
		public GImage m_n3;
		public GImage m_n4;
		public GImage m_n2;
		public UI_btn_MySafeBox m_btn_MyBox;
		public UI_btn_MoneyAccount m_btn_Money;
		public UI_btn_close m_btn_Close;
		public UI_btn_OperatingRecord m_btn_OperatingRecord;
		public GGroup m_menu;
		public GImage m_n7;
		public GImage m_n8;
		public GImage m_n9;
		public GImage m_n10;
		public GImage m_n14;
		public UI_btn_Deposit m_btn_Deposit;
		public UI_btn_Fetch m_btn_Fetch;
		public GImage m_n57;
		public GTextInput m_txt_input;
		public GTextField m_txt_boxBalance;
		public GTextField m_txt_cashBalance;
		public GImage m_n58;
		public GGroup m_box;
		public GImage m_n49;
		public GImage m_n50;
		public GImage m_n54;
		public GImage m_n56;
		public GTextInput m_txt_inpuID;
		public GTextInput m_txt_inputMoneyNum;
		public UI_btn_sureChange m_btn_sureOpera;
		public GTextField m_n48;
		public GTextField m_txt_pre;
		public GGroup m_money;
		public UI_SureOperaCom m_sureOperaCom;
		public UI_SureOperaCom2 m_sureOperaCom2;
		public UI_OperatingRecordCom m_operatingRecordCom;

		public const string URL = "ui://ey7bc1rcv4v91o";

		public static UI_SafeBoxCom CreateInstance()
		{
			return (UI_SafeBoxCom)UIPackage.CreateObject("Safebox","SafeBoxCom");
		}

		public UI_SafeBoxCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n3 = (GImage)this.GetChildAt(0);
			m_n4 = (GImage)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
			m_btn_MyBox = (UI_btn_MySafeBox)this.GetChildAt(3);
			m_btn_Money = (UI_btn_MoneyAccount)this.GetChildAt(4);
			m_btn_Close = (UI_btn_close)this.GetChildAt(5);
			m_btn_OperatingRecord = (UI_btn_OperatingRecord)this.GetChildAt(6);
			m_menu = (GGroup)this.GetChildAt(7);
			m_n7 = (GImage)this.GetChildAt(8);
			m_n8 = (GImage)this.GetChildAt(9);
			m_n9 = (GImage)this.GetChildAt(10);
			m_n10 = (GImage)this.GetChildAt(11);
			m_n14 = (GImage)this.GetChildAt(12);
			m_btn_Deposit = (UI_btn_Deposit)this.GetChildAt(13);
			m_btn_Fetch = (UI_btn_Fetch)this.GetChildAt(14);
			m_n57 = (GImage)this.GetChildAt(15);
			m_txt_input = (GTextInput)this.GetChildAt(16);
			m_txt_boxBalance = (GTextField)this.GetChildAt(17);
			m_txt_cashBalance = (GTextField)this.GetChildAt(18);
			m_n58 = (GImage)this.GetChildAt(19);
			m_box = (GGroup)this.GetChildAt(20);
			m_n49 = (GImage)this.GetChildAt(21);
			m_n50 = (GImage)this.GetChildAt(22);
			m_n54 = (GImage)this.GetChildAt(23);
			m_n56 = (GImage)this.GetChildAt(24);
			m_txt_inpuID = (GTextInput)this.GetChildAt(25);
			m_txt_inputMoneyNum = (GTextInput)this.GetChildAt(26);
			m_btn_sureOpera = (UI_btn_sureChange)this.GetChildAt(27);
			m_n48 = (GTextField)this.GetChildAt(28);
			m_txt_pre = (GTextField)this.GetChildAt(29);
			m_money = (GGroup)this.GetChildAt(30);
			m_sureOperaCom = (UI_SureOperaCom)this.GetChildAt(31);
			m_sureOperaCom2 = (UI_SureOperaCom2)this.GetChildAt(32);
			m_operatingRecordCom = (UI_OperatingRecordCom)this.GetChildAt(33);
		}
	}
}