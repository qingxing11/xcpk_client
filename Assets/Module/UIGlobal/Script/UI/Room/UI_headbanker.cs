/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_headbanker : GComponent
	{
		public GLoader m_n0;
		public GGraph m_n1;

		public const string URL = "ui://es6hjd4t9nncxwj";

		public static UI_headbanker CreateInstance()
		{
			return (UI_headbanker)UIPackage.CreateObject("Room","headbanker");
		}

		public UI_headbanker()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GLoader)this.GetChildAt(0);
			m_n1 = (GGraph)this.GetChildAt(1);
		}
	}
}