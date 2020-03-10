/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SendRedEnvelope
{
	public partial class UI_red_200W : GComponent
	{
		public GImage m_n5;
		public GImage m_n6;

		public const string URL = "ui://qixddahojt0z8";

		public static UI_red_200W CreateInstance()
		{
			return (UI_red_200W)UIPackage.CreateObject("SendRedEnvelope","red_200W");
		}

		public UI_red_200W()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n5 = (GImage)this.GetChildAt(0);
			m_n6 = (GImage)this.GetChildAt(1);
		}
	}
}