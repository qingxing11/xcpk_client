/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_UpBankerList : GComponent
	{
		public Controller m_upOrDown;
		public GLoader m_btn_close;
		public GImage m_n2;
		public GTextField m_n9;
		public GTextField m_n10;
		public GList m_playerList;
		public UI_btn_requestUpDesk m_upBanker;
		public UI_btn_requestUpDesk m_downBanker;
		public GImage m_n14;
		public GImage m_n15;
		public GImage m_n16;
		public GTextField m_n18;
		public GTextField m_n19;
		public GTextField m_n20;

		public const string URL = "ui://efj6gsloenaq2q";

		public static UI_UpBankerList CreateInstance()
		{
			return (UI_UpBankerList)UIPackage.CreateObject("TenThousandField","UpBankerList");
		}

		public UI_UpBankerList()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_upOrDown = this.GetControllerAt(0);
			m_btn_close = (GLoader)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
			m_n9 = (GTextField)this.GetChildAt(2);
			m_n10 = (GTextField)this.GetChildAt(3);
			m_playerList = (GList)this.GetChildAt(4);
			m_upBanker = (UI_btn_requestUpDesk)this.GetChildAt(5);
			m_downBanker = (UI_btn_requestUpDesk)this.GetChildAt(6);
			m_n14 = (GImage)this.GetChildAt(7);
			m_n15 = (GImage)this.GetChildAt(8);
			m_n16 = (GImage)this.GetChildAt(9);
			m_n18 = (GTextField)this.GetChildAt(10);
			m_n19 = (GTextField)this.GetChildAt(11);
			m_n20 = (GTextField)this.GetChildAt(12);
		}
	}
}