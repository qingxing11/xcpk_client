/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_vrOrls : GComponent
	{
		public GList m_list_banker;
		public GList m_list_east;
		public GList m_list_south;
		public GList m_list_west;
		public GList m_list_north;
		public GGroup m_n5;

		public const string URL = "ui://es6hjd4tt37kxz7";

		public static UI_vrOrls CreateInstance()
		{
			return (UI_vrOrls)UIPackage.CreateObject("Room","vrOrls");
		}

		public UI_vrOrls()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_list_banker = (GList)this.GetChildAt(0);
			m_list_east = (GList)this.GetChildAt(1);
			m_list_south = (GList)this.GetChildAt(2);
			m_list_west = (GList)this.GetChildAt(3);
			m_list_north = (GList)this.GetChildAt(4);
			m_n5 = (GGroup)this.GetChildAt(5);
		}
	}
}