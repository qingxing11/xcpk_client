/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace Lottery
{
	public partial class UI_LotteryWin : GComponent
	{
		public GImage m_n5;
		public GGroup m_win;
		public GTextField m_txt_coinNUm;
		public Transition m_t0;

		public const string URL = "ui://czzshd91fxu62h";

		public static UI_LotteryWin CreateInstance()
		{
			return (UI_LotteryWin)UIPackage.CreateObject("Lottery","LotteryWin");
		}

		public UI_LotteryWin()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);
            Debug.Log("UI_LotteryWin:ConstructFromXML");
			m_n5 = (GImage)this.GetChildAt(0);
			m_win = (GGroup)this.GetChildAt(1);
			m_txt_coinNUm = (GTextField)this.GetChildAt(2);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}