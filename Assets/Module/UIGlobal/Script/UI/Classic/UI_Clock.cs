/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_Clock : GComponent
	{
		public GImage m_n0;
		public GTextField m_timer;

		public const string URL = "ui://x31qyfgg9jf63k";

		public static UI_Clock CreateInstance()
		{
			return (UI_Clock)UIPackage.CreateObject("Classic","Clock");
		}

		public UI_Clock()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_timer = (GTextField)this.GetChildAt(1);
		}
	}
}