/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_Gif : GComponent
	{
		public Controller m_c1;
		public GImage m_n0;
		public GImage m_n18;
		public GGraph m_pos0;
		public GGraph m_pos1;
		public GGraph m_pos2;
		public GGraph m_pos3;
		public GGraph m_pos4;
		public GGraph m_pos5;
		public GGraph m_pos6;
		public GGraph m_pos7;
		public GGraph m_pos8;
		public GGraph m_pos9;
		public GGraph m_pos10;
		public GMovieClip m_flowerGif;
		public GMovieClip m_cheersGif;
		public GMovieClip m_bombGif;
		public GMovieClip m_eggGif;
		public GMovieClip m_kissGif;
		public GMovieClip m_shoeGif;

		public const string URL = "ui://es6hjd4tsczixzw";

		public static UI_Gif CreateInstance()
		{
			return (UI_Gif)UIPackage.CreateObject("Room","Gif");
		}

		public UI_Gif()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n18 = (GImage)this.GetChildAt(1);
			m_pos0 = (GGraph)this.GetChildAt(2);
			m_pos1 = (GGraph)this.GetChildAt(3);
			m_pos2 = (GGraph)this.GetChildAt(4);
			m_pos3 = (GGraph)this.GetChildAt(5);
			m_pos4 = (GGraph)this.GetChildAt(6);
			m_pos5 = (GGraph)this.GetChildAt(7);
			m_pos6 = (GGraph)this.GetChildAt(8);
			m_pos7 = (GGraph)this.GetChildAt(9);
			m_pos8 = (GGraph)this.GetChildAt(10);
			m_pos9 = (GGraph)this.GetChildAt(11);
			m_pos10 = (GGraph)this.GetChildAt(12);
			m_flowerGif = (GMovieClip)this.GetChildAt(13);
			m_cheersGif = (GMovieClip)this.GetChildAt(14);
			m_bombGif = (GMovieClip)this.GetChildAt(15);
			m_eggGif = (GMovieClip)this.GetChildAt(16);
			m_kissGif = (GMovieClip)this.GetChildAt(17);
			m_shoeGif = (GMovieClip)this.GetChildAt(18);
		}
	}
}