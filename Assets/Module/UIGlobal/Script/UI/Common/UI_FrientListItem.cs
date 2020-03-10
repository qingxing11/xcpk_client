/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_FrientListItem : GButton
	{
		public Controller m_c2;
		public GImage m_n2;
		public GImage m_n3;
		public GImage m_selectPoint;
		public GLoader m_icon;
		public GLoader m_lv_icon;
		public GTextField m_txt_lv;
		public GTextField m_txt_ID;
		public GTextField m_txt_nike;
		public GGroup m_n4;

		public const string URL = "ui://eqqn9lxmh1lwtaq";

		public static UI_FrientListItem CreateInstance()
		{
			return (UI_FrientListItem)UIPackage.CreateObject("Common","FrientListItem");
		}

		public UI_FrientListItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c2 = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n3 = (GImage)this.GetChildAt(1);
			m_selectPoint = (GImage)this.GetChildAt(2);
			m_icon = (GLoader)this.GetChildAt(3);
			m_lv_icon = (GLoader)this.GetChildAt(4);
			m_txt_lv = (GTextField)this.GetChildAt(5);
			m_txt_ID = (GTextField)this.GetChildAt(6);
			m_txt_nike = (GTextField)this.GetChildAt(7);
			m_n4 = (GGroup)this.GetChildAt(8);
		}
	}
}