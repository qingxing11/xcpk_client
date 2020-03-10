/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_ComparerPoker : GComponent
	{
		public GImage m_n0;
		public GImage m_n1;
		public UI_cards1 m_cards0;
		public UI_cards1 m_cards1;
		public GLoader m_head0;
		public GLoader m_head1;
		public GTextField m_text_nickName0;
		public GTextField m_text_nickName1;
		public GMovieClip m_anim;
		public GImage m_n12;
		public Transition m_t0;

		public const string URL = "ui://efj6gslojb9s6s";

		public static UI_ComparerPoker CreateInstance()
		{
			return (UI_ComparerPoker)UIPackage.CreateObject("TenThousandField","ComparerPoker");
		}

		public UI_ComparerPoker()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_cards0 = (UI_cards1)this.GetChildAt(2);
			m_cards1 = (UI_cards1)this.GetChildAt(3);
			m_head0 = (GLoader)this.GetChildAt(4);
			m_head1 = (GLoader)this.GetChildAt(5);
			m_text_nickName0 = (GTextField)this.GetChildAt(6);
			m_text_nickName1 = (GTextField)this.GetChildAt(7);
			m_anim = (GMovieClip)this.GetChildAt(8);
			m_n12 = (GImage)this.GetChildAt(9);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}