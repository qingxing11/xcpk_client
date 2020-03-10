/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_cards : GComponent
	{
		public Controller m_c_cardType;
		public Controller m_c1;
		public GLoader m_n0;
		public GLoader m_n1;
		public GLoader m_n2;
		public GImage m_n8;
		public GLoader m_n7;

		public const string URL = "ui://x31qyfggkawu2g";

		public static UI_cards CreateInstance()
		{
			return (UI_cards)UIPackage.CreateObject("Classic","cards");
		}

		public UI_cards()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c_cardType = this.GetControllerAt(0);
			m_c1 = this.GetControllerAt(1);
			m_n0 = (GLoader)this.GetChildAt(0);
			m_n1 = (GLoader)this.GetChildAt(1);
			m_n2 = (GLoader)this.GetChildAt(2);
			m_n8 = (GImage)this.GetChildAt(3);
			m_n7 = (GLoader)this.GetChildAt(4);
		}
	}
}