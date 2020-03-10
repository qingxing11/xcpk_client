/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace More
{
	public partial class UI_btn_room3 : GButton
	{
		public Controller m_button;
		public GImage m_n2;
		public GImage m_n3;

		public const string URL = "ui://46dmj4zsbbbsa";

		public static UI_btn_room3 CreateInstance()
		{
			return (UI_btn_room3)UIPackage.CreateObject("More","btn_room3");
		}

		public UI_btn_room3()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n3 = (GImage)this.GetChildAt(1);
		}
	}
}