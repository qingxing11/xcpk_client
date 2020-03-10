/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FirstCZ
{
	public partial class UI_Point : GComponent
	{
		public Controller m_c1;
		public GImage m_n1;
		public GImage m_n0;

		public const string URL = "ui://e0ws505fll7fu";

		public static UI_Point CreateInstance()
		{
			return (UI_Point)UIPackage.CreateObject("FirstCZ","Point");
		}

		public UI_Point()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n1 = (GImage)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
		}
	}
}