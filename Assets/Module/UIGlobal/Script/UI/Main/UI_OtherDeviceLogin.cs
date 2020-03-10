/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_OtherDeviceLogin : GComponent
	{
		public GImage m_n0;
		public GImage m_n1;
		public UI_btn_sure_g1 m_btn_sure;
		public GTextField m_n12;

		public const string URL = "ui://du637vw1mcs8y1e";

		public static UI_OtherDeviceLogin CreateInstance()
		{
			return (UI_OtherDeviceLogin)UIPackage.CreateObject("Main","OtherDeviceLogin");
		}

		public UI_OtherDeviceLogin()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_btn_sure = (UI_btn_sure_g1)this.GetChildAt(2);
			m_n12 = (GTextField)this.GetChildAt(3);
		}
	}
}