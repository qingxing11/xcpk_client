/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SendRedEnvelope
{
	public partial class UI_showTips : GComponent
	{
		public GRichTextField m_txt_pop;
		public Transition m_show;

		public const string URL = "ui://qixddahofoazi";

		public static UI_showTips CreateInstance()
		{
			return (UI_showTips)UIPackage.CreateObject("SendRedEnvelope","showTips");
		}

		public UI_showTips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_txt_pop = (GRichTextField)this.GetChildAt(0);
			m_show = this.GetTransitionAt(0);
		}
	}
}