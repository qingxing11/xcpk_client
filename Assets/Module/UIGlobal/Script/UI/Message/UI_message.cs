/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Message
{
	public partial class UI_message : GComponent
	{
		public GImage m_n2;
		public GTextField m_text_content;
		public Transition m_t0;

		public const string URL = "ui://2pj4ie0up31v0";

		public static UI_message CreateInstance()
		{
			return (UI_message)UIPackage.CreateObject("Message","message");
		}

		public UI_message()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n2 = (GImage)this.GetChildAt(0);
			m_text_content = (GTextField)this.GetChildAt(1);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}