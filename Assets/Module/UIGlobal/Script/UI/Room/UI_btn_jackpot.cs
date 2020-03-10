/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_btn_jackpot : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GTextField m_text_conis;

		public const string URL = "ui://es6hjd4thm3axxu";

		public static UI_btn_jackpot CreateInstance()
		{
			return (UI_btn_jackpot)UIPackage.CreateObject("Room","btn_jackpot");
		}

		public UI_btn_jackpot()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_text_conis = (GTextField)this.GetChildAt(2);
		}
	}
}