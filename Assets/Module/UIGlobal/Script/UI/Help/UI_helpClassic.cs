/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Help
{
	public partial class UI_helpClassic : GComponent
	{
		public GImage m_n0;
		public GImage m_n2;
		public GImage m_n1;
		public GImage m_n3;
		public GImage m_n14;
		public UI_btn_close m_btn_close;
		public GList m_n16;

		public const string URL = "ui://exihkvm8kudqm";

		public static UI_helpClassic CreateInstance()
		{
			return (UI_helpClassic)UIPackage.CreateObject("Help","helpClassic");
		}

		public UI_helpClassic()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
			m_n1 = (GImage)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
			m_n14 = (GImage)this.GetChildAt(4);
			m_btn_close = (UI_btn_close)this.GetChildAt(5);
			m_n16 = (GList)this.GetChildAt(6);
		}
	}
}