using Load;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;

public  class UIGameTips  : WTUIPage<UI_gameTips, LoadingCtrl>
{
    public UIGameTips() : base(UIType.Normal, UIMode.DoNothing, R.UI.LOAD)
    {

    }

    public override void Awake()
    {
 
    }
}
