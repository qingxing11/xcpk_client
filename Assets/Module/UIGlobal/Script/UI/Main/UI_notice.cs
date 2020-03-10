/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_notice : GComponent
	{
		public GGraph m_n3;
		public GTextField m_n2;
		public GLoader m_n4;
		public GGroup m_n5;
		public GTextField m_n6;
		public GLoader m_n7;
		public GGroup m_n8;
		public Transition m_t1;
		public Transition m_t2;

		public const string URL = "ui://du637vw1tejyy16";

		public static UI_notice CreateInstance()
		{
			return (UI_notice)UIPackage.CreateObject("Main","notice");
		}

		public UI_notice()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n3 = (GGraph)this.GetChildAt(0);
			m_n2 = (GTextField)this.GetChildAt(1);
			m_n4 = (GLoader)this.GetChildAt(2);
			m_n5 = (GGroup)this.GetChildAt(3);
			m_n6 = (GTextField)this.GetChildAt(4);
			m_n7 = (GLoader)this.GetChildAt(5);
			m_n8 = (GGroup)this.GetChildAt(6);
			m_t1 = this.GetTransitionAt(0);
			m_t2 = this.GetTransitionAt(1);
		}
	}
}