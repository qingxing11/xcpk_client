/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_backSeeItem : GComponent
	{
		public Controller m_winOrLoss;
		public GLoader m_icon;
		public GTextField m_name;
		public GLoader m_card1;
		public GLoader m_card2;
		public GLoader m_card3;
		public GImage m_n10;
		public GImage m_n11;
		public GTextField m_winTxt;
		public GTextField m_lossTxt;

		public const string URL = "ui://efj6gsloo04a9i";

		public static UI_backSeeItem CreateInstance()
		{
			return (UI_backSeeItem)UIPackage.CreateObject("TenThousandField","backSeeItem");
		}

		public UI_backSeeItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_winOrLoss = this.GetControllerAt(0);
			m_icon = (GLoader)this.GetChildAt(0);
			m_name = (GTextField)this.GetChildAt(1);
			m_card1 = (GLoader)this.GetChildAt(2);
			m_card2 = (GLoader)this.GetChildAt(3);
			m_card3 = (GLoader)this.GetChildAt(4);
			m_n10 = (GImage)this.GetChildAt(5);
			m_n11 = (GImage)this.GetChildAt(6);
			m_winTxt = (GTextField)this.GetChildAt(7);
			m_lossTxt = (GTextField)this.GetChildAt(8);
		}
	}
}