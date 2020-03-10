/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lottery
{
	public partial class UI_coin : GComponent
	{
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;
		public GImage m_n4;
		public GImage m_n5;
		public GImage m_n6;
		public GImage m_n7;
		public GImage m_n8;
		public GGroup m_coin;
		public Transition m_t1;

		public const string URL = "ui://czzshd91b0z25a";

		public static UI_coin CreateInstance()
		{
			return (UI_coin)UIPackage.CreateObject("Lottery","coin");
		}

		public UI_coin()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
			m_n4 = (GImage)this.GetChildAt(4);
			m_n5 = (GImage)this.GetChildAt(5);
			m_n6 = (GImage)this.GetChildAt(6);
			m_n7 = (GImage)this.GetChildAt(7);
			m_n8 = (GImage)this.GetChildAt(8);
			m_coin = (GGroup)this.GetChildAt(9);
			m_t1 = this.GetTransitionAt(0);
		}
	}
}