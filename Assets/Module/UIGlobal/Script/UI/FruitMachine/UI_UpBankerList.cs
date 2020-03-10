/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_UpBankerList : GComponent
	{
		public Controller m_upOrDownBanker;
		public GLoader m_btn_close;
		public GImage m_bg;
		public GList m_players;
		public UI_btn_UpBanker m_btn_upBanker;
		public UI_downBanker m_btn_downBanker;
		public GTextField m_text_conis;
		public GTextField m_text_conis_2;

		public const string URL = "ui://l17p56hbue6cteg";

		public static UI_UpBankerList CreateInstance()
		{
			return (UI_UpBankerList)UIPackage.CreateObject("FruitMachine","UpBankerList");
		}

		public UI_UpBankerList()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_upOrDownBanker = this.GetControllerAt(0);
			m_btn_close = (GLoader)this.GetChildAt(0);
			m_bg = (GImage)this.GetChildAt(1);
			m_players = (GList)this.GetChildAt(2);
			m_btn_upBanker = (UI_btn_UpBanker)this.GetChildAt(3);
			m_btn_downBanker = (UI_downBanker)this.GetChildAt(4);
			m_text_conis = (GTextField)this.GetChildAt(5);
			m_text_conis_2 = (GTextField)this.GetChildAt(6);
		}
	}
}