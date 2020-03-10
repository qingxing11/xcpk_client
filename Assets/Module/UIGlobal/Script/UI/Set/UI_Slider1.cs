/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_Slider1 : GSlider
	{
		public GImage m_n0;
		public GImage m_bar;
		public UI_Slider1_grip m_grip;

		public const string URL = "ui://4f5tb9ztdpct96";

		public static UI_Slider1 CreateInstance()
		{
			return (UI_Slider1)UIPackage.CreateObject("Set","Slider1");
		}

		public UI_Slider1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_bar = (GImage)this.GetChildAt(1);
			m_grip = (UI_Slider1_grip)this.GetChildAt(2);
		}
	}
}