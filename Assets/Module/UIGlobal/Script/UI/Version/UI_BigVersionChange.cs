/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Version
{
	public partial class UI_BigVersionChange : GComponent
	{
		public GImage m_bg;
		public UI_btn_ok m_btn_ok;
		public UI_btn_close m_btn_close;
		public GTextField m_n18;
		public GTextField m_n19;

		public const string URL = "ui://8o9h3wfnkszr1";

		public static UI_BigVersionChange CreateInstance()
		{
			return (UI_BigVersionChange)UIPackage.CreateObject("Version","BigVersionChange");
		}

		public UI_BigVersionChange()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_bg = (GImage)this.GetChildAt(0);
			m_btn_ok = (UI_btn_ok)this.GetChildAt(1);
			m_btn_close = (UI_btn_close)this.GetChildAt(2);
			m_n18 = (GTextField)this.GetChildAt(3);
			m_n19 = (GTextField)this.GetChildAt(4);
		}
	}
}