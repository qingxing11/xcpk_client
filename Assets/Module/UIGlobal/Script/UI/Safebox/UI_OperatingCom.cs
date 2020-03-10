/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Safebox
{
	public partial class UI_OperatingCom : GComponent
	{
		public GImage m_bg;
		public GTextField m_txt_time;
		public GTextField m_txt_kind;
		public GTextField m_txt_tmoney;
		public GTextField m_txt_ID;

		public const string URL = "ui://ey7bc1rcrwpf20";

		public static UI_OperatingCom CreateInstance()
		{
			return (UI_OperatingCom)UIPackage.CreateObject("Safebox","OperatingCom");
		}

		public UI_OperatingCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_bg = (GImage)this.GetChildAt(0);
			m_txt_time = (GTextField)this.GetChildAt(1);
			m_txt_kind = (GTextField)this.GetChildAt(2);
			m_txt_tmoney = (GTextField)this.GetChildAt(3);
			m_txt_ID = (GTextField)this.GetChildAt(4);
		}
	}
}