/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_ReturnPanel : GComponent
	{
		public GImage m_n7;
		public UI_btn_return m_btn_return;
		public UI_btn_set m_btn_set;
		public UI_btn_bangzhu m_btn_help;

		public const string URL = "ui://l17p56hbob03tg1";

		public static UI_ReturnPanel CreateInstance()
		{
			return (UI_ReturnPanel)UIPackage.CreateObject("FruitMachine","ReturnPanel");
		}

		public UI_ReturnPanel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n7 = (GImage)this.GetChildAt(0);
			m_btn_return = (UI_btn_return)this.GetChildAt(1);
			m_btn_set = (UI_btn_set)this.GetChildAt(2);
			m_btn_help = (UI_btn_bangzhu)this.GetChildAt(3);
		}
	}
}