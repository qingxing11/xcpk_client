/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_GglGame : GComponent
	{
		public Controller m_c1;
		public Controller m_c2;
		public GImage m_n3;
		public GImage m_n6;
		public UI_Button_back m_button_back;
		public GLoader m_loder_xingyunqizhi;
		public GLoader m_loader_qizhi1;
		public GLoader m_loader_qizhi2;
		public GGroup m_xingyunqizhi;
		public GLoader m_btn_nideqizhi;
		public GLoader m_btn_guawo;
		public UI_QiZhiItem m_qizhiItem1;
		public UI_QiZhiItem m_qizhiItem2;
		public UI_QiZhiItem m_qizhiItem3;
		public UI_QiZhiItem m_qizhiItem4;
		public UI_QiZhiItem m_qizhiItem5;
		public UI_QiZhiItem m_qizhiItem6;
		public GGroup m_nindeqizhi;
		public UI_btn_buyOne m_Btn_OneBuy;
		public UI_Button_menu m_btn_menu;
		public UI_btn_myBuy m_btn_MyBuy;
		public UI_btn_jiShu m_btn_jiShu;
		public GTextField m_txt_money;
		public GTextField m_txt_title;
		public GImage m_bg_horn;
		public GLoader m_btn_horn;
		public GLoader m_btn_hornReocrd;
		public GGroup m_horn;
		public GLoader m_btn_money;
		public GImage m_n31;
		public UI_Btn_reward m_btn_reward;
		public GImage m_n33;
		public GImage m_n34;

		public const string URL = "ui://rjmn7jeuec6rn";

		public static UI_GglGame CreateInstance()
		{
			return (UI_GglGame)UIPackage.CreateObject("Guaguale","GglGame");
		}

		public UI_GglGame()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_c2 = this.GetControllerAt(1);
			m_n3 = (GImage)this.GetChildAt(0);
			m_n6 = (GImage)this.GetChildAt(1);
			m_button_back = (UI_Button_back)this.GetChildAt(2);
			m_loder_xingyunqizhi = (GLoader)this.GetChildAt(3);
			m_loader_qizhi1 = (GLoader)this.GetChildAt(4);
			m_loader_qizhi2 = (GLoader)this.GetChildAt(5);
			m_xingyunqizhi = (GGroup)this.GetChildAt(6);
			m_btn_nideqizhi = (GLoader)this.GetChildAt(7);
			m_btn_guawo = (GLoader)this.GetChildAt(8);
			m_qizhiItem1 = (UI_QiZhiItem)this.GetChildAt(9);
			m_qizhiItem2 = (UI_QiZhiItem)this.GetChildAt(10);
			m_qizhiItem3 = (UI_QiZhiItem)this.GetChildAt(11);
			m_qizhiItem4 = (UI_QiZhiItem)this.GetChildAt(12);
			m_qizhiItem5 = (UI_QiZhiItem)this.GetChildAt(13);
			m_qizhiItem6 = (UI_QiZhiItem)this.GetChildAt(14);
			m_nindeqizhi = (GGroup)this.GetChildAt(15);
			m_Btn_OneBuy = (UI_btn_buyOne)this.GetChildAt(16);
			m_btn_menu = (UI_Button_menu)this.GetChildAt(17);
			m_btn_MyBuy = (UI_btn_myBuy)this.GetChildAt(18);
			m_btn_jiShu = (UI_btn_jiShu)this.GetChildAt(19);
			m_txt_money = (GTextField)this.GetChildAt(20);
			m_txt_title = (GTextField)this.GetChildAt(21);
			m_bg_horn = (GImage)this.GetChildAt(22);
			m_btn_horn = (GLoader)this.GetChildAt(23);
			m_btn_hornReocrd = (GLoader)this.GetChildAt(24);
			m_horn = (GGroup)this.GetChildAt(25);
			m_btn_money = (GLoader)this.GetChildAt(26);
			m_n31 = (GImage)this.GetChildAt(27);
			m_btn_reward = (UI_Btn_reward)this.GetChildAt(28);
			m_n33 = (GImage)this.GetChildAt(29);
			m_n34 = (GImage)this.GetChildAt(30);
		}
	}
}