/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Message
{
	public partial class UI_Low : GComponent
	{
		public GImage m_n7;
		public GTextField m_text_content;
		public Transition m_t0;

		public const string URL = "ui://2pj4ie0uqx2fd";

		public static UI_Low CreateInstance()
		{
			return (UI_Low)UIPackage.CreateObject("Message","Low");
		}

		public UI_Low()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n7 = (GImage)this.GetChildAt(0);
			m_text_content = (GTextField)this.GetChildAt(1);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}