/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_win : GComponent
	{
		public Controller m_win;
		public GLoader m_click;
		public GImage m_n0;
		public UI_winOrLoss m_pos1;
		public UI_winOrLoss m_pos2;
		public UI_winOrLoss m_pos3;
		public UI_winOrLoss m_pos4;
		public UI_winOrLoss m_pos5;
		public GImage m_n26;
		public GImage m_n27;
		public UI_btnReady m_btnReady;

		public const string URL = "ui://efj6gsloglfq6m";

		public static UI_win CreateInstance()
		{
			return (UI_win)UIPackage.CreateObject("TenThousandField","win");
		}

		public UI_win()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_win = this.GetControllerAt(0);
			m_click = (GLoader)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
			m_pos1 = (UI_winOrLoss)this.GetChildAt(2);
			m_pos2 = (UI_winOrLoss)this.GetChildAt(3);
			m_pos3 = (UI_winOrLoss)this.GetChildAt(4);
			m_pos4 = (UI_winOrLoss)this.GetChildAt(5);
			m_pos5 = (UI_winOrLoss)this.GetChildAt(6);
			m_n26 = (GImage)this.GetChildAt(7);
			m_n27 = (GImage)this.GetChildAt(8);
			m_btnReady = (UI_btnReady)this.GetChildAt(9);
		}
	}
}