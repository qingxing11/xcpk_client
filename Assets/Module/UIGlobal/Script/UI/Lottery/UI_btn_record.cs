/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lottery
{
	public partial class UI_btn_record : GComponent
	{
		public Controller m_c1;
		public GImage m_n7;
		public GLoader m_n8;
		public GLoader m_n9;
		public GLoader m_n10;
		public GLoader m_n11;
		public GLoader m_n12;
		public GLoader m_n13;

		public const string URL = "ui://czzshd91lt201p";

		public static UI_btn_record CreateInstance()
		{
			return (UI_btn_record)UIPackage.CreateObject("Lottery","btn_record");
		}

		public UI_btn_record()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n7 = (GImage)this.GetChildAt(0);
			m_n8 = (GLoader)this.GetChildAt(1);
			m_n9 = (GLoader)this.GetChildAt(2);
			m_n10 = (GLoader)this.GetChildAt(3);
			m_n11 = (GLoader)this.GetChildAt(4);
			m_n12 = (GLoader)this.GetChildAt(5);
			m_n13 = (GLoader)this.GetChildAt(6);
		}
	}
}