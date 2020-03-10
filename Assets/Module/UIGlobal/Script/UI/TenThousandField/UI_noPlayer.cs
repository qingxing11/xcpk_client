/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_noPlayer : GComponent
	{
		public GImage m_n19;

		public const string URL = "ui://efj6gsloglfq6q";

		public static UI_noPlayer CreateInstance()
		{
			return (UI_noPlayer)UIPackage.CreateObject("TenThousandField","noPlayer");
		}

		public UI_noPlayer()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n19 = (GImage)this.GetChildAt(0);
		}
	}
}