/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_bar : GProgressBar
	{
		public GGraph m_n0;
		public GImage m_bar;

		public const string URL = "ui://x31qyfgg9jf63g";

		public static UI_bar CreateInstance()
		{
			return (UI_bar)UIPackage.CreateObject("Classic","bar");
		}

		public UI_bar()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GGraph)this.GetChildAt(0);
			m_bar = (GImage)this.GetChildAt(1);
		}
	}
}