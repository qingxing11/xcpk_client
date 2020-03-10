/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_backSee : GComponent
	{
		public GImage m_n0;
		public GList m_n3;
		public GTextField m_n5;

		public const string URL = "ui://efj6gsloo04a9g";

		public static UI_backSee CreateInstance()
		{
			return (UI_backSee)UIPackage.CreateObject("TenThousandField","backSee");
		}

		public UI_backSee()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n3 = (GList)this.GetChildAt(1);
			m_n5 = (GTextField)this.GetChildAt(2);
		}
	}
}