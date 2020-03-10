/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_txtCom3 : GComponent
	{
		public GRichTextField m_txt_title;
		public GImage m_n4;

		public const string URL = "ui://kxabpsetotjz5xxy";

		public static UI_txtCom3 CreateInstance()
		{
			return (UI_txtCom3)UIPackage.CreateObject("Chat","txtCom3");
		}

		public UI_txtCom3()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_txt_title = (GRichTextField)this.GetChildAt(0);
			m_n4 = (GImage)this.GetChildAt(1);
		}
	}
}