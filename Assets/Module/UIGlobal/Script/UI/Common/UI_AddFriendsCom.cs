/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_AddFriendsCom : GComponent
	{
		public GGraph m_n0;
		public GGraph m_n1;
		public GTextField m_txt_title;
		public UI_btn_kamisho m_btn_sure;
		public UI_btn_kamisho m_btn_refuse;

		public const string URL = "ui://eqqn9lxmifa3t81";

		public static UI_AddFriendsCom CreateInstance()
		{
			return (UI_AddFriendsCom)UIPackage.CreateObject("Common","AddFriendsCom");
		}

		public UI_AddFriendsCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GGraph)this.GetChildAt(0);
			m_n1 = (GGraph)this.GetChildAt(1);
			m_txt_title = (GTextField)this.GetChildAt(2);
			m_btn_sure = (UI_btn_kamisho)this.GetChildAt(3);
			m_btn_refuse = (UI_btn_kamisho)this.GetChildAt(4);
		}
	}
}