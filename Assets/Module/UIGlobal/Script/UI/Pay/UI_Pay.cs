/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Pay
{
	public partial class UI_Pay : GComponent
	{
		public GGraph m_n1;
		public GImage m_n2;
		public UI_btn_close m_btn_close;
		public GImage m_n4;
		public GImage m_n5;
		public UI_weixin m_weiXin;
		public UI_zhiFuBao m_zhiFuBao;
		public GTextField m_n8;
		public GTextField m_shopNum;
		public GTextField m_price;
		public GTextField m_n11;

		public const string URL = "ui://u7z8g3uli2c4a";

		public static UI_Pay CreateInstance()
		{
			return (UI_Pay)UIPackage.CreateObject("Pay","Pay");
		}

		public UI_Pay()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n1 = (GGraph)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
			m_btn_close = (UI_btn_close)this.GetChildAt(2);
			m_n4 = (GImage)this.GetChildAt(3);
			m_n5 = (GImage)this.GetChildAt(4);
			m_weiXin = (UI_weixin)this.GetChildAt(5);
			m_zhiFuBao = (UI_zhiFuBao)this.GetChildAt(6);
			m_n8 = (GTextField)this.GetChildAt(7);
			m_shopNum = (GTextField)this.GetChildAt(8);
			m_price = (GTextField)this.GetChildAt(9);
			m_n11 = (GTextField)this.GetChildAt(10);
		}
	}
}