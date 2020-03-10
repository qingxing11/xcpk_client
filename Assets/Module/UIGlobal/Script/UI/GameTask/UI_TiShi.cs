/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_TiShi : GComponent
	{
		public UI_tiShi1 m_tiShi;
		public GLoader m_click;
		public Transition m_tiShiPlay;

		public const string URL = "ui://jbql1kzap1gk2n";

		public static UI_TiShi CreateInstance()
		{
			return (UI_TiShi)UIPackage.CreateObject("GameTask","TiShi");
		}

		public UI_TiShi()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_tiShi = (UI_tiShi1)this.GetChildAt(0);
			m_click = (GLoader)this.GetChildAt(1);
			m_tiShiPlay = this.GetTransitionAt(0);
		}
	}
}