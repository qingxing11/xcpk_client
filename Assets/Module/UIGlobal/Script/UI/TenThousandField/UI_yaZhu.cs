/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_yaZhu : GComponent
	{
		public Controller m_big;
		public GLoader m_icon;

		public const string URL = "ui://efj6gsloenaq2p";

		public static UI_yaZhu CreateInstance()
		{
			return (UI_yaZhu)UIPackage.CreateObject("TenThousandField","yaZhu");
		}

		public UI_yaZhu()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_big = this.GetControllerAt(0);
			m_icon = (GLoader)this.GetChildAt(0);
		}
	}
}