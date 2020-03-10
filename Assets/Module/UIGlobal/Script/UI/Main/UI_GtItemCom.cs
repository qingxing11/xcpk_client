/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_GtItemCom : GComponent
	{
		public GTextField m_n0;
		public GTextField m_n1;
		public GTextField m_n2;
		public GTextField m_n3;
		public UI_btn_kamisho m_n4;

		public const string URL = "ui://du637vw1hxskt83";

		public static UI_GtItemCom CreateInstance()
		{
			return (UI_GtItemCom)UIPackage.CreateObject("Main","GtItemCom");
		}

		public UI_GtItemCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GTextField)this.GetChildAt(0);
			m_n1 = (GTextField)this.GetChildAt(1);
			m_n2 = (GTextField)this.GetChildAt(2);
			m_n3 = (GTextField)this.GetChildAt(3);
			m_n4 = (UI_btn_kamisho)this.GetChildAt(4);
		}
	}
}