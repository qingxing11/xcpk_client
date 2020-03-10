/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_GglMenu : GComponent
	{
		public GImage m_n1;
		public UI_Button_back m_btn_exit;
		public UI_Button_menu m_n3;
		public GImage m_n24;
		public GTextField m_text_gold;
		public GLoader m_btn_game0;
		public GLoader m_btn_game1;
		public GLoader m_btn_game2;

		public const string URL = "ui://rjmn7jeuec6rm";

		public static UI_GglMenu CreateInstance()
		{
			return (UI_GglMenu)UIPackage.CreateObject("Guaguale","GglMenu");
		}

		public UI_GglMenu()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n1 = (GImage)this.GetChildAt(0);
			m_btn_exit = (UI_Button_back)this.GetChildAt(1);
			m_n3 = (UI_Button_menu)this.GetChildAt(2);
			m_n24 = (GImage)this.GetChildAt(3);
			m_text_gold = (GTextField)this.GetChildAt(4);
			m_btn_game0 = (GLoader)this.GetChildAt(5);
			m_btn_game1 = (GLoader)this.GetChildAt(6);
			m_btn_game2 = (GLoader)this.GetChildAt(7);
		}
	}
}