/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_cards : GComponent
	{
		public GLoader m_n0;
		public GLoader m_n1;
		public GLoader m_n2;
		public GImage m_n3;

		public const string URL = "ui://es6hjd4trk79vp";

		public static UI_cards CreateInstance()
		{
			return (UI_cards)UIPackage.CreateObject("Room","cards");
		}

		public UI_cards()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GLoader)this.GetChildAt(0);
			m_n1 = (GLoader)this.GetChildAt(1);
			m_n2 = (GLoader)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
		}
	}
}