/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SendRedEnvelope
{
	public partial class UI_red_50W : GComponent
	{
		public GImage m_n1;
		public GImage m_n2;

		public const string URL = "ui://qixddahojt0z6";

		public static UI_red_50W CreateInstance()
		{
			return (UI_red_50W)UIPackage.CreateObject("SendRedEnvelope","red_50W");
		}

		public UI_red_50W()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n1 = (GImage)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
		}
	}
}