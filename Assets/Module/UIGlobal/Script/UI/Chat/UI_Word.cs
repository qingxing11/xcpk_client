/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_Word : GComponent
	{
		public GLoader m_right;
		public GLoader m_left;
		public GLoader m_down;
		public UI_creatWord m_txt_com;

		public const string URL = "ui://kxabpsetkouvvr";

		public static UI_Word CreateInstance()
		{
			return (UI_Word)UIPackage.CreateObject("Chat","Word");
		}

		public UI_Word()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_right = (GLoader)this.GetChildAt(0);
			m_left = (GLoader)this.GetChildAt(1);
			m_down = (GLoader)this.GetChildAt(2);
			m_txt_com = (UI_creatWord)this.GetChildAt(3);
		}
	}
}