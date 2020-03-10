/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_mask : GComponent
	{
		public Controller m_scale;
		public GImage m_mask1;
		public Transition m_t0;

		public const string URL = "ui://l17p56hbi2c9t98";

		public static UI_mask CreateInstance()
		{
			return (UI_mask)UIPackage.CreateObject("FruitMachine","mask");
		}

		public UI_mask()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_scale = this.GetControllerAt(0);
			m_mask1 = (GImage)this.GetChildAt(0);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}