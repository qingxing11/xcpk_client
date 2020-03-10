/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace More
{
	public partial class UI_more : GComponent
	{
		public Controller m_c1;
		public GImage m_bg;
		public UI_btn_Fruit m_btn_fruit;
		public UI_btn_room2 m_btn_kill;
		public UI_btn_room3 m_btn_wanren;
		public UI_btn_room4 m_btn_classic;
		public GRichTextField m_text_packUp;

		public const string URL = "ui://46dmj4zsbbbs0";

		public static UI_more CreateInstance()
		{
			return (UI_more)UIPackage.CreateObject("More","more");
		}

		public UI_more()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_bg = (GImage)this.GetChildAt(0);
			m_btn_fruit = (UI_btn_Fruit)this.GetChildAt(1);
			m_btn_kill = (UI_btn_room2)this.GetChildAt(2);
			m_btn_wanren = (UI_btn_room3)this.GetChildAt(3);
			m_btn_classic = (UI_btn_room4)this.GetChildAt(4);
			m_text_packUp = (GRichTextField)this.GetChildAt(5);
		}
	}
}