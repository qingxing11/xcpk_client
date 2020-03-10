using GameTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;

public  class UITaskTiShi : WTUIPage<UI_TiShi, TaskCtrl>
{
    public UITaskTiShi() : base(UIType.PopUp, UIMode.DoNothing, R.UI.GAMETASK)
    {
    }
    public override void Awake()
    {
        UIPage.m_click.onClick.Add(Hide);
    }

    public void Play(string name)
    {
        UIPage.m_tiShi.m_name.text = " 您已完成“[color=#D77923]"+ name+ "！[/color]”任务";
        UIPage.m_tiShiPlay.Play();
        
    }
}