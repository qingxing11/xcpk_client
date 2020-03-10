using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using WT.UI;

public class UINetError : WTUIPage<UI_NetError, NetCtrl>
{
    public UINetError() : base(UIType.Dialog, UIMode.DoNothing, R.UI.MAIN)
    {
    }
   
    public override void Awake()
    {
        UIPage.m_btn_sure.onClick.Add(()=> {
            
             
            
            SceneManager.LoadScene("InitScene");
            
        });
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_btn_cancel.onClick.Add(Hide);
    }
}
