/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Load
{
	public partial class UI_ProgressBar1 : GProgressBar
	{
		public GImage m_n0;
		public GImage m_bar;
		public GLoader m_n2;

		public const string URL = "ui://dzfevmlrfdzr17";

		public static UI_ProgressBar1 CreateInstance()
		{
			return (UI_ProgressBar1)UIPackage.CreateObject("Load","ProgressBar1");
		}

		public UI_ProgressBar1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_bar = (GImage)this.GetChildAt(1);
			m_n2 = (GLoader)this.GetChildAt(2);
		}
	}
}