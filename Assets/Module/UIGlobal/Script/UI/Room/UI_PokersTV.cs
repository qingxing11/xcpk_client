/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_PokersTV : GComponent
	{
		public Controller m_c1;
		public UI_Pokers m_pokers;

		public const string URL = "ui://es6hjd4tjr4by1e";

		public static UI_PokersTV CreateInstance()
		{
			return (UI_PokersTV)UIPackage.CreateObject("Room","PokersTV");
		}

		public UI_PokersTV()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_pokers = (UI_Pokers)this.GetChildAt(0);
		}
	}
}