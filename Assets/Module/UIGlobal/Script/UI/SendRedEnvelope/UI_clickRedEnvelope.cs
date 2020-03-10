/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SendRedEnvelope
{
	public partial class UI_clickRedEnvelope : GComponent
	{
		public GImage m_n3;
		public GLoader m_click;

		public const string URL = "ui://qixddahone4ka";

		public static UI_clickRedEnvelope CreateInstance()
		{
			return (UI_clickRedEnvelope)UIPackage.CreateObject("SendRedEnvelope","clickRedEnvelope");
		}

		public UI_clickRedEnvelope()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n3 = (GImage)this.GetChildAt(0);
			m_click = (GLoader)this.GetChildAt(1);
		}
	}
}