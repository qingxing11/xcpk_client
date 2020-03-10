/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UpBankerList
{
	public partial class UI_UpBankerList : GComponent
	{
		public GImage m_n19;
		public GImage m_n11;
		public GImage m_n10;
		public GList m_list;
		public GImage m_n12;
		public GImage m_n13;
		public UI_btn_upBanker m_btn_upbank;
		public GTextField m_text_conis;
		public GTextField m_text_conis_2;

		public const string URL = "ui://septv56poymb8";

		public static UI_UpBankerList CreateInstance()
		{
			return (UI_UpBankerList)UIPackage.CreateObject("UpBankerList","UpBankerList");
		}

		public UI_UpBankerList()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n19 = (GImage)this.GetChildAt(0);
			m_n11 = (GImage)this.GetChildAt(1);
			m_n10 = (GImage)this.GetChildAt(2);
			m_list = (GList)this.GetChildAt(3);
			m_n12 = (GImage)this.GetChildAt(4);
			m_n13 = (GImage)this.GetChildAt(5);
			m_btn_upbank = (UI_btn_upBanker)this.GetChildAt(6);
			m_text_conis = (GTextField)this.GetChildAt(7);
			m_text_conis_2 = (GTextField)this.GetChildAt(8);
		}
	}
}