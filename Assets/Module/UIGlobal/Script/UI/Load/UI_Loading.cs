/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Load
{
	public partial class UI_Loading : GComponent
	{
		public GImage m_n0;
		public UI_ProgressBar1 m_loadIndex;
		public GImage m_n5;

		public const string URL = "ui://dzfevmlrfdzr0";

		public static UI_Loading CreateInstance()
		{
			return (UI_Loading)UIPackage.CreateObject("Load","Loading");
		}

		public UI_Loading()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_loadIndex = (UI_ProgressBar1)this.GetChildAt(1);
			m_n5 = (GImage)this.GetChildAt(2);
		}
	}
}