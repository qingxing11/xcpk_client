using UnityEngine;
using WT.UI;

public abstract class BaseController
{
    protected void SendMessage(Request request)
    {
        NetWorkClient.sendRequest(request);
    }

    public U ShowUI<U>() where U : WTUIPage, new()
    {
        return ShowUI<U>(null);
    }

    public U ShowUI<U>(string pageName) where U : WTUIPage, new()
    {
        return WTUIPage.ShowPage<U>(pageName);
    }

    public U ShowOnTransform<U>(string pageName, Transform node, int layer) where U : WTUIPage, new()
    {
        return WTUIPage.ShowOnTransform<U>(pageName, node, layer);
    }

    public U ShowOnTransform<U>(Transform node, int layer) where U : WTUIPage, new()
    {
        return WTUIPage.ShowOnTransform<U>(null, node, layer);
    }

    /// <summary>
    /// 功能模块对应的所有面板中事件必须在此方法中实现
    /// </summary>
    public abstract void InitAction();


    protected C GetController<C>() where C : BaseController, new()
    {

        return BaseCanvas.GetController<C>();
    }


    protected T GetUIPage<T>() where T : WTUIPage, new()
    {
        return GetUIPage<T>(null);
    }

    protected T GetUIPage<T>(string name) where T : WTUIPage, new()
    {
        return WTUIPage.GetUIPage<T>(name);
    }
}