/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_GameTask : GComponent
	{
		public Controller m_btnClick;
		public GGraph m_n1;
		public GImage m_n13;
		public GImage m_n35;
		public UI_btn_close_g2 m_btn_close;
		public UI_btn_onLineReward m_btn_onLineReward;
		public UI_btn_chouJiang m_btn_chouJiang;
		public UI_btn_gameTask m_btn_gameTask;
		public GImage m_n19;
		public GImage m_n20;
		public GImage m_n21;
		public UI_compgameTask m_compGameTask;
		public UI_OnLineReward m_onLineReward;
		public UI_freeChouJiang m_freeChouJiang;
		public GRichTextField m_txt_pop;
		public GImage m_n42;
		public GImage m_n43;
		public Transition m_showTips;

		public const string URL = "ui://jbql1kzagjdgj";

		public static UI_GameTask CreateInstance()
		{
			return (UI_GameTask)UIPackage.CreateObject("GameTask","GameTask");
		}

		public UI_GameTask()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_btnClick = this.GetControllerAt(0);
			m_n1 = (GGraph)this.GetChildAt(0);
			m_n13 = (GImage)this.GetChildAt(1);
			m_n35 = (GImage)this.GetChildAt(2);
			m_btn_close = (UI_btn_close_g2)this.GetChildAt(3);
			m_btn_onLineReward = (UI_btn_onLineReward)this.GetChildAt(4);
			m_btn_chouJiang = (UI_btn_chouJiang)this.GetChildAt(5);
			m_btn_gameTask = (UI_btn_gameTask)this.GetChildAt(6);
			m_n19 = (GImage)this.GetChildAt(7);
			m_n20 = (GImage)this.GetChildAt(8);
			m_n21 = (GImage)this.GetChildAt(9);
			m_compGameTask = (UI_compgameTask)this.GetChildAt(10);
			m_onLineReward = (UI_OnLineReward)this.GetChildAt(11);
			m_freeChouJiang = (UI_freeChouJiang)this.GetChildAt(12);
			m_txt_pop = (GRichTextField)this.GetChildAt(13);
			m_n42 = (GImage)this.GetChildAt(14);
			m_n43 = (GImage)this.GetChildAt(15);
			m_showTips = this.GetTransitionAt(0);
		}
	}
}