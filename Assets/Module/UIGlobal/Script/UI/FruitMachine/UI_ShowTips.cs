/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_ShowTips : GComponent
	{
		public Controller m_index;
		public GImage m_n4;
		public GTextField m_n3;
		public GGroup m_n6;
		public GImage m_n7;
		public GTextField m_n8;
		public GGroup m_n9;
		public Transition m_play1;
		public Transition m_play2;

		public const string URL = "ui://l17p56hbpv1it9m";

		public static UI_ShowTips CreateInstance()
		{
			return (UI_ShowTips)UIPackage.CreateObject("FruitMachine","ShowTips");
		}

		public UI_ShowTips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_index = this.GetControllerAt(0);
			m_n4 = (GImage)this.GetChildAt(0);
			m_n3 = (GTextField)this.GetChildAt(1);
			m_n6 = (GGroup)this.GetChildAt(2);
			m_n7 = (GImage)this.GetChildAt(3);
			m_n8 = (GTextField)this.GetChildAt(4);
			m_n9 = (GGroup)this.GetChildAt(5);
			m_play1 = this.GetTransitionAt(0);
			m_play2 = this.GetTransitionAt(1);
		}
	}
}