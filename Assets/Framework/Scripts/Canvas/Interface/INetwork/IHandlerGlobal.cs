public interface IHandlerGlobal : IHandlerReceive
{
    
    /// <summary>
    /// 客户端掉线事件
    /// </summary>
    void LostConnect();
}