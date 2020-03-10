/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_gold : GComponent
	{
		public GImage m_n0;

		public const string URL = "ui://es6hjd4ttwaaxvu";

		public static UI_gold CreateInstance()
		{
			return (UI_gold)UIPackage.CreateObject("Room","gold");
		}

		public UI_gold()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
		}
	}
}