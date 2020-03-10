/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace NetLoading
{
	public partial class UI_NetLoading : GComponent
	{
		public GGraph m_n1;
		public GImage m_n0;
		public Transition m_t1;

		public const string URL = "ui://d51r4rncyg6z1";

		public static UI_NetLoading CreateInstance()
		{
			return (UI_NetLoading)UIPackage.CreateObject("NetLoading","NetLoading");
		}

		public UI_NetLoading()
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