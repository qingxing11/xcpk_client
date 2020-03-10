/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_icon : GComponent
	{
		public GLoader m_n0;

		public const string URL = "ui://es6hjd4tqdhpy2r";

		public static UI_icon CreateInstance()
		{
			return (UI_icon)UIPackage.CreateObject("Room","icon");
		}

		public UI_icon()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GLoader)this.GetChildAt(0);
		}
	}
}