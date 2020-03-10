/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Help
{
	public partial class UI_help : GComponent
	{
		public GImage m_n0;
		public GImage m_n2;
		public GImage m_n1;
		public GImage m_n3;
		public GImage m_n4;
		public GImage m_n5;
		public GImage m_n6;
		public GImage m_n7;
		public GImage m_n8;
		public GImage m_n9;
		public GImage m_n10;
		public GImage m_n11;
		public GImage m_n12;
		public GImage m_n14;
		public UI_btn_close m_btn_close;

		public const string URL = "ui://exihkvm8kudqn";

		public static UI_help CreateInstance()
		{
			return (UI_help)UIPackage.CreateObject("Help","help");
		}

		public UI_help()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
			m_n1 = (GImage)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
			m_n4 = (GImage)this.GetChildAt(4);
			m_n5 = (GImage)this.GetChildAt(5);
			m_n6 = (GImage)this.GetChildAt(6);
			m_n7 = (GImage)this.GetChildAt(7);
			m_n8 = (GImage)this.GetChildAt(8);
			m_n9 = (GImage)this.GetChildAt(9);
			m_n10 = (GImage)this.GetChildAt(10);
			m_n11 = (GImage)this.GetChildAt(11);
			m_n12 = (GImage)this.GetChildAt(12);
			m_n14 = (GImage)this.GetChildAt(13);
			m_btn_close = (UI_btn_close)this.GetChildAt(14);
		}
	}
}