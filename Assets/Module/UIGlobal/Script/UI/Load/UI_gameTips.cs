/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Load
{
	public partial class UI_gameTips : GComponent
	{
		public GImage m_n0;

		public const string URL = "ui://dzfevmlrh81j1b";

		public static UI_gameTips CreateInstance()
		{
			return (UI_gameTips)UIPackage.CreateObject("Load","gameTips");
		}

		public UI_gameTips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
		}
	}
}