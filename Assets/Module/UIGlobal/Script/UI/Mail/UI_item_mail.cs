/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Mail
{
	public partial class UI_item_mail : GComponent
	{
		public Controller m_c1;
		public GImage m_n0;
		public GImage m_xinfeng1;
		public GImage m_xinfeng2;
		public GTextField m_text_title;
		public GTextField m_text_from;
		public GTextField m_text_time;

		public const string URL = "ui://ez7i33lmvet0u";

		public static UI_item_mail CreateInstance()
		{
			return (UI_item_mail)UIPackage.CreateObject("Mail","item_mail");
		}

		public UI_item_mail()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_xinfeng1 = (GImage)this.GetChildAt(1);
			m_xinfeng2 = (GImage)this.GetChildAt(2);
			m_text_title = (GTextField)this.GetChildAt(3);
			m_text_from = (GTextField)this.GetChildAt(4);
			m_text_time = (GTextField)this.GetChildAt(5);
		}
	}
}