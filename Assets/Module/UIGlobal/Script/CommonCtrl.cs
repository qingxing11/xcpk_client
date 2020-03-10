
using System;
using System.Text.RegularExpressions;
using Common;
using Module.Common;
using UnityEngine;
using WT.UI;

public class CommonCtrl : BaseController, IHandlerReceive
{

   

    public override void InitAction()
    {
 

    }
     

    private void event_clickCreate()
    {
        TestRequest request = new TestRequest
        {
            testText = "akwang",
        };
        SendMessage(request);
    }


    public Response RunServerReceive(Response response)
    {
        //Debug.Log("commonCtrl:"+ response.msgType);
        if (response != null)
        {

            switch (response.msgType)
            {
                case MsgType.TEST:
                    TestResponse login = MySerializerUtil.DeSerializerFromProtobufNet<TestResponse>(response.data);
                    Debug.Log("login:" + login);
                    break;

                default:
                    return response;
            }
        }
        return null;
    }

}