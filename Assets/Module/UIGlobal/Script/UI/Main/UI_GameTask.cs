/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_GameTask : GComponent
	{
		public GGraph m_n1;
		public UI_btn_gt_g m_n3;
		public UI_btn_gt_g m_n4;
		public UI_btn_gt_g m_n5;
		public GList m_n6;
		public UI_btn_gt_g m_n7;
		public UI_btn_gt_g m_n8;
		public UI_btn_gt_g m_n9;
		public UI_btn_close_g2 m_n11;

		public const string URL = "ui://du637vw1hxskt80";

		public static UI_GameTask CreateInstance()
		{
			return (UI_GameTask)UIPackage.CreateObject("Main","GameTask");
		}

		public UI_GameTask()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n1 = (GGraph)this.GetChildAt(0);
			m_n3 = (UI_btn_gt_g)this.GetChildAt(1);
			m_n4 = (UI_btn_gt_g)this.GetChildAt(2);
			m_n5 = (UI_btn_gt_g)this.GetChildAt(3);
			m_n6 = (GList)this.GetChildAt(4);
			m_n7 = (UI_btn_gt_g)this.GetChildAt(5);
			m_n8 = (UI_btn_gt_g)this.GetChildAt(6);
			m_n9 = (UI_btn_gt_g)this.GetChildAt(7);
			m_n11 = (UI_btn_close_g2)this.GetChildAt(8);
		}
	}
}