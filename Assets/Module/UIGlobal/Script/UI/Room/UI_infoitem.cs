/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_infoitem : GComponent
	{
		public Controller m_c1;
		public UI_head m_head;
		public GImage m_n14;
		public GTextField m_n11;
		public GImage m_n12;
		public GTextField m_gold;
		public GLoader m_vip;
		public GList m_icon_list;

		public const string URL = "ui://es6hjd4tcg7fvf";

		public static UI_infoitem CreateInstance()
		{
			return (UI_infoitem)UIPackage.CreateObject("Room","infoitem");
		}

		public UI_infoitem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_head = (UI_head)this.GetChildAt(0);
			m_n14 = (GImage)this.GetChildAt(1);
			m_n11 = (GTextField)this.GetChildAt(2);
			m_n12 = (GImage)this.GetChildAt(3);
			m_gold = (GTextField)this.GetChildAt(4);
			m_vip = (GLoader)this.GetChildAt(5);
			m_icon_list = (GList)this.GetChildAt(6);
		}
	}
}