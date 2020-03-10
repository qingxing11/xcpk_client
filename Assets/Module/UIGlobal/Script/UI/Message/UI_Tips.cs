/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Message
{
	public partial class UI_Tips : GComponent
	{
		public GTextField m_text_content;

		public const string URL = "ui://2pj4ie0ueupob";

		public static UI_Tips CreateInstance()
		{
			return (UI_Tips)UIPackage.CreateObject("Message","Tips");
		}

		public UI_Tips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_text_content = (GTextField)this.GetChildAt(0);
		}
	}
}