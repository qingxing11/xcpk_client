/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace Lottery
{
	public partial class UI_LotteryLose : GComponent
	{
        public GImage m_n6;
        public GGroup m_lose;
        public Transition m_t0;

        public const string URL = "ui://czzshd91wlwd6p";

		public static UI_LotteryLose CreateInstance()
		{
			return (UI_LotteryLose)UIPackage.CreateObject("Lottery", "LotteryLose");
		}

		public UI_LotteryLose()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);
            Debug.Log("UI_LotteryLose:ConstructFromXML");
            m_n6 = (GImage)this.GetChildAt(0);
            m_lose = (GGroup)this.GetChildAt(1);
            m_t0 = this.GetTransitionAt(0);
        }
	}
}