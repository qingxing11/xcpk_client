using SendRedEnvelope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;

public class UIRedEnvelope : WTUIPage<UI_RedEnvelope, SendRedEnvelopeCtrl>
{
    public int userId;
    public Action<int, int> sendRedEnvelope;

    public UIRedEnvelope() : base(UIType.Normal, UIMode.DoNothing, R.UI.SENDREDENVELOPE)
    {
    }

    public override void Awake()
    {
        UIPage.m_clickHide.onClick.Add(Hide);
        UIPage.m_red_50W.onClick.Add(() => { sendRedEnvelope.Invoke(userId, 500000); Hide(); });
        UIPage.m_red_100W.onClick.Add(() => { sendRedEnvelope.Invoke(userId, 800000); Hide(); });
        UIPage.m_red_200W.onClick.Add(() => { sendRedEnvelope.Invoke(userId, 1000000); Hide(); });
    }



    public void SetUserIdPanle(int userId)
    {
        this.userId = userId;
    }


    public UIClickRedEnvelope ReturnUIClickRedEnvelope(int index)
    {
        return ShowPage<UIClickRedEnvelope>("redEnvelope" + index);
    }
}