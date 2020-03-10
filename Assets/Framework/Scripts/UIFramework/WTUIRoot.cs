
namespace WT.UI
{
    using UnityEngine;
    using FairyGUI;
    using static FairyGUI.UIContentScaler;

    public class WTUIRoot
    {
        public const int SCENE_W = 800;
        public const int SCENE_H = 480;

        private static WTUIRoot m_Instance = null;
        public static WTUIRoot Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new WTUIRoot();
                    InitRoot();
                }
                return m_Instance;
            }
        }

        public GRoot root;
        public GRoot touchRoot;
        public GRoot fixedRoot;
        public GRoot normalRoot;
        public GRoot popupRoot;
        public GRoot dialog;
        static void InitRoot()
        {

            m_Instance.root = GRoot.inst;
            m_Instance.root.SetContentScaleFactor(SCENE_W, SCENE_H, ScreenMatchMode.MatchWidthOrHeight);
             

           m_Instance.touchRoot = new GRoot()
            {
                name = "TouchRoot"
            };
            m_Instance.touchRoot.SetContentScaleFactor(SCENE_W, SCENE_H, ScreenMatchMode.MatchWidthOrHeight);

            m_Instance.normalRoot = new GRoot()
            {
                name = "NormalRoot"
            };
           
            m_Instance.normalRoot.SetContentScaleFactor(SCENE_W, SCENE_H, ScreenMatchMode.MatchWidthOrHeight);

            m_Instance.fixedRoot = new GRoot()
            {
                name = "FixedRoot"
            };
            m_Instance.fixedRoot.SetContentScaleFactor(SCENE_W, SCENE_H, ScreenMatchMode.MatchWidthOrHeight);

            m_Instance.popupRoot = new GRoot()
            {
                name = "PopupRoot"
            };
            m_Instance.popupRoot.SetContentScaleFactor(SCENE_W, SCENE_H, ScreenMatchMode.MatchWidthOrHeight);

            m_Instance.dialog = new GRoot()
            {
                name = "dialog"
            };
            m_Instance.dialog.SetContentScaleFactor(SCENE_W, SCENE_H, ScreenMatchMode.MatchWidthOrHeight);
            

            //m_Instance.root.AddChild(m_Instance.normalRoot);
            //m_Instance.root.AddChild(m_Instance.fixedRoot);
            //m_Instance.root.AddChild(m_Instance.popupRoot);

            Stage.inst.AddChild(m_Instance.touchRoot.displayObject);
            Stage.inst.AddChild(m_Instance.normalRoot.displayObject);
            Stage.inst.AddChild(m_Instance.fixedRoot.displayObject);
            Stage.inst.AddChild(m_Instance.popupRoot.displayObject);
            Stage.inst.AddChild(m_Instance.dialog.displayObject);
        }


        void OnDestroy()
        {
            m_Instance = null;
        }
    }
}