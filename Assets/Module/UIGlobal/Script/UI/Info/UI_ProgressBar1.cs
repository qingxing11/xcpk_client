/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Info
{
	public partial class UI_ProgressBar1 : GProgressBar
	{
		public GImage m_n0;
		public GImage m_bar;

		public const string URL = "ui://5wbi0yeup31vtct";

		public static UI_ProgressBar1 CreateInstance()
		{
			return (UI_ProgressBar1)UIPackage.CreateObject("Info","ProgressBar1");
		}

		public UI_ProgressBar1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_bar = (GImage)this.GetChildAt(1);
		}
	}
}