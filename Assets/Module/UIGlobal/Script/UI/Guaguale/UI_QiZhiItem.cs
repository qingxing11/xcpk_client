/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_QiZhiItem : GComponent
	{
		public Controller m_c1;
		public GLoader m_icon;
		public GTextField m_txt_money;
		public GImage m_n2;

		public const string URL = "ui://rjmn7jeuzq2w66";

		public static UI_QiZhiItem CreateInstance()
		{
			return (UI_QiZhiItem)UIPackage.CreateObject("Guaguale","QiZhiItem");
		}

		public UI_QiZhiItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_icon = (GLoader)this.GetChildAt(0);
			m_txt_money = (GTextField)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
		}
	}
}