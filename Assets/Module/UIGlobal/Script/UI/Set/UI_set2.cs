/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_set2 : GComponent
	{
		public Controller m_c_sound;
		public Controller m_c_music;
		public GImage m_n82;
		public GImage m_n83;
		public UI_Slider1 m_Slider_sound;
		public UI_Slider1 m_Slider_music;
		public GImage m_n41;
		public GImage m_n42;
		public UI_btn_close m_btn_close;
		public GImage m_bg;
		public GImage m_bg_2;
		public UI_btn_set m_btn_sound;
		public UI_btn_set m_btn_music;
		public GImage m_n84;
		public GImage m_n86;

		public const string URL = "ui://4f5tb9ztdz5o9s";

		public static UI_set2 CreateInstance()
		{
			return (UI_set2)UIPackage.CreateObject("Set","set2");
		}

		public UI_set2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c_sound = this.GetControllerAt(0);
			m_c_music = this.GetControllerAt(1);
			m_n82 = (GImage)this.GetChildAt(0);
			m_n83 = (GImage)this.GetChildAt(1);
			m_Slider_sound = (UI_Slider1)this.GetChildAt(2);
			m_Slider_music = (UI_Slider1)this.GetChildAt(3);
			m_n41 = (GImage)this.GetChildAt(4);
			m_n42 = (GImage)this.GetChildAt(5);
			m_btn_close = (UI_btn_close)this.GetChildAt(6);
			m_bg = (GImage)this.GetChildAt(7);
			m_bg_2 = (GImage)this.GetChildAt(8);
			m_btn_sound = (UI_btn_set)this.GetChildAt(9);
			m_btn_music = (UI_btn_set)this.GetChildAt(10);
			m_n84 = (GImage)this.GetChildAt(11);
			m_n86 = (GImage)this.GetChildAt(12);
		}
	}
}