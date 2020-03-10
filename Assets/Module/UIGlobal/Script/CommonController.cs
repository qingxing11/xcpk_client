
using UnityEngine;
using WT.UI;

public class CommonController : BaseController, IHandlerReceive
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
        if (response != null)
        {
            Debug.Log("response.msgType:" + response.msgType);
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