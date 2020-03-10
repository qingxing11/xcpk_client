/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_text_selfCoins : GComponent
	{
		public GImage m_n2;
		public GTextField m_text_coins;

		public const string URL = "ui://es6hjd4tp31vy0h";

		public static UI_text_selfCoins CreateInstance()
		{
			return (UI_text_selfCoins)UIPackage.CreateObject("Room","text_selfCoins");
		}

		public UI_text_selfCoins()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n2 = (GImage)this.GetChildAt(0);
			m_text_coins = (GTextField)this.GetChildAt(1);
		}
	}
}