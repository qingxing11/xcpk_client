/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_txtCom : GComponent
	{
		public GImage m_n2;
		public GRichTextField m_txt_title;

		public const string URL = "ui://kxabpsetv1nxvo";

		public static UI_txtCom CreateInstance()
		{
			return (UI_txtCom)UIPackage.CreateObject("Chat","txtCom");
		}

		public UI_txtCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n2 = (GImage)this.GetChildAt(0);
			m_txt_title = (GRichTextField)this.GetChildAt(1);
		}
	}
}