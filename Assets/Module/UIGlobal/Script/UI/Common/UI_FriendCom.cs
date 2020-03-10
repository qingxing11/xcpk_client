/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_FriendCom : GComponent
	{
		public Controller m_c1;
		public GImage m_bg;
		public GLoader m_icon;
		public GLoader m_lv_icon;
		public GTextField m_txt_lv;
		public GTextField m_txt_ID;
		public GRichTextField m_txt_nike;
		public UI_btn_addFriend2 m_btn_addFriend;

		public const string URL = "ui://eqqn9lxmfz639q";

		public static UI_FriendCom CreateInstance()
		{
			return (UI_FriendCom)UIPackage.CreateObject("Common","FriendCom");
		}

		public UI_FriendCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_bg = (GImage)this.GetChildAt(0);
			m_icon = (GLoader)this.GetChildAt(1);
			m_lv_icon = (GLoader)this.GetChildAt(2);
			m_txt_lv = (GTextField)this.GetChildAt(3);
			m_txt_ID = (GTextField)this.GetChildAt(4);
			m_txt_nike = (GRichTextField)this.GetChildAt(5);
			m_btn_addFriend = (UI_btn_addFriend2)this.GetChildAt(6);
		}
	}
}