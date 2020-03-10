/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TxtTitle
{
	public partial class UI_TxtCom : GComponent
	{
		public GGraph m_n0;
		public GTextField m_txt;

		public const string URL = "ui://xv1ecxjayo1k0";

		public static UI_TxtCom CreateInstance()
		{
			return (UI_TxtCom)UIPackage.CreateObject("TxtTitle","TxtCom");
		}

		public UI_TxtCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GGraph)this.GetChildAt(0);
			m_txt = (GTextField)this.GetChildAt(1);
		}
	}
}