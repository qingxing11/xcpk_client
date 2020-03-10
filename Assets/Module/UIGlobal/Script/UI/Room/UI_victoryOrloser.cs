/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_victoryOrloser : GComponent
	{
		public Controller m_c1;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;

		public const string URL = "ui://es6hjd4tt37kxz5";

		public static UI_victoryOrloser CreateInstance()
		{
			return (UI_victoryOrloser)UIPackage.CreateObject("Room","victoryOrloser");
		}

		public UI_victoryOrloser()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
		}
	}
}