/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_ManyPeopleTV : GComponent
	{
		public Controller m_c1;
		public GGraph m_n3;
		public GImage m_n1;
		public UI_RoomManyPeople m_roomMany;
		public UI_btn_close m_btn_close;

		public const string URL = "ui://x31qyfggpxdrc5";

		public static UI_ManyPeopleTV CreateInstance()
		{
			return (UI_ManyPeopleTV)UIPackage.CreateObject("Classic","ManyPeopleTV");
		}

		public UI_ManyPeopleTV()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n3 = (GGraph)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_roomMany = (UI_RoomManyPeople)this.GetChildAt(2);
			m_btn_close = (UI_btn_close)this.GetChildAt(3);
		}
	}
}