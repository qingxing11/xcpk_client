/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_btn_addFriend : GButton
	{
		public Controller m_button;
		public GImage m_n3;
		public GImage m_n1;

		public const string URL = "ui://eqqn9lxmeyj4t8p";

		public static UI_btn_addFriend CreateInstance()
		{
			return (UI_btn_addFriend)UIPackage.CreateObject("Common","btn_addFriend");
		}

		public UI_btn_addFriend()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n3 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
		}
	}
}