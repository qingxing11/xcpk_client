/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_btn_fastbuy : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://es6hjd4t7gacxy4";

		public static UI_btn_fastbuy CreateInstance()
		{
			return (UI_btn_fastbuy)UIPackage.CreateObject("Room","btn_fastbuy");
		}

		public UI_btn_fastbuy()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
		}
	}
}