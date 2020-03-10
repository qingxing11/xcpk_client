/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_RoomTV : GComponent
	{
		public Controller m_c1;
		public GGraph m_n3;
		public GImage m_n1;
		public UI_RoomFlower m_room;
		public UI_btn_close2 m_n2;

		public const string URL = "ui://es6hjd4tgk8xy1f";

		public static UI_RoomTV CreateInstance()
		{
			return (UI_RoomTV)UIPackage.CreateObject("Room","RoomTV");
		}

		public UI_RoomTV()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n3 = (GGraph)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_room = (UI_RoomFlower)this.GetChildAt(2);
			m_n2 = (UI_btn_close2)this.GetChildAt(3);
		}
	}
}