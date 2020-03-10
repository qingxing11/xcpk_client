/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_TrendCom : GComponent
	{
		public GImage m_n0;
		public GImage m_n16;
		public GImage m_n7;
		public GImage m_n9;
		public GImage m_n10;
		public GImage m_n11;
		public GImage m_n12;
		public GImage m_n13;
		public GImage m_n14;
		public UI_btn_close m_btn_close;
		public UI_vrOrls m_vrOrls;

		public const string URL = "ui://es6hjd4tv4v9xx2";

		public static UI_TrendCom CreateInstance()
		{
			return (UI_TrendCom)UIPackage.CreateObject("Room","TrendCom");
		}

		public UI_TrendCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n16 = (GImage)this.GetChildAt(1);
			m_n7 = (GImage)this.GetChildAt(2);
			m_n9 = (GImage)this.GetChildAt(3);
			m_n10 = (GImage)this.GetChildAt(4);
			m_n11 = (GImage)this.GetChildAt(5);
			m_n12 = (GImage)this.GetChildAt(6);
			m_n13 = (GImage)this.GetChildAt(7);
			m_n14 = (GImage)this.GetChildAt(8);
			m_btn_close = (UI_btn_close)this.GetChildAt(9);
			m_vrOrls = (UI_vrOrls)this.GetChildAt(10);
		}
	}
}