/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_raisebetManyPeople : GComponent
	{
		public GImage m_n0;
		public GLoader m_n50000;
		public GLoader m_n80000;
		public GLoader m_n100000;
		public GLoader m_n150000;
		public GLoader m_n250000;

		public const string URL = "ui://x31qyfggpxdrbz";

		public static UI_raisebetManyPeople CreateInstance()
		{
			return (UI_raisebetManyPeople)UIPackage.CreateObject("Classic","raisebetManyPeople");
		}

		public UI_raisebetManyPeople()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n50000 = (GLoader)this.GetChildAt(1);
			m_n80000 = (GLoader)this.GetChildAt(2);
			m_n100000 = (GLoader)this.GetChildAt(3);
			m_n150000 = (GLoader)this.GetChildAt(4);
			m_n250000 = (GLoader)this.GetChildAt(5);
		}
	}
}