/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Safebox
{
	public partial class UI_OperatingRecordCom : GComponent
	{
		public GGraph m_n11;
		public GImage m_n2;
		public GImage m_n4;
		public GImage m_n3;
		public GImage m_n5;
		public GImage m_n6;
		public GImage m_n7;
		public GImage m_n8;
		public GList m_list_opera;

		public const string URL = "ui://ey7bc1rcrwpf1z";

		public static UI_OperatingRecordCom CreateInstance()
		{
			return (UI_OperatingRecordCom)UIPackage.CreateObject("Safebox","OperatingRecordCom");
		}

		public UI_OperatingRecordCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n11 = (GGraph)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
			m_n4 = (GImage)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
			m_n5 = (GImage)this.GetChildAt(4);
			m_n6 = (GImage)this.GetChildAt(5);
			m_n7 = (GImage)this.GetChildAt(6);
			m_n8 = (GImage)this.GetChildAt(7);
			m_list_opera = (GList)this.GetChildAt(8);
		}
	}
}