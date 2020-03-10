using UnityEngine;
using System.Collections;
using System;
using WT.UI;

public class GlobalReceiveControl
{
   

    public Action AddEventCancelReConnect;
    public GlobalReceiveControl()
    {


    }



    public void OnShowServerError(string info)
    {
         
    }

    private void Button_CancelReConnect()
    {
        if (AddEventCancelReConnect != null)
        {
            AddEventCancelReConnect();
        }
    }


    public void OnShowGamePause(bool isShow)
    {

    }
}
