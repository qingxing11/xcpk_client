/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_OnLineReward : GComponent
	{
		public GList m_n33;
		public GImage m_n34;
		public GImage m_n35;

		public const string URL = "ui://jbql1kzagjdg12";

		public static UI_OnLineReward CreateInstance()
		{
			return (UI_OnLineReward)UIPackage.CreateObject("GameTask","OnLineReward");
		}

		public UI_OnLineReward()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n33 = (GList)this.GetChildAt(0);
			m_n34 = (GImage)this.GetChildAt(1);
			m_n35 = (GImage)this.GetChildAt(2);
		}
	}
}