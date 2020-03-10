using UnityEngine;

public class LoginCanvas : BaseCanvas
{
    private static int testIndex;
    private int testLocal;


    private const long LOGIN_TIME_OUT = 20 * MyTimeUtil.TIME_S;

 

    private long startLoginTime;
    private bool isStartLogin;
    void Awake()
    {
         AddAudioControl();
         AddHandlerGlobalReceiveEvent<GlobalReceiveCanvas>();
        
        //testLocal = testIndex;
        //testIndex++;
        //isStartLogin = false;
        ////微信授权

        ////AddAppPayControl();
  
        //PlayBGM(R.AudioClip.LOGINBGM);

        ActivationConntroller<LoginCtrl>();
 
    }
     
    private void InitUI()
    {


    }
     
    protected override void Update()
    {
        base.Update();
    }
}