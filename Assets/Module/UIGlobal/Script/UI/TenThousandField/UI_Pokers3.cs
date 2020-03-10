/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_Pokers3 : GComponent
	{
		public GImage m_card_back1;
		public GImage m_card_back2;
		public GImage m_card_back3;
		public Transition m_Anim1;

		public const string URL = "ui://efj6gslory4w3w";

		public static UI_Pokers3 CreateInstance()
		{
			return (UI_Pokers3)UIPackage.CreateObject("TenThousandField","Pokers3");
		}

		public UI_Pokers3()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_card_back1 = (GImage)this.GetChildAt(0);
			m_card_back2 = (GImage)this.GetChildAt(1);
			m_card_back3 = (GImage)this.GetChildAt(2);
			m_Anim1 = this.GetTransitionAt(0);
		}
	}
}