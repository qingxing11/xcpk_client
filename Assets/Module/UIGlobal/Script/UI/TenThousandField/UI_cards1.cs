/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_cards1 : GComponent
	{
		public GLoader m_n0;
		public GLoader m_n1;
		public GLoader m_n2;
		public GImage m_n3;
		public GLoader m_state;

		public const string URL = "ui://efj6gslojb9s6v";

		public static UI_cards1 CreateInstance()
		{
			return (UI_cards1)UIPackage.CreateObject("TenThousandField","cards1");
		}

		public UI_cards1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GLoader)this.GetChildAt(0);
			m_n1 = (GLoader)this.GetChildAt(1);
			m_n2 = (GLoader)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
			m_state = (GLoader)this.GetChildAt(4);
		}
	}
}