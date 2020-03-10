/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Info
{
	public partial class UI_selfInfo : GComponent
	{
		public Controller m_c1;
		public Controller m_c2;
		public GImage m_n39;
		public GImage m_bg;
		public GImage m_bg1;
		public GImage m_bg2;
		public GImage m_bg3;
		public GImage m_n6;
		public GImage m_n7;
		public GImage m_n8;
		public GImage m_n9;
		public GLoader m_head;
		public GLoader m_vip;
		public UI_btn_close m_btn_close;
		public UI_btn_editor m_btn_editorNickname;
		public UI_btn_editor m_btn_editorSign;
		public UI_ProgressBar1 m_slid;
		public GRichTextField m_text_editorHead;
		public GTextInput m_text_nickname;
		public GTextField m_text_coins;
		public GTextField m_text_masonry;
		public GTextField m_text_gaiming;
		public GTextField m_text_qiangzuo;
		public GTextField m_text_addTime;
		public GTextField m_text_account;
		public GTextField m_text_id;
		public GTextInput m_text_sign;
		public GTextField m_text_shengchang;
		public GTextField m_text_shuchang;
		public GTextField m_text_shenglv;
		public GTextField m_text_level;
		public GTextField m_text_exp;
		public GImage m_n51;
		public GImage m_n52;
		public GImage m_n53;
		public GTextField m_n24;
		public GTextField m_n25;
		public GTextField m_n27;
		public GTextField m_n30;
		public GTextField m_n32;
		public GTextField m_n34;
		public GTextField m_n36;
		public UI_Update m_updateQueren;

		public const string URL = "ui://5wbi0yeuaeent9v";

		public static UI_selfInfo CreateInstance()
		{
			return (UI_selfInfo)UIPackage.CreateObject("Info","selfInfo");
		}

		public UI_selfInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_c2 = this.GetControllerAt(1);
			m_n39 = (GImage)this.GetChildAt(0);
			m_bg = (GImage)this.GetChildAt(1);
			m_bg1 = (GImage)this.GetChildAt(2);
			m_bg2 = (GImage)this.GetChildAt(3);
			m_bg3 = (GImage)this.GetChildAt(4);
			m_n6 = (GImage)this.GetChildAt(5);
			m_n7 = (GImage)this.GetChildAt(6);
			m_n8 = (GImage)this.GetChildAt(7);
			m_n9 = (GImage)this.GetChildAt(8);
			m_head = (GLoader)this.GetChildAt(9);
			m_vip = (GLoader)this.GetChildAt(10);
			m_btn_close = (UI_btn_close)this.GetChildAt(11);
			m_btn_editorNickname = (UI_btn_editor)this.GetChildAt(12);
			m_btn_editorSign = (UI_btn_editor)this.GetChildAt(13);
			m_slid = (UI_ProgressBar1)this.GetChildAt(14);
			m_text_editorHead = (GRichTextField)this.GetChildAt(15);
			m_text_nickname = (GTextInput)this.GetChildAt(16);
			m_text_coins = (GTextField)this.GetChildAt(17);
			m_text_masonry = (GTextField)this.GetChildAt(18);
			m_text_gaiming = (GTextField)this.GetChildAt(19);
			m_text_qiangzuo = (GTextField)this.GetChildAt(20);
			m_text_addTime = (GTextField)this.GetChildAt(21);
			m_text_account = (GTextField)this.GetChildAt(22);
			m_text_id = (GTextField)this.GetChildAt(23);
			m_text_sign = (GTextInput)this.GetChildAt(24);
			m_text_shengchang = (GTextField)this.GetChildAt(25);
			m_text_shuchang = (GTextField)this.GetChildAt(26);
			m_text_shenglv = (GTextField)this.GetChildAt(27);
			m_text_level = (GTextField)this.GetChildAt(28);
			m_text_exp = (GTextField)this.GetChildAt(29);
			m_n51 = (GImage)this.GetChildAt(30);
			m_n52 = (GImage)this.GetChildAt(31);
			m_n53 = (GImage)this.GetChildAt(32);
			m_n24 = (GTextField)this.GetChildAt(33);
			m_n25 = (GTextField)this.GetChildAt(34);
			m_n27 = (GTextField)this.GetChildAt(35);
			m_n30 = (GTextField)this.GetChildAt(36);
			m_n32 = (GTextField)this.GetChildAt(37);
			m_n34 = (GTextField)this.GetChildAt(38);
			m_n36 = (GTextField)this.GetChildAt(39);
			m_updateQueren = (UI_Update)this.GetChildAt(40);
		}
	}
}