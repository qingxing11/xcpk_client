/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_game_chip : GComponent
	{
		public GLoader m_n0;

		public const string URL = "ui://x31qyfggkawu2e";

		public static UI_game_chip CreateInstance()
		{
			return (UI_game_chip)UIPackage.CreateObject("Classic","game_chip");
		}

		public UI_game_chip()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GLoader)this.GetChildAt(0);
		}
	}
}