/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_HornRecord : GComponent
	{
		public GLoader m_btn_close;
		public GGraph m_n2;
		public GList m_list;
		public GGroup m_recordCom;

		public const string URL = "ui://es6hjd4tvnuly38";

		public static UI_HornRecord CreateInstance()
		{
			return (UI_HornRecord)UIPackage.CreateObject("Room","HornRecord");
		}

		public UI_HornRecord()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_btn_close = (GLoader)this.GetChildAt(0);
			m_n2 = (GGraph)this.GetChildAt(1);
			m_list = (GList)this.GetChildAt(2);
			m_recordCom = (GGroup)this.GetChildAt(3);
		}
	}
}