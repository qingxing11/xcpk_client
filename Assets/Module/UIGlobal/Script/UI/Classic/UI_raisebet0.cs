/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_raisebet0 : GComponent
	{
		public Controller m_c1;
		public GImage m_n0;
		public GLoader m_n100;
		public GLoader m_n300;
		public GLoader m_n500;
		public GLoader m_n800;
		public GLoader m_n1000;
		public GLoader m_n1500;
		public GLoader m_n2500;
		public GLoader m_n3000;
		public GLoader m_n4000;
		public GLoader m_n5000;
		public GLoader m_n8000;
		public GLoader m_n10000;
		public GLoader m_n30000;
		public GLoader m_n80000;
		public GLoader m_n100000;
		public GLoader m_n150000;
		public GLoader m_n250000;

		public const string URL = "ui://x31qyfggkawu2l";

		public static UI_raisebet0 CreateInstance()
		{
			return (UI_raisebet0)UIPackage.CreateObject("Classic","raisebet0");
		}

		public UI_raisebet0()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n100 = (GLoader)this.GetChildAt(1);
			m_n300 = (GLoader)this.GetChildAt(2);
			m_n500 = (GLoader)this.GetChildAt(3);
			m_n800 = (GLoader)this.GetChildAt(4);
			m_n1000 = (GLoader)this.GetChildAt(5);
			m_n1500 = (GLoader)this.GetChildAt(6);
			m_n2500 = (GLoader)this.GetChildAt(7);
			m_n3000 = (GLoader)this.GetChildAt(8);
			m_n4000 = (GLoader)this.GetChildAt(9);
			m_n5000 = (GLoader)this.GetChildAt(10);
			m_n8000 = (GLoader)this.GetChildAt(11);
			m_n10000 = (GLoader)this.GetChildAt(12);
			m_n30000 = (GLoader)this.GetChildAt(13);
			m_n80000 = (GLoader)this.GetChildAt(14);
			m_n100000 = (GLoader)this.GetChildAt(15);
			m_n150000 = (GLoader)this.GetChildAt(16);
			m_n250000 = (GLoader)this.GetChildAt(17);
		}
	}
}