using WT.UI;
using FairyGUI;
using Load;
using UnityEngine.SceneManagement;

public class UILoading : WTUIPage<UI_Loading, LoadingCtrl>
{

    public UILoading() : base(UIType.Normal, UIMode.DoNothing, R.UI.LOAD)
    {

    }

    public override void Refresh()
    {
        UIPage.m_loadIndex.value = 0;
        GTweener tweenr = UIPage.m_loadIndex.TweenValue(100, 2);
        tweenr.OnComplete(() => {
            Hide();
            SceneManager.LoadScene("Login");
            //BaseCanvas.GetController<LoginCtrl>().Show();
        });
    }

    public override void Awake()
    {
        base.Awake();
       
    }

}

