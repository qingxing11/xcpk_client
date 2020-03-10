/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lottery
{
	public partial class UI_GglWin : GComponent
	{
		public GTextField m_txt_coinNUm;
		public Transition m_t0;

		public const string URL = "ui://czzshd91ezha6l";

		public static UI_GglWin CreateInstance()
		{
			return (UI_GglWin)UIPackage.CreateObject("Lottery","GglWin");
		}

		public UI_GglWin()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_txt_coinNUm = (GTextField)this.GetChildAt(0);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}