using SendRedEnvelope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;
using DG.Tweening;
using UnityEngine;
using FairyGUI;

public class UIClickRedEnvelope : WTUIPage<UI_clickRedEnvelope, SendRedEnvelopeCtrl>
{

    public int redEnvelopeIndex;
    private long redEnvelopeValue;

    public Action<int, long> sendGardRedEnvelope;
    public UIClickRedEnvelope() : base(UIType.PopUp, UIMode.DoNothing, R.UI.SENDREDENVELOPE)
    {
    }

    public override void Awake()
    {
        
        UIPage.m_click.onClick.Add(()=> {
            //Hide();
            sendGardRedEnvelope.Invoke(redEnvelopeIndex,redEnvelopeValue);
        });
    
    }

    public void SetRedIndexAndValue(int redEnvelopeIndex, long redEnvelopeValue)
    {
        this.redEnvelopeIndex = redEnvelopeIndex;
        this.redEnvelopeValue = redEnvelopeValue;
    }

    GTweener tweener;
    public void Move(Vector3 endPos)
    {
        float a = UnityEngine.Random.Range(900, 1500);
        tweener = UIPage.TweenMove(endPos,a/100+redEnvelopeIndex*0.01f).OnComplete(()=> {
            tweener.Kill();
        });
    }

}