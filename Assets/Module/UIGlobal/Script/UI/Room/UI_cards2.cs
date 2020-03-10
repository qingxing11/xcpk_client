/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_cards2 : GComponent
	{
		public GLoader m_n0;
		public GLoader m_n1;
		public GLoader m_n2;

		public const string URL = "ui://es6hjd4tk5ym1y3h";

		public static UI_cards2 CreateInstance()
		{
			return (UI_cards2)UIPackage.CreateObject("Room","cards2");
		}

		public UI_cards2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GLoader)this.GetChildAt(0);
			m_n1 = (GLoader)this.GetChildAt(1);
			m_n2 = (GLoader)this.GetChildAt(2);
		}
	}
}