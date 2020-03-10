/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_freeChouJiang : GComponent
	{
		public Controller m_btn;
		public GImage m_n38;
		public UI_btn_startChouJiang m_btn_free;
		public UI_btn_costChouJiang m_btn_cost;
		public GImage m_move;
		public GImage m_movePlay;
		public GImage m_ka1;
		public GImage m_ka2;
		public GImage m_ka3;
		public GImage m_ka4;
		public GImage m_ka5;
		public GImage m_ka6;
		public GImage m_ka7;
		public GImage m_ka8;
		public GImage m_ka9;
		public GImage m_ka10;
		public GImage m_ka11;
		public GImage m_ka12;
		public GImage m_ka13;
		public GImage m_ka14;
		public GImage m_ka15;
		public GImage m_ka16;
		public Transition m_play;

		public const string URL = "ui://jbql1kzat1m32i";

		public static UI_freeChouJiang CreateInstance()
		{
			return (UI_freeChouJiang)UIPackage.CreateObject("GameTask","freeChouJiang");
		}

		public UI_freeChouJiang()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_btn = this.GetControllerAt(0);
			m_n38 = (GImage)this.GetChildAt(0);
			m_btn_free = (UI_btn_startChouJiang)this.GetChildAt(1);
			m_btn_cost = (UI_btn_costChouJiang)this.GetChildAt(2);
			m_move = (GImage)this.GetChildAt(3);
			m_movePlay = (GImage)this.GetChildAt(4);
			m_ka1 = (GImage)this.GetChildAt(5);
			m_ka2 = (GImage)this.GetChildAt(6);
			m_ka3 = (GImage)this.GetChildAt(7);
			m_ka4 = (GImage)this.GetChildAt(8);
			m_ka5 = (GImage)this.GetChildAt(9);
			m_ka6 = (GImage)this.GetChildAt(10);
			m_ka7 = (GImage)this.GetChildAt(11);
			m_ka8 = (GImage)this.GetChildAt(12);
			m_ka9 = (GImage)this.GetChildAt(13);
			m_ka10 = (GImage)this.GetChildAt(14);
			m_ka11 = (GImage)this.GetChildAt(15);
			m_ka12 = (GImage)this.GetChildAt(16);
			m_ka13 = (GImage)this.GetChildAt(17);
			m_ka14 = (GImage)this.GetChildAt(18);
			m_ka15 = (GImage)this.GetChildAt(19);
			m_ka16 = (GImage)this.GetChildAt(20);
			m_play = this.GetTransitionAt(0);
		}
	}
}