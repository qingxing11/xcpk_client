/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_playerSinpleInfo : GComponent
	{
		public GTextField m_name;
		public GTextField m_shunXu;
		public GTextField m_coinNum;

		public const string URL = "ui://efj6gsloenaq34";

		public static UI_playerSinpleInfo CreateInstance()
		{
			return (UI_playerSinpleInfo)UIPackage.CreateObject("TenThousandField","playerSinpleInfo");
		}

		public UI_playerSinpleInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_name = (GTextField)this.GetChildAt(0);
			m_shunXu = (GTextField)this.GetChildAt(1);
			m_coinNum = (GTextField)this.GetChildAt(2);
		}
	}
}