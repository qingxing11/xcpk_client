/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Message
{
	public partial class UI_winOrLoss : GComponent
	{
		public GGraph m_n5;
		public GTextField m_text_content;
		public Transition m_t0;

		public const string URL = "ui://2pj4ie0uumfa9";

		public static UI_winOrLoss CreateInstance()
		{
			return (UI_winOrLoss)UIPackage.CreateObject("Message","winOrLoss");
		}

		public UI_winOrLoss()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n5 = (GGraph)this.GetChildAt(0);
			m_text_content = (GTextField)this.GetChildAt(1);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}