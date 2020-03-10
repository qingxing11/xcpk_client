namespace WT.UI
{
    using UnityEngine;
    using System.Collections;
    using FairyGUI;

    public class WTUIBind : MonoBehaviour
    {
        static bool isBind = false;

        /// <summary>
        /// 绑定自已定义的加载器
        /// </summary>
        public static void Bind()
        {
            if (!isBind)
            {
                isBind = true;
                
                WTUIPage.delegateSyncLoadUIByLocal = FileIO.LoadFairyGUI;
            }
        }
    }
}