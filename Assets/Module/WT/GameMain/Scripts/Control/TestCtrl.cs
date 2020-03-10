using DG.Tweening;
using WT.UI;

public class TestCtrl : BaseController
{
    private UITest uiTest;
    private UITest1 uitest1;
    
    public override void InitAction()
    {
        
        uitest1 = WTUIPage.ShowPage<UITest1>();

        uiTest = WTUIPage.ShowPage<UITest>();
         uiTest.ChangeRoot(UIType.PopUp);
    }
 
}