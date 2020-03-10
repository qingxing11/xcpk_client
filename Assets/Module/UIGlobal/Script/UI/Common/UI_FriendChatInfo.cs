/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_FriendChatInfo : GComponent
	{
		public Controller m_c1;
		public GImage m_n2;
		public GTextField m_txt_left;
		public GLoader m_left_icon;
		public GLoader m_left_vip;
		public GGroup m_left;
		public GImage m_n3;
		public GTextField m_txt_right;
		public GLoader m_right_icon;
		public GLoader m_right_vip;
		public GGroup m_right;

		public const string URL = "ui://eqqn9lxmh1lwtap";

		public static UI_FriendChatInfo CreateInstance()
		{
			return (UI_FriendChatInfo)UIPackage.CreateObject("Common","FriendChatInfo");
		}

		public UI_FriendChatInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
			m_txt_left = (GTextField)this.GetChildAt(1);
			m_left_icon = (GLoader)this.GetChildAt(2);
			m_left_vip = (GLoader)this.GetChildAt(3);
			m_left = (GGroup)this.GetChildAt(4);
			m_n3 = (GImage)this.GetChildAt(5);
			m_txt_right = (GTextField)this.GetChildAt(6);
			m_right_icon = (GLoader)this.GetChildAt(7);
			m_right_vip = (GLoader)this.GetChildAt(8);
			m_right = (GGroup)this.GetChildAt(9);
		}
	}
}