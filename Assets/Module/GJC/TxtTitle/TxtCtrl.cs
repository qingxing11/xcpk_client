using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TxtCtrl : BaseController
{
    private UITxtCom uiTxtCom;
    private List<string> info;
    private int index;
    private Tween tween;
    private float hideTime = 0.5f;
    public override void InitAction()
    {
        uiTxtCom = GetUIPage<UITxtCom>();
        uiTxtCom.over = Over;
    }

    private void Over()
    {
        uiTxtCom.Hide();
        index++;
        tween = DOTween.To(() => hideTime, (value) => { }, 1, hideTime).OnComplete(showNext);
    }

    private void showNext()
    {
        if (info != null && index < info.Count)
        {
            ShowUIIxtCom();
            uiTxtCom.ShowTxt2(info[index]);
        }
    }

    public void Show(string txt)
    {
        if (string.IsNullOrEmpty(txt))
        {
            return;
        }
        ShowUIIxtCom();
        uiTxtCom.ShowTxt(txt);
    }

    public void Show(List<string> info)
    {
        if (info==null)
        {
            return;
        }
        index = 0;
        this.info = info;
        ShowUIIxtCom();
        uiTxtCom.ShowTxt2(info[index]);
    }

    private void ShowUIIxtCom()
    {
        ShowUI <UITxtCom>();
    }
}