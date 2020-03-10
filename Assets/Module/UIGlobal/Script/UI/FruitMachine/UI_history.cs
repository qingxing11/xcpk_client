/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_history : GComponent
	{
		public GLoader m_load_1;

		public const string URL = "ui://l17p56hbvgukt99";

		public static UI_history CreateInstance()
		{
			return (UI_history)UIPackage.CreateObject("FruitMachine","history");
		}

		public UI_history()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_load_1 = (GLoader)this.GetChildAt(0);
		}
	}
}