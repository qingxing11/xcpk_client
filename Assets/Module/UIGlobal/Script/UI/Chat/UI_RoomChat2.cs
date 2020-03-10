/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_RoomChat2 : GComponent
	{
		public GImage m_n3;
		public GRichTextField m_txt3;
		public GGroup m_t3;
		public GImage m_n2;
		public GRichTextField m_txt2;
		public GGroup m_t2;
		public GImage m_n7;
		public GRichTextField m_txt7;
		public GGroup m_t7;
		public GImage m_n1;
		public GRichTextField m_txt1;
		public GGroup m_t1;
		public GImage m_n0;
		public GRichTextField m_txt0;
		public GGroup m_t0;
		public GImage m_n6;
		public GRichTextField m_txt6;
		public GGroup m_t6;
		public GImage m_n5;
		public GRichTextField m_txt5;
		public GGroup m_t5;
		public GImage m_n4;
		public GRichTextField m_txt4;
		public GGroup m_t4;
		public GLoader m_en0;
		public GLoader m_en1;
		public GLoader m_en2;
		public GLoader m_en3;
		public GLoader m_en7;
		public GLoader m_en6;
		public GLoader m_en5;
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
		public Transition m_tn7;
		public Transition m_tn6;
		public Transition m_tn5;
		public Transition m_tn4;

		public const string URL = "ui://kxabpsetr0ik5xy0";

		public static UI_RoomChat2 CreateInstance()
		{
			return (UI_RoomChat2)UIPackage.CreateObject("Chat","RoomChat2");
		}

		public UI_RoomChat2()
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
			m_n7 = (GImage)this.GetChildAt(6);
			m_txt7 = (GRichTextField)this.GetChildAt(7);
			m_t7 = (GGroup)this.GetChildAt(8);
			m_n1 = (GImage)this.GetChildAt(9);
			m_txt1 = (GRichTextField)this.GetChildAt(10);
			m_t1 = (GGroup)this.GetChildAt(11);
			m_n0 = (GImage)this.GetChildAt(12);
			m_txt0 = (GRichTextField)this.GetChildAt(13);
			m_t0 = (GGroup)this.GetChildAt(14);
			m_n6 = (GImage)this.GetChildAt(15);
			m_txt6 = (GRichTextField)this.GetChildAt(16);
			m_t6 = (GGroup)this.GetChildAt(17);
			m_n5 = (GImage)this.GetChildAt(18);
			m_txt5 = (GRichTextField)this.GetChildAt(19);
			m_t5 = (GGroup)this.GetChildAt(20);
			m_n4 = (GImage)this.GetChildAt(21);
			m_txt4 = (GRichTextField)this.GetChildAt(22);
			m_t4 = (GGroup)this.GetChildAt(23);
			m_en0 = (GLoader)this.GetChildAt(24);
			m_en1 = (GLoader)this.GetChildAt(25);
			m_en2 = (GLoader)this.GetChildAt(26);
			m_en3 = (GLoader)this.GetChildAt(27);
			m_en7 = (GLoader)this.GetChildAt(28);
			m_en6 = (GLoader)this.GetChildAt(29);
			m_en5 = (GLoader)this.GetChildAt(30);
			m_en4 = (GLoader)this.GetChildAt(31);
			m_t00 = this.GetTransitionAt(0);
			m_t01 = this.GetTransitionAt(1);
			m_t02 = this.GetTransitionAt(2);
			m_t03 = this.GetTransitionAt(3);
			m_t04 = this.GetTransitionAt(4);
			m_tn0 = this.GetTransitionAt(5);
			m_tn1 = this.GetTransitionAt(6);
			m_tn2 = this.GetTransitionAt(7);
			m_tn3 = this.GetTransitionAt(8);
			m_tn7 = this.GetTransitionAt(9);
			m_tn6 = this.GetTransitionAt(10);
			m_tn5 = this.GetTransitionAt(11);
			m_tn4 = this.GetTransitionAt(12);
		}
	}
}