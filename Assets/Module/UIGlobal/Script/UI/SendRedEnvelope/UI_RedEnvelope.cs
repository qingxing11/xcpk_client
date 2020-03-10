/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SendRedEnvelope
{
	public partial class UI_RedEnvelope : GComponent
	{
		public GLoader m_clickHide;
		public UI_red_50W m_red_50W;
		public UI_red_100W m_red_100W;
		public UI_red_200W m_red_200W;

		public const string URL = "ui://qixddahojt0z5";

		public static UI_RedEnvelope CreateInstance()
		{
			return (UI_RedEnvelope)UIPackage.CreateObject("SendRedEnvelope","RedEnvelope");
		}

		public UI_RedEnvelope()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_clickHide = (GLoader)this.GetChildAt(0);
			m_red_50W = (UI_red_50W)this.GetChildAt(1);
			m_red_100W = (UI_red_100W)this.GetChildAt(2);
			m_red_200W = (UI_red_200W)this.GetChildAt(3);
		}
	}
}