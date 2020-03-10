/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_tiShi1 : GComponent
	{
		public GImage m_n0;
		public GTextField m_n1;
		public GRichTextField m_name;
		public GTextField m_n3;

		public const string URL = "ui://jbql1kzap1gk2o";

		public static UI_tiShi1 CreateInstance()
		{
			return (UI_tiShi1)UIPackage.CreateObject("GameTask","tiShi1");
		}

		public UI_tiShi1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GTextField)this.GetChildAt(1);
			m_name = (GRichTextField)this.GetChildAt(2);
			m_n3 = (GTextField)this.GetChildAt(3);
		}
	}
}