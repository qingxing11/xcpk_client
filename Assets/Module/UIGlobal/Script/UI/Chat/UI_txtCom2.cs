/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_txtCom2 : GComponent
	{
		public GImage m_n2;
		public GRichTextField m_txt_title;

		public const string URL = "ui://kxabpsetptr45xxe";

		public static UI_txtCom2 CreateInstance()
		{
			return (UI_txtCom2)UIPackage.CreateObject("Chat","txtCom2");
		}

		public UI_txtCom2()
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