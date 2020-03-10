/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_OnLineRewardItem : GComponent
	{
		public Controller m_btn_lingQu;
		public GImage m_n12;
		public GTextField m_timeDuan;
		public GTextField m_reward;
		public GImage m_n5;
		public UI_btn_lingJiang m_btn_canLingQu;
		public UI_btn_noLingQu m_btn_noLingQu;
		public UI_btn_yiLingQu m_btn_yiLingQu;

		public const string URL = "ui://jbql1kzagjdg11";

		public static UI_OnLineRewardItem CreateInstance()
		{
			return (UI_OnLineRewardItem)UIPackage.CreateObject("GameTask","OnLineRewardItem");
		}

		public UI_OnLineRewardItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_btn_lingQu = this.GetControllerAt(0);
			m_n12 = (GImage)this.GetChildAt(0);
			m_timeDuan = (GTextField)this.GetChildAt(1);
			m_reward = (GTextField)this.GetChildAt(2);
			m_n5 = (GImage)this.GetChildAt(3);
			m_btn_canLingQu = (UI_btn_lingJiang)this.GetChildAt(4);
			m_btn_noLingQu = (UI_btn_noLingQu)this.GetChildAt(5);
			m_btn_yiLingQu = (UI_btn_yiLingQu)this.GetChildAt(6);
		}
	}
}