/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_head : GComponent
	{
		public GLoader m_n0;
		public GGraph m_n1;

		public const string URL = "ui://es6hjd4tlmr5xwc";

		public static UI_head CreateInstance()
		{
			return (UI_head)UIPackage.CreateObject("Room","head");
		}

		public UI_head()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GLoader)this.GetChildAt(0);
			m_n1 = (GGraph)this.GetChildAt(1);
		}
	}
}