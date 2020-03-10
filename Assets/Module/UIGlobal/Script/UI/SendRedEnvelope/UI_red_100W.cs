/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SendRedEnvelope
{
	public partial class UI_red_100W : GComponent
	{
		public GImage m_n3;
		public GImage m_n4;

		public const string URL = "ui://qixddahojt0z7";

		public static UI_red_100W CreateInstance()
		{
			return (UI_red_100W)UIPackage.CreateObject("SendRedEnvelope","red_100W");
		}

		public UI_red_100W()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n3 = (GImage)this.GetChildAt(0);
			m_n4 = (GImage)this.GetChildAt(1);
		}
	}
}