/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_Banned : GComponent
	{
		public GImage m_n0;
		public GImage m_n1;
		public GTextField m_n2;
		public UI_btn_sure_g1 m_btn_sure;
		public GTextField m_bannedId;
		public GTextField m_n12;
		public GTextField m_n13;

		public const string URL = "ui://du637vw1m88yy1f";

		public static UI_Banned CreateInstance()
		{
			return (UI_Banned)UIPackage.CreateObject("Main","Banned");
		}

		public UI_Banned()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GTextField)this.GetChildAt(2);
			m_btn_sure = (UI_btn_sure_g1)this.GetChildAt(3);
			m_bannedId = (GTextField)this.GetChildAt(4);
			m_n12 = (GTextField)this.GetChildAt(5);
			m_n13 = (GTextField)this.GetChildAt(6);
		}
	}
}