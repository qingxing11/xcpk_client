/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
	public partial class UI_shop : GComponent
	{
		public Controller m_c1;
		public GImage m_n38;
		public GImage m_n39;
		public UI_btn_shop m_btn_shop;
		public UI_btn_diamond m_btn_diamond;
		public UI_btn_props m_btn_props;
		public UI_btn_vip m_btn_vip;
		public UI_btn_return m_btn_return;
		public GLoader m_icon;
		public GTextField m_txt_nike;
		public GImage m_n31;
		public GTextField m_txt_jinbi;
		public GLoader m_jinbi;
		public GLoader m_btn_add_left;
		public GImage m_n32;
		public GTextField m_txt_zuanshi;
		public GLoader m_zuanshi;
		public GLoader m_btn_add_right;
		public GLoader m_vip;
		public GList m_list_shop0;
		public GList m_list_shop1;
		public GList m_list_shop2;
		public GList m_list_shop3;

		public const string URL = "ui://el2yavg6j4qy2i";

		public static UI_shop CreateInstance()
		{
			return (UI_shop)UIPackage.CreateObject("Shop","shop");
		}

		public UI_shop()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n38 = (GImage)this.GetChildAt(0);
			m_n39 = (GImage)this.GetChildAt(1);
			m_btn_shop = (UI_btn_shop)this.GetChildAt(2);
			m_btn_diamond = (UI_btn_diamond)this.GetChildAt(3);
			m_btn_props = (UI_btn_props)this.GetChildAt(4);
			m_btn_vip = (UI_btn_vip)this.GetChildAt(5);
			m_btn_return = (UI_btn_return)this.GetChildAt(6);
			m_icon = (GLoader)this.GetChildAt(7);
			m_txt_nike = (GTextField)this.GetChildAt(8);
			m_n31 = (GImage)this.GetChildAt(9);
			m_txt_jinbi = (GTextField)this.GetChildAt(10);
			m_jinbi = (GLoader)this.GetChildAt(11);
			m_btn_add_left = (GLoader)this.GetChildAt(12);
			m_n32 = (GImage)this.GetChildAt(13);
			m_txt_zuanshi = (GTextField)this.GetChildAt(14);
			m_zuanshi = (GLoader)this.GetChildAt(15);
			m_btn_add_right = (GLoader)this.GetChildAt(16);
			m_vip = (GLoader)this.GetChildAt(17);
			m_list_shop0 = (GList)this.GetChildAt(18);
			m_list_shop1 = (GList)this.GetChildAt(19);
			m_list_shop2 = (GList)this.GetChildAt(20);
			m_list_shop3 = (GList)this.GetChildAt(21);
		}
	}
}