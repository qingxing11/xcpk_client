/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace WiningShow
{
	public partial class UI_WinShow : GComponent
	{
		public GLoader m_click;
		public GImage m_n4;
		public GImage m_n7;
		public GImage m_n8;
		public GMovieClip m_n0;
		public GMovieClip m_n1;
		public GMovieClip m_n2;
		public GMovieClip m_n3;
		public GImage m_n9;
		public GImage m_n10;
		public GImage m_n11;
		public GImage m_n12;
		public GImage m_n13;
		public GImage m_n14;
		public GImage m_n15;
		public GImage m_n16;
		public GImage m_n17;
		public GMovieClip m_n19;
		public GMovieClip m_n20;
		public GMovieClip m_n21;
		public GMovieClip m_n22;
		public GImage m_n23;
		public GTextField m_text;
		public Transition m_playWin;
		public Transition m_t1;

		public const string URL = "ui://auw4g2n9sy8pg";

		public static UI_WinShow CreateInstance()
		{
			return (UI_WinShow)UIPackage.CreateObject("WiningShow","WinShow");
		}

		public UI_WinShow()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_click = (GLoader)this.GetChildAt(0);
			m_n4 = (GImage)this.GetChildAt(1);
			m_n7 = (GImage)this.GetChildAt(2);
			m_n8 = (GImage)this.GetChildAt(3);
			m_n0 = (GMovieClip)this.GetChildAt(4);
			m_n1 = (GMovieClip)this.GetChildAt(5);
			m_n2 = (GMovieClip)this.GetChildAt(6);
			m_n3 = (GMovieClip)this.GetChildAt(7);
			m_n9 = (GImage)this.GetChildAt(8);
			m_n10 = (GImage)this.GetChildAt(9);
			m_n11 = (GImage)this.GetChildAt(10);
			m_n12 = (GImage)this.GetChildAt(11);
			m_n13 = (GImage)this.GetChildAt(12);
			m_n14 = (GImage)this.GetChildAt(13);
			m_n15 = (GImage)this.GetChildAt(14);
			m_n16 = (GImage)this.GetChildAt(15);
			m_n17 = (GImage)this.GetChildAt(16);
			m_n19 = (GMovieClip)this.GetChildAt(17);
			m_n20 = (GMovieClip)this.GetChildAt(18);
			m_n21 = (GMovieClip)this.GetChildAt(19);
			m_n22 = (GMovieClip)this.GetChildAt(20);
			m_n23 = (GImage)this.GetChildAt(21);
			m_text = (GTextField)this.GetChildAt(22);
			m_playWin = this.GetTransitionAt(0);
			m_t1 = this.GetTransitionAt(1);
		}
	}
}