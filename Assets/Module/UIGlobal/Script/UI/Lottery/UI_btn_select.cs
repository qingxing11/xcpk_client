/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lottery
{
	public partial class UI_btn_select : GButton
	{
		public Controller m_c1;
		public Controller m_button;
		public Controller m_c2;
		public GImage m_n0;
		public GImage m_n10;
		public GImage m_n1;
		public GImage m_n3;
		public GImage m_n4;
		public GImage m_n5;
		public GImage m_n6;
		public GImage m_n7;
		public GImage m_n8;
		public GGroup m_n9;
		public GMovieClip m_movie;
		public GImage m_n12;
		public GTextField m_txt_number;
		public GGroup m_num;

		public const string URL = "ui://czzshd91lt201o";

		public static UI_btn_select CreateInstance()
		{
			return (UI_btn_select)UIPackage.CreateObject("Lottery","btn_select");
		}

		public UI_btn_select()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_button = this.GetControllerAt(1);
			m_c2 = this.GetControllerAt(2);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n10 = (GImage)this.GetChildAt(1);
			m_n1 = (GImage)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
			m_n4 = (GImage)this.GetChildAt(4);
			m_n5 = (GImage)this.GetChildAt(5);
			m_n6 = (GImage)this.GetChildAt(6);
			m_n7 = (GImage)this.GetChildAt(7);
			m_n8 = (GImage)this.GetChildAt(8);
			m_n9 = (GGroup)this.GetChildAt(9);
			m_movie = (GMovieClip)this.GetChildAt(10);
			m_n12 = (GImage)this.GetChildAt(11);
			m_txt_number = (GTextField)this.GetChildAt(12);
			m_num = (GGroup)this.GetChildAt(13);
		}
	}
}