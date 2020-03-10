/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Pay
{
	public partial class UI_zhiFuBao : GComponent
	{
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n3;
		public GImage m_n4;

		public const string URL = "ui://u7z8g3uli2c4e";

		public static UI_zhiFuBao CreateInstance()
		{
			return (UI_zhiFuBao)UIPackage.CreateObject("Pay","zhiFuBao");
		}

		public UI_zhiFuBao()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n3 = (GImage)this.GetChildAt(2);
			m_n4 = (GImage)this.GetChildAt(3);
		}
	}
}