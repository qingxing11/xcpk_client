/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_bankerInfo : GComponent
	{
		public GImage m_n196;
		public GLoader m_icon;
		public GImage m_n197;
		public GTextField m_txt_bankerNike;
		public GImage m_n200;
		public GTextField m_txt_bankerCoins;
		public GLoader m_vip;

		public const string URL = "ui://l17p56hbdku5tev";

		public static UI_bankerInfo CreateInstance()
		{
			return (UI_bankerInfo)UIPackage.CreateObject("FruitMachine","bankerInfo");
		}

		public UI_bankerInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n196 = (GImage)this.GetChildAt(0);
			m_icon = (GLoader)this.GetChildAt(1);
			m_n197 = (GImage)this.GetChildAt(2);
			m_txt_bankerNike = (GTextField)this.GetChildAt(3);
			m_n200 = (GImage)this.GetChildAt(4);
			m_txt_bankerCoins = (GTextField)this.GetChildAt(5);
			m_vip = (GLoader)this.GetChildAt(6);
		}
	}
}