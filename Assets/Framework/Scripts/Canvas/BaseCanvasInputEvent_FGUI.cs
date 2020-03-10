using FairyGUI;
using System;
using UnityEngine;
/// <summary>
/// canvas输入事件扩展
/// </summary>
partial class BaseCanvas
{
    public enum TouchAction
    {
        Touch,
        Drag,
        Scale
    }

    private TouchAction _action = TouchAction.Touch;
    private float lastDistance = -1f;

    private SwipeGesture swipeGesture;
    private long touchTime;
    private const int ACTION_TIME_OUT = 250;
    private bool isAction = false;

    /// <summary>
    /// 老的已有代码需激活事件中心，新功能建议直接使用单独输入事件
    /// </summary>
    protected void ActivationInputEventCenter()
    {
 
        Stage.inst.onTouchBegin.Clear();
        Stage.inst.onTouchBegin.Add(OnTouchBegin);
       
        Timers.inst.Add(0.01f, -1, Callback);
 
        swipeGesture = new SwipeGesture(GRoot.inst);
        swipeGesture.onAction.Clear();
        swipeGesture.onAction.Add((context) => {
            OnTouchAction(context);
        });
    }

   
    private void OnTouchAction(EventContext context)
    {
        SwipeGesture sg = (SwipeGesture)context.sender;

        long use = MyTimeUtil.GetCurrTimeMM - touchTime;
       
        if (use > ACTION_TIME_OUT)
        {
            isAction = false;
        }
      

        if (isAction)
        {
            EventCenter.Broadcast<SwipeGesture>(EventDefine.TouchAction, sg);
            isAction = false;
        }
    }

    private bool isDrag;
    protected void OnTouchBegin(Action<EventContext> method)
    {
        Stage.inst.onTouchBegin.Add((context)=> {
           

            method(context);
            isDrag = true;
        });
    }

    protected void OnTouchDrag(Action<EventContext> method)
    {
        Stage.inst.onTouchMove.Add((context) => {
            if (isDrag)
            {
                method(context);
            }
        });
    }

    protected void OnTouchEnd(Action<EventContext> method)
    {
        Stage.inst.onTouchEnd.Add((context) => {
            method(context);
            isDrag = false;
        });
    }

    /// <summary>
    /// 鼠标滚轮
    /// </summary>
    /// <param name="o"></param>
    private void Callback(object o)
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (wheel > 0)
        {
            EventCenter.Broadcast(EventDefine.TouchScale, -1);
        }
        else if (wheel < 0)
        {
            EventCenter.Broadcast(EventDefine.TouchScale, 1);
        }
    }

    private void OnTouchBegin(EventContext context)
    {
        Stage.inst.onTouchMove.Add(OnStageTouchMove);
        Stage.inst.onTouchEnd.Add(OnRootTouchEnd);
        if (Stage.isTouchOnUI)
        {
            return;
        }
        if (Stage.inst.touchCount == 1)
        {
            _action = TouchAction.Drag;
        }
        else if (Stage.inst.touchCount > 1)
        {
            _action = TouchAction.Scale;
        }
        touchTime = MyTimeUtil.GetCurrTimeMM;
        isAction = true;

 
        EventCenter.Broadcast(EventDefine.TouchBegin, context.inputEvent.touchId, context.inputEvent.position);
    }

    private void OnStageTouchMove(EventContext context)
    {
        if (_action == TouchAction.Drag)
        {
            EventCenter.Broadcast(EventDefine.TouchDrag, context.inputEvent.touchId, context.inputEvent.position);
           

        }
        else if (_action == TouchAction.Scale)
        {
            if (lastDistance < 0)
            {
                lastDistance = Vector3.Distance(Stage.inst.GetTouchPosition(0), Stage.inst.GetTouchPosition(1));
            }
            else
            {
                float nowDisTance = Vector3.Distance(Stage.inst.GetTouchPosition(0), Stage.inst.GetTouchPosition(1));
                EventCenter.Broadcast(EventDefine.TouchScale, nowDisTance < lastDistance ? 1 : -1);

                lastDistance = nowDisTance;
            }
        }
    }

    private void OnRootTouchEnd(EventContext context)
    {
        Stage.inst.onTouchEnd.Remove(OnRootTouchEnd);
        Stage.inst.onTouchMove.Remove(OnStageTouchMove);

        switch (_action)
        {
            case TouchAction.Drag:
                if (!Stage.isTouchOnUI)
                {
                    _action = TouchAction.Touch;
                    EventCenter.Broadcast(EventDefine.TouchDragEnd);
                }
                break;
            case TouchAction.Scale:
                _action = TouchAction.Touch;
                EndScale();
                break;
            case TouchAction.Touch:
                break;
        }
        if (!Stage.isTouchOnUI)
        {
           
            EventCenter.Broadcast(EventDefine.TouchEnd, context.inputEvent.touchId, context.inputEvent.position);
        }
    }

    private void EndScale()
    {
        EventCenter.Broadcast(EventDefine.TouchScaleEnd);

        lastDistance = -1;
    }

    
}