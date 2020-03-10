/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FirstCZ
{
	public partial class UI_Firstcharge : GComponent
	{
		public GImage m_bg;
		public GImage m_n0;
		public UI_btn_close m_btn_close;
		public GImage m_n4;
		public GImage m_n3;
		public GImage m_n9;
		public GImage m_n10;
		public GImage m_n6;
		public UI_Point m_Point;
		public GTextField m_n14;
		public GTextField m_n15;

		public const string URL = "ui://e0ws505f7gaci";

		public static UI_Firstcharge CreateInstance()
		{
			return (UI_Firstcharge)UIPackage.CreateObject("FirstCZ","Firstcharge");
		}

		public UI_Firstcharge()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_bg = (GImage)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
			m_btn_close = (UI_btn_close)this.GetChildAt(2);
			m_n4 = (GImage)this.GetChildAt(3);
			m_n3 = (GImage)this.GetChildAt(4);
			m_n9 = (GImage)this.GetChildAt(5);
			m_n10 = (GImage)this.GetChildAt(6);
			m_n6 = (GImage)this.GetChildAt(7);
			m_Point = (UI_Point)this.GetChildAt(8);
			m_n14 = (GTextField)this.GetChildAt(9);
			m_n15 = (GTextField)this.GetChildAt(10);
		}
	}
}