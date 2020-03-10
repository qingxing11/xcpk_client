using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using WT.UI;
using XLua;

public static class HotfixCfg
{
    [Hotfix]
    public static List<Type> by_field = new List<Type>()
    {
        typeof(NetWorkClient),
        typeof(FileIO),
        typeof(HelperClass),
        typeof(WTUIPage),
        typeof(TipsManager),

     
        typeof(InitGameCanvas),
        typeof(LoginCanvas),
       

    };

    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>() {
                typeof(Vector3),
                typeof(GameObject),
                typeof(Transform),
                typeof(Button),
                typeof(Image),
                typeof(RectTransform),
            };

    //[LuaCallCSharp]
    //public static List<Type> LuaCallCSharp_unityUI
    //{
    //    get
    //    {
    //        string nspace = "UnityEngine.UI";

    //        var q = from t in Assembly.GetExecutingAssembly().GetTypes()
    //                where t.IsClass && t.Namespace == nspace
    //                select t;
    //        q.ToList().ForEach(t => Console.WriteLine(t.Name));

    //        return q.ToList();

    //    }
    //}
}