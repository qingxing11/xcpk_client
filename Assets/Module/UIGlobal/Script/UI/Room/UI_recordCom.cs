/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_recordCom : GComponent
	{
		public Controller m_c1;
		public GLoader m_icon;
		public GTextField m_txt_nikeName;
		public GTextField m_txtInfo;
		public GTextField m_txt_title;
		public GTextField m_txtInfo0;

		public const string URL = "ui://es6hjd4tvnuly39";

		public static UI_recordCom CreateInstance()
		{
			return (UI_recordCom)UIPackage.CreateObject("Room","recordCom");
		}

		public UI_recordCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_icon = (GLoader)this.GetChildAt(0);
			m_txt_nikeName = (GTextField)this.GetChildAt(1);
			m_txtInfo = (GTextField)this.GetChildAt(2);
			m_txt_title = (GTextField)this.GetChildAt(3);
			m_txtInfo0 = (GTextField)this.GetChildAt(4);
		}
	}
}