/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UpBankerList
{
	public partial class UI_BankItem : GComponent
	{
		public GTextField m_text_num;
		public GTextField m_text_nickname;
		public GTextField m_text_conis;

		public const string URL = "ui://septv56poymbe";

		public static UI_BankItem CreateInstance()
		{
			return (UI_BankItem)UIPackage.CreateObject("UpBankerList","BankItem");
		}

		public UI_BankItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_text_num = (GTextField)this.GetChildAt(0);
			m_text_nickname = (GTextField)this.GetChildAt(1);
			m_text_conis = (GTextField)this.GetChildAt(2);
		}
	}
}