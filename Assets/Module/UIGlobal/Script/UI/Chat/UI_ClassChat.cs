/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_ClassChat : GComponent
	{
		public GImage m_n3;
		public GRichTextField m_txt3;
		public GGroup m_t3;
		public GImage m_n2;
		public GRichTextField m_txt2;
		public GGroup m_t2;
		public GImage m_n4;
		public GRichTextField m_txt4;
		public GGroup m_t4;
		public GImage m_n1;
		public GRichTextField m_txt1;
		public GGroup m_t1;
		public GImage m_n0;
		public GRichTextField m_txt0;
		public GGroup m_t0;
		public GLoader m_en0;
		public GLoader m_en1;
		public GLoader m_en2;
		public GLoader m_en3;
		public GLoader m_en4;
		public Transition m_t00;
		public Transition m_t01;
		public Transition m_t02;
		public Transition m_t03;
		public Transition m_t04;
		public Transition m_tn0;
		public Transition m_tn1;
		public Transition m_tn2;
		public Transition m_tn3;
		public Transition m_tn4;

		public const string URL = "ui://kxabpsetd2dh5xxg";

		public static UI_ClassChat CreateInstance()
		{
			return (UI_ClassChat)UIPackage.CreateObject("Chat","ClassChat");
		}

		public UI_ClassChat()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n3 = (GImage)this.GetChildAt(0);
			m_txt3 = (GRichTextField)this.GetChildAt(1);
			m_t3 = (GGroup)this.GetChildAt(2);
			m_n2 = (GImage)this.GetChildAt(3);
			m_txt2 = (GRichTextField)this.GetChildAt(4);
			m_t2 = (GGroup)this.GetChildAt(5);
			m_n4 = (GImage)this.GetChildAt(6);
			m_txt4 = (GRichTextField)this.GetChildAt(7);
			m_t4 = (GGroup)this.GetChildAt(8);
			m_n1 = (GImage)this.GetChildAt(9);
			m_txt1 = (GRichTextField)this.GetChildAt(10);
			m_t1 = (GGroup)this.GetChildAt(11);
			m_n0 = (GImage)this.GetChildAt(12);
			m_txt0 = (GRichTextField)this.GetChildAt(13);
			m_t0 = (GGroup)this.GetChildAt(14);
			m_en0 = (GLoader)this.GetChildAt(15);
			m_en1 = (GLoader)this.GetChildAt(16);
			m_en2 = (GLoader)this.GetChildAt(17);
			m_en3 = (GLoader)this.GetChildAt(18);
			m_en4 = (GLoader)this.GetChildAt(19);
			m_t00 = this.GetTransitionAt(0);
			m_t01 = this.GetTransitionAt(1);
			m_t02 = this.GetTransitionAt(2);
			m_t03 = this.GetTransitionAt(3);
			m_t04 = this.GetTransitionAt(4);
			m_tn0 = this.GetTransitionAt(5);
			m_tn1 = this.GetTransitionAt(6);
			m_tn2 = this.GetTransitionAt(7);
			m_tn3 = this.GetTransitionAt(8);
			m_tn4 = this.GetTransitionAt(9);
		}
	}
}