/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_MyTxtItem : GComponent
	{
		public Controller m_c1;
		public GTextField m_txt_myTitlle;
		public GTextField m_txt_myTitlle2;
		public GTextField m_txt_myTitlle3;

		public const string URL = "ui://rjmn7jeuzq2w6l";

		public static UI_MyTxtItem CreateInstance()
		{
			return (UI_MyTxtItem)UIPackage.CreateObject("Guaguale","MyTxtItem");
		}

		public UI_MyTxtItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_txt_myTitlle = (GTextField)this.GetChildAt(0);
			m_txt_myTitlle2 = (GTextField)this.GetChildAt(1);
			m_txt_myTitlle3 = (GTextField)this.GetChildAt(2);
		}
	}
}