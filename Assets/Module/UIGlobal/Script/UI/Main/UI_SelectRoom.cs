/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_SelectRoom : GComponent
	{
		public GImage m_n27;
		public GImage m_n9;
		public UI_btn_tongsha m_btn_allkill2;
		public UI_btn_wanren m_btn_manyPeople;
		public UI_btn_return m_btn_return;
		public UI_btn_yule m_btn_yule;
		public UI_btn_jingdian m_btn_classic;
		public UI_btn_qidai m_n5;
		public UI_btn_shuiguoji m_btn_fruit2;
		public UI_btn_quickStart m_n7;
		public GGroup m_n8;

		public const string URL = "ui://du637vw1ulxey0h";

		public static UI_SelectRoom CreateInstance()
		{
			return (UI_SelectRoom)UIPackage.CreateObject("Main","SelectRoom");
		}

		public UI_SelectRoom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n27 = (GImage)this.GetChildAt(0);
			m_n9 = (GImage)this.GetChildAt(1);
			m_btn_allkill2 = (UI_btn_tongsha)this.GetChildAt(2);
			m_btn_manyPeople = (UI_btn_wanren)this.GetChildAt(3);
			m_btn_return = (UI_btn_return)this.GetChildAt(4);
			m_btn_yule = (UI_btn_yule)this.GetChildAt(5);
			m_btn_classic = (UI_btn_jingdian)this.GetChildAt(6);
			m_n5 = (UI_btn_qidai)this.GetChildAt(7);
			m_btn_fruit2 = (UI_btn_shuiguoji)this.GetChildAt(8);
			m_n7 = (UI_btn_quickStart)this.GetChildAt(9);
			m_n8 = (GGroup)this.GetChildAt(10);
		}
	}
}