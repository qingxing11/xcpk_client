/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace NewLoding
{
	public partial class UI_NewLoading : GComponent
	{
		public GGraph m_n1;
		public GImage m_n0;
		public Transition m_t1;

		public const string URL = "ui://lmwv0rvqkhim4";

		public static UI_NewLoading CreateInstance()
		{
			return (UI_NewLoading)UIPackage.CreateObject("NewLoding","NewLoading");
		}

		public UI_NewLoading()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n1 = (GGraph)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
			m_t1 = this.GetTransitionAt(0);
		}
	}
}