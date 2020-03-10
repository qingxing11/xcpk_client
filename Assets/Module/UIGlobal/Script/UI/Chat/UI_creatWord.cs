/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_creatWord : GComponent
	{
		public Controller m_c1;
		public GImage m_n1;
		public GRichTextField m_txt;
		public GLoader m_icon_vipLv;
		public GRichTextField m_txt_name;
		public GRichTextField m_txt_vipLv;
		public GGroup m_n5;
		public Transition m_t0;

		public const string URL = "ui://kxabpsetpr8fxvs";

		public static UI_creatWord CreateInstance()
		{
			return (UI_creatWord)UIPackage.CreateObject("Chat","creatWord");
		}

		public UI_creatWord()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n1 = (GImage)this.GetChildAt(0);
			m_txt = (GRichTextField)this.GetChildAt(1);
			m_icon_vipLv = (GLoader)this.GetChildAt(2);
			m_txt_name = (GRichTextField)this.GetChildAt(3);
			m_txt_vipLv = (GRichTextField)this.GetChildAt(4);
			m_n5 = (GGroup)this.GetChildAt(5);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}