/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_winOrLoss : GComponent
	{
		public Controller m_havePlayer;
		public UI_item m_have;
		public UI_noPlayer m_no;

		public const string URL = "ui://efj6gsloglfq6r";

		public static UI_winOrLoss CreateInstance()
		{
			return (UI_winOrLoss)UIPackage.CreateObject("TenThousandField","winOrLoss");
		}

		public UI_winOrLoss()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_havePlayer = this.GetControllerAt(0);
			m_have = (UI_item)this.GetChildAt(0);
			m_no = (UI_noPlayer)this.GetChildAt(1);
		}
	}
}