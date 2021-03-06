using UnityEngine;
using System.Collections;

public enum EventDefine
{
    /// <summary>
    /// 世界地图数据加载完成
    /// </summary>
    MAP_DATA_LOAD_Complete,
    
    /// <summary>
    /// 开始,触摸
    /// 参数touchId,vecter2d
    /// </summary>
    TouchBegin,
    /// <summary>
    /// 放开,触摸
    /// 参数touchId,vecter2d
    /// </summary>
    TouchEnd,
    /// <summary>
    /// 触摸-拖动
    /// 参数touchId,vecter2d
    /// </summary>
    TouchDrag,
    /// <summary>
    /// 触摸-拖动结束
    /// </summary>
    TouchDragEnd,
    /// <summary>
    /// 触摸-缩放
    /// ,1: 放大,-1:缩小
    /// </summary>
    TouchScale,
    /// <summary>
    /// 停止缩放
    /// </summary>
    TouchScaleEnd,

    TouchAction,


    /// <summary>
    /// 船死了
    /// </summary>
    ShipDead,
    /// <summary>
    /// 微信登陆
    /// </summary>
    WeXinLogin,
    /// <summary>
    /// 玩家属性变更
    /// </summary>
    PlayerPropertyChange,
    AmryListUpdate,
    OnClickMerchant,
    CancelMerchantRoad,
    CoinsChange,
}
