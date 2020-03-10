/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_btn_addFriend2 : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n2;

		public const string URL = "ui://eqqn9lxmeyj4t8q";

		public static UI_btn_addFriend2 CreateInstance()
		{
			return (UI_btn_addFriend2)UIPackage.CreateObject("Common","btn_addFriend2");
		}

		public UI_btn_addFriend2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
		}
	}
}