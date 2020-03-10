/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_ComparerPoker : GComponent
	{
		public GImage m_n48;
		public GImage m_n1;
		public GLoader m_head0;
		public GLoader m_head1;
		public GTextField m_text_nickName0;
		public GTextField m_text_nickName1;
		public GMovieClip m_anim;
		public GImage m_n44;
		public GGroup m_n43;
		public GLoader m_card_back1;
		public GLoader m_card_back2;
		public GLoader m_card_back3;
		public GLoader m_card_back4;
		public GLoader m_card_back5;
		public GLoader m_card_back6;
		public GLoader m_boom;
		public Transition m_t_boom;

		public const string URL = "ui://x31qyfggl4he30";

		public static UI_ComparerPoker CreateInstance()
		{
			return (UI_ComparerPoker)UIPackage.CreateObject("Classic","ComparerPoker");
		}

		public UI_ComparerPoker()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n48 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_head0 = (GLoader)this.GetChildAt(2);
			m_head1 = (GLoader)this.GetChildAt(3);
			m_text_nickName0 = (GTextField)this.GetChildAt(4);
			m_text_nickName1 = (GTextField)this.GetChildAt(5);
			m_anim = (GMovieClip)this.GetChildAt(6);
			m_n44 = (GImage)this.GetChildAt(7);
			m_n43 = (GGroup)this.GetChildAt(8);
			m_card_back1 = (GLoader)this.GetChildAt(9);
			m_card_back2 = (GLoader)this.GetChildAt(10);
			m_card_back3 = (GLoader)this.GetChildAt(11);
			m_card_back4 = (GLoader)this.GetChildAt(12);
			m_card_back5 = (GLoader)this.GetChildAt(13);
			m_card_back6 = (GLoader)this.GetChildAt(14);
			m_boom = (GLoader)this.GetChildAt(15);
			m_t_boom = this.GetTransitionAt(0);
		}
	}
}