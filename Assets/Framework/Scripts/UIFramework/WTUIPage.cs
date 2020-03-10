using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using FairyGUI;
using System.Reflection;

using Config;
using System.Reflection.Emit;

namespace WT.UI
{
    #region define
    public enum UIType
    {
        /// <summary>
        /// 拖动，缩放
        /// </summary>
        Touch,
        Normal,
        Fixed,

        /// <summary>
        /// 弹出窗口，需要关闭当前才可操作其他
        /// </summary>
        PopUp,

        /// <summary>
        /// 
        /// </summary>
        Dialog,

        /// <summary>
        /// 独立的窗口(无遮挡效果)
        /// </summary>
        None,

    }

    public enum UIMode
    {
        /// <summary>
        /// 
        /// </summary>
        DoNothing,

        /// <summary>
        /// 关闭其他界面
        /// </summary>
        HideOther,

        /// <summary>
        ///  点击返回按钮关闭当前,不关闭其他界面(需要调整好层级关系)
        /// </summary>
        NeedBack,

        /// <summary>
        /// 关闭TopBar,关闭其他界面,不加入backSequence队列
        /// </summary>
        NoNeedBack,
    }

    #endregion

    public class WTUIPage<U, C> : WTUIPage where U : GComponent, new() where C : BaseController, new()
    {
        protected WTUIPage(UIType type, UIMode mode, int index) : base(type, mode)
        {
            uiIndex = index;
            SetUI<U>();
            SetCtrl<C>();
        }

        public virtual void ShowSelf() { }

        protected override void InitLanguage()
        {
            //string pathName = typeof(U).Name;
            //Debug.Log("pathName:"+ pathName);

            //MethodInfo method = ConfigManager.Configs.GetType().GetMethod("get_DataArmy");
            //Debug.Log("method:"+ method);
            //Dictionary<int, DataArmy> map = method.Invoke(ConfigManager.Configs, null) as Dictionary<int, DataArmy>;
            //foreach (var item in map)
            //{
            //    Debug.Log("item:"+item.Value);
            //    foreach (var item1 in item.Value.GetType().GetRuntimeFields())
            //    {
            //        Debug.Log("item1:"+item1.Name);
            //    }

            //}

            //foreach (var item in ConfigManager.Configs.GetType().GetRuntimeMethods())
            //{
            //    Debug.Log("config.Name:" + item);
            //}


            //Debug.Log("U:"+typeof(U));
            //foreach (var item in UIPage.GetType().GetRuntimeFields())
            //{
            //    Debug.Log("item:" + item.Name);
            //}
        }

        protected U UIPage
        {
            get
            {
                return getGComponent() as U;
            }
        }


    }

    /// <summary>
    /// 一个UIPage使用一个FairyGUI自动生成的UI:GComponent组件数据来显示（将GComponent转化为window）
    /// </summary>
    /// 
    public class WTUIPage
    {
        public string name = string.Empty;

        //页面id 
        public int id = -1;

        //页面类型
        public UIType type = UIType.Normal;

        //页面打开模式
        public UIMode mode = UIMode.DoNothing;

        /// <summary>
        /// ui路径，已经改为使用索引
        /// </summary>
        //public string uiPath = string.Empty;

        /// <summary>
        /// ui预制体索引
        /// </summary>
        protected int uiIndex;

        /// <summary>
        /// ui的gameObject
        /// </summary>
        public Window window;
        protected GRoot gRoot;
        protected GComponent gComponent;

        private MethodInfo method_bindAll;
        private MethodInfo method_createInstance;

        public Transform transform;
        private int layer;
        private string uiName;
        private UIPanel uiPanel;
        private BaseController baseCtrl;
        private bool isUiPanel = false;


        protected WTUIPage(UIType type, UIMode mod)
        {
            this.type = type;
            this.mode = mod;

            this.name = this.GetType().ToString();
            WTUIBind.Bind();
        }

        protected void SetUI<U>() where U : GComponent
        {
            Type u = typeof(U);
            method_createInstance = u.GetMethod("CreateInstance");
            string name = GetType().Name;
            uiName = typeof(U).Name;
        }

        protected void SetCtrl<C>()
        {

        }

        public GComponent getGComponent()
        {
            if (isUiPanel)
            {
                return uiPanel.ui;
            }
            else
            {
                return gComponent;
            }
        }

        public UIPanel GetUIPanel()
        {
            if (isUiPanel)
            {
                return uiPanel;
            }
            Debug.LogError("页面不是UIpanel");
            return null;
        }

        public WTUIPage SetScale(float x, float y)
        {
            if (isUiPanel)
            {
                transform.localScale = new Vector2(x, y);
            }
            else
            {
                getGComponent().SetScale(x, y);
            }

            return this;
        }

        public virtual WTUIPage SetPosition(float x, float y, float z)
        {
            if (isUiPanel)
            {
                transform.localPosition = new Vector3(x, y, z);
            }
            else
            {
                getGComponent().SetPosition(x, y, z);
            }
            return this;
        }

        public virtual WTUIPage SetPosition(float x, float y)
        {
            return SetPosition(x, y, 0);
        }



        public virtual WTUIPage SetPosition(Vector3 v3)
        {
            //window.position = v3;

            getGComponent().SetPosition(v3.x, v3.y, v3.z);
            return this;

            //return SetPosition(v3.x,v3.y,v3.z);
        }

        public Vector3 Position
        {
            get
            {
                return getGComponent().position;
            }
        }

        public WTUIPage SetRotate(float x, float y = 0, float z = 0)
        {
            if (isUiPanel)
            {
                transform.Rotate(x, y, z);
            }
            else
            {
                getGComponent().rotation = x;
            }

            return this;
        }

        //所有的页面
        private static Dictionary<string, WTUIPage> m_allPages = new Dictionary<string, WTUIPage>();
        public static Dictionary<string, WTUIPage> allPages
        {
            get
            {
                //Debug.Log("getAllPages");
                return m_allPages;
            }
        }


        private static List<WTUIPage> m_currentPageNodes;
        private static List<WTUIPage> currentPageNodes
        { get { return m_currentPageNodes; } }

        /// <summary>
        /// 获取Page类对应的ui，对应调用Show<T>()显示的唯一ui
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetUIPage<T>() where T : WTUIPage, new()
        {
            return GetUIPage<T>(null) as T;
        }

        /// <summary>
        /// 获取Page类对应的ui,name为空时获取名称为类名的Page(对应Show<T>())，否侧获取名称为name的Page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetUIPage<T>(string name) where T : WTUIPage, new()
        {
            string pageName = typeof(T).Name;
            if (!string.IsNullOrEmpty(name))
            {
                pageName = pageName + name;
            }

            WTUIPage page = allPages.GetValue(pageName);
            //Debug.Log("pageName:" + pageName+ ",page:"+ page);
            if (page == null)
            {
                T t = new T();//此处发生递归，中断字典插入执行
                t.name = pageName;         //Debug.LogError("[UI]获取page页面错误,UI界面[" + pageName + "]为空!");
                allPages.AddValue(pageName, t);

                return t;
            }
            return page as T;
        }

        /// <summary>
        /// 检查UI是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsUiExist<T>(string name)
        {
            string pageName = typeof(T).Name;
            if (!string.IsNullOrEmpty(name))
            {
                pageName = pageName + name;
            }
            return allPages.ContainsKey(name);
        }

        /// <summary>
        /// 是否异步加载模式
        /// </summary>
        private bool isAsyncUI = false;

        /// <summary>
        /// 是否激活
        /// </summary>
        protected bool isActived = false;

        /// <summary>
        /// 界面数据，重新打开时刷新
        /// </summary>
        private object m_data = null;
        protected object data { get { return m_data; } }

        /// <summary>
        /// 本地加载器
        /// </summary>
        public static Func<int, UIPackage> delegateSyncLoadUIByLocal = null;
        public static Func<string, UIPackage> delegateSyncLoadUIByLocalStringPath = null;
        /// <summary>
        /// 远程加载器
        /// </summary>
         //public static Func<string, Object> delegateSyncLoadUIByRemote = null;

        public static Action<string, Action<Object>> delegateAsyncLoadUI = null;

        #region virtual api

        /// <summary>
        /// 当初始化ui时调用一次
        /// </summary>
        ///
        public virtual void Awake()
        {

        }

        /// <summary>
        /// 刷新界面，在Awake之后调用，每次打开界面时都会调用
        /// </summary>
        public virtual void Refresh() { }

        /// <summary>
        /// 激活ui
        /// </summary>
        public virtual void Active()
        {
            if (!isUiPanel)
            {
                this.window.ShowOn(gRoot);
            }

            isActived = true;
        }




        protected virtual void InitLanguage()
        {

        }

        public bool IsUiPanel()
        {
            return isUiPanel;
        }

        public virtual void Hide()
        {
            if (!isUiPanel)
            {
                HideWindow();
            }
            else
            {
                HideUIPanel();
            }

            isActived = false;

            this.m_data = null;
        }

        private void HideUIPanel()
        {
            if (transform != null)
            {
                Object.Destroy(transform.gameObject);
            }
        }

        private void HideWindow()
        {
            if (window != null)
            {
                window.Hide();

            }
        }

        #endregion

        #region internal api
        protected void ShowWindow()
        {
            if (this.window == null && uiIndex >= 0)
            {
                Window window = null;
                UIPackage o = null;
                if (delegateSyncLoadUIByLocal != null)
                {
                    o = delegateSyncLoadUIByLocal(uiIndex);
                }

                if (o != null)
                {

                    gComponent = method_createInstance.Invoke(null, null) as GComponent;//调用UI的CreateInstance

                }
                else
                {
                    Debug.LogError("[UI] 同步加载显示ui时错误,uiPath:" + R.UI.path[uiIndex] + ",检查是否设置了索引");
                    return;
                }

                if (gComponent != null)
                {
                    //gComponent.MakeFullScreen();


                    window = new Window
                    {
                        contentPane = gComponent.asCom
                    };
                    InitLanguage();
                }
                else
                {
                    Debug.LogError("[UI] 同步加载显示ui时错误,uiPath:[" + R.UI.path[uiIndex] + "],检查是否设置了索引");
                    return;
                }

                if (window == null)
                {
                    Debug.LogError("[UI] 同步加载显示ui时错误,uiPath:[" + R.UI.path[uiIndex] + "],检查是否设置了索引");
                    return;
                }
                this.window = window;


                AnchorUIGameObject(window);
                window.contentPane.SetSize(gRoot.width, gRoot.height);

                window.ShowOn(gRoot);

                window.SetScale(gRoot.width / WTUIRoot.SCENE_W, gRoot.height / WTUIRoot.SCENE_H);
                //第一次初始化的时候调用Awake

                Awake();

                isAsyncUI = false;
            }


            Active();


            Refresh();


            PopNode(this);
        }

        protected void ShowOnTransform(Transform node, int layer)
        {
            if (uiPanel == null && uiIndex >= 0)
            {
                UIPackage o = null;
                if (delegateSyncLoadUIByLocal != null)
                {
                    o = delegateSyncLoadUIByLocal(uiIndex);
                }

                if (o == null)
                {
                    Debug.LogError("[UI] 同步加载显示ui时错误,uiPath:" + R.UI.path[uiIndex] + ",检查是否设置了索引");
                    return;
                }

                GameObject gameObject = new GameObject
                {
                    name = "UIPanel"
                };
                gameObject.layer = LayerMask.NameToLayer("Fairygui_panel");


                gameObject.transform.SetParent(node);
                transform = gameObject.transform;
                uiPanel = gameObject.AddComponent<UIPanel>();
                isUiPanel = true;

                string[] pathNameArr = R.UI.path[uiIndex].Split('/');
                string pathName = pathNameArr[pathNameArr.Length - 1];
                uiPanel.packageName = pathName;
                string name = uiName.Substring(3);//去掉"UI_",暂时写死，gui导出数据时必须以"UI_"开头
                uiPanel.componentName = name;
                uiPanel.SetSortingOrder(layer, true);

                //设置renderMode的方式
                uiPanel.container.renderMode = RenderMode.WorldSpace;

                uiPanel.CreateUI();

                Awake(); //第一次初始化的时候调用Awake
                InitLanguage();
                isAsyncUI = false;

            }
            else
            {

                GameObject gameObject = new GameObject
                {
                    name = "UIPanel"
                };
                gameObject.layer = LayerMask.NameToLayer("Fairygui_panel");


                gameObject.transform.SetParent(node);
                transform = gameObject.transform;
                uiPanel = gameObject.AddComponent<UIPanel>();
                isUiPanel = true;

                string[] pathNameArr = R.UI.path[uiIndex].Split('/');
                string pathName = pathNameArr[pathNameArr.Length - 1];
                uiPanel.packageName = pathName;
                string name = uiName.Substring(3);//去掉"UI_",暂时写死，gui导出数据时必须以"UI_"开头
                uiPanel.componentName = name;
                uiPanel.SetSortingOrder(layer, true);

                //设置renderMode的方式
                uiPanel.container.renderMode = RenderMode.WorldSpace;


                InitLanguage();
                isAsyncUI = false;
                Debug.Log(" uiPanel.packageName:" + uiPanel.packageName);
            }

            Active();


            Refresh();


            //PopNode(this);
        }

        /// <summary>
        /// 异步显示
        /// </summary>
        protected void Show(Action callback)
        {
            //WTUIRoot.Instance.StartCoroutine(AsyncShow(callback));
        }

        /// <summary>
        /// 异步显示
        /// </summary>
        IEnumerator AsyncShow(Action callback)
        {
            if (this.window == null && string.IsNullOrEmpty(R.UI.path[uiIndex]) == false)
            {
                Window go = null;
                bool _loading = true;
                delegateAsyncLoadUI(R.UI.path[uiIndex], (o) =>
                {
                    //go = o != null ? GameObject.Instantiate(o) as GameObject : null;
                    AnchorUIGameObject(go);
                    Awake();
                    isAsyncUI = true;
                    _loading = false;


                    Active();


                    Refresh();


                    PopNode(this);

                    if (callback != null) callback();
                });

                float _t0 = Time.realtimeSinceStartup;
                while (_loading)
                {
                    if (Time.realtimeSinceStartup - _t0 >= 10.0f)
                    {
                        Debug.LogError("[UI] WTF async load your ui prefab timeout!");
                        yield break;
                    }
                    yield return null;
                }
            }
            else
            {

                Active();


                Refresh();


                PopNode(this);

                if (callback != null) callback();
            }
        }

        private bool CheckIfNeedBack()
        {
            if (type == UIType.Touch || type == UIType.Fixed || type == UIType.PopUp || type == UIType.None) return false;
            else if (mode == UIMode.NoNeedBack || mode == UIMode.DoNothing) return false;
            return true;
        }

        public GRoot GetGRoot()
        {
            return gRoot;
        }

        protected void AnchorUIGameObject(Window ui)
        {
            if (WTUIRoot.Instance == null || ui == null) return;

            this.window = ui;
            this.gRoot = ui.root;

            switch (type)
            {
                case UIType.Touch:
                    gRoot = WTUIRoot.Instance.touchRoot;
                    break;
                case UIType.Normal:
                    gRoot = WTUIRoot.Instance.normalRoot;
                    break;
                case UIType.Fixed:
                    gRoot = WTUIRoot.Instance.fixedRoot;
                    break;
                case UIType.PopUp:
                    gRoot = WTUIRoot.Instance.popupRoot;
                    break;
                case UIType.Dialog:
                    gRoot = WTUIRoot.Instance.dialog;
                    break;
                case UIType.None:
                    break;
                default:
                    break;
            }

        }

        public void ChangeRoot(UIType type)
        {
            switch (type)
            {
                case UIType.Touch:
                    gRoot = WTUIRoot.Instance.touchRoot;
                    break;
                case UIType.Normal:
                    gRoot = WTUIRoot.Instance.normalRoot;
                    break;
                case UIType.Fixed:
                    gRoot = WTUIRoot.Instance.fixedRoot;
                    break;
                case UIType.PopUp:
                    gRoot = WTUIRoot.Instance.popupRoot;
                    break;
                case UIType.Dialog:
                    gRoot = WTUIRoot.Instance.dialog;
                    break;
                case UIType.None:
                    break;
                default:
                    break;
            }
            if (window != null)
            {
                window.ShowOn(gRoot);
            }

        }

        public bool isActive()
        {
            //考虑如果不是一个gameobject的情况
            bool ret = window != null && window.isShowing;
            return ret || isActived;
        }

        #endregion

        #region 静态方法

        private static bool CheckIfNeedBack(WTUIPage page)
        {
            return page != null && page.CheckIfNeedBack();
        }

        /// <summary>
        ///  
        /// 将目标弹到顶层
        /// </summary>
        private static void PopNode(WTUIPage page)
        {
            if (m_currentPageNodes == null)
            {
                m_currentPageNodes = new List<WTUIPage>();
            }

            if (page == null)
            {
                Debug.LogError("[UI] page popup is null.");
                return;
            }

            //子页面不需要调用.
            if (CheckIfNeedBack(page) == false)
            {
                return;
            }

            bool _isFound = false;
            for (int i = 0; i < m_currentPageNodes.Count; i++)
            {
                if (m_currentPageNodes[i].Equals(page))
                {
                    m_currentPageNodes.RemoveAt(i);
                    m_currentPageNodes.Add(page);
                    _isFound = true;
                    break;
                }
            }

            if (!_isFound)
            {
                m_currentPageNodes.Add(page);
            }

            //弹出新界面的时候隐藏其他界面
            HideOldNodes();
        }

        /// <summary>
        /// 隐藏其他可隐藏的界面
        /// </summary>
        private static void HideOldNodes()
        {
            if (m_currentPageNodes.Count < 0) return;
            WTUIPage topPage = m_currentPageNodes[m_currentPageNodes.Count - 1];
            if (topPage.mode == UIMode.HideOther)
            {

                for (int i = m_currentPageNodes.Count - 2; i >= 0; i--)
                {
                    if (m_currentPageNodes[i].isActive())
                        m_currentPageNodes[i].Hide();
                }
            }
        }

        public static void ClearNodes()
        {
            if (m_currentPageNodes != null)
                m_currentPageNodes.Clear();

            if (allPages != null)
                allPages.Clear();
        }

        public static void CloseAll()
        {
            if (m_allPages != null)
            {
                //Debug.Log("CloseAll");
               
                foreach (var item in m_allPages.Values)
                {
                    item.Hide();
                }

                //Debug.Log("CloseAll over");
            }
        }


        private static WTUIPage ShowPage<T>(string name, Action callback, object pageData, bool isAsync) where T : WTUIPage, new()
        {
            string pageName = typeof(T).Name;

            if (!string.IsNullOrEmpty(pageName))
            {
                if (!string.IsNullOrEmpty(name))//已经包含这个ui名
                {
                    if (!name.Contains(pageName))
                    {
                        pageName = pageName + name;
                    }
                    else
                    {
                        pageName = name;
                    }
                }
            }

            if (allPages != null && allPages.ContainsKey(pageName))
            {
                return ShowPage(pageName, allPages[pageName], callback, pageData, isAsync);
            }
            else
            {
                T instance = new T();

                instance.name = pageName;
                return ShowPage(pageName, instance, callback, pageData, isAsync);
            }
        }

        private static WTUIPage ShowOnTransform<T>(string name, Action callback, object pageData, bool isAsync, Transform node, int layer) where T : WTUIPage, new()
        {
            string pageName = typeof(T).Name;
            if (!string.IsNullOrEmpty(pageName))
            {
                pageName = pageName + name;
            }

            if (allPages != null && allPages.ContainsKey(pageName))
            {
                return ShowPageByUIPanel(pageName, allPages[pageName], callback, pageData, isAsync, node, layer);
            }
            else
            {
                T instance = new T();
                instance.name = pageName;
                return ShowPageByUIPanel(pageName, instance, callback, pageData, isAsync, node, layer);
            }
        }

        private static WTUIPage ShowPage(string pageName, WTUIPage pageInstance, Action callback, object pageData, bool isAsync)
        {
            if (string.IsNullOrEmpty(pageName) || pageInstance == null)
            {
                Debug.LogError("[UI] 显示页面错误，with :" + pageName + " 可能没有instance.");
                return null;
            }
 

            WTUIPage page = null;
            if (allPages.ContainsKey(pageName))
            {
                page = allPages[pageName];
            }
            else
            {
                allPages.Add(pageName, pageInstance);
                page = pageInstance;
            }

            //if (page.isActive() == false)
            {

                page.m_data = pageData;

                if (isAsync)
                    page.Show(callback);
                else
                    page.ShowWindow();
            }

            return pageInstance;
        }

        private static WTUIPage ShowPageByUIPanel(string pageName, WTUIPage pageInstance, Action callback, object pageData, bool isAsync, Transform node, int layer)
        {
            if (string.IsNullOrEmpty(pageName) || pageInstance == null)
            {
                Debug.LogError("[UI] 显示页面错误，with :" + pageName + " 可能没有instance.");
                return null;
            }

        

            WTUIPage page = null;
            if (allPages.ContainsKey(pageName))
            {
                page = allPages[pageName];
            }
            else
            {
                allPages.Add(pageName, pageInstance);
                page = pageInstance;
            }

            //if (page.isActive() == false)
            {
                page.m_data = pageData;

                if (isAsync)
                {
                    //page.ShowUIPanel(callback,node,layer);
                    throw new Exception("异步显示UI未处理");
                }
                else
                {
                    page.ShowOnTransform(node, layer);
                }
            }
            return pageInstance;
        }

        /// <summary>
        /// 同步显示
        /// </summary>
        public static T ShowPage<T>() where T : WTUIPage, new()
        {
            return ShowPage<T>(null) as T;
        }

        public static T ShowPage<T>(object data) where T : WTUIPage, new()
        {
            return ShowPage<T>(null, null, data, false) as T;
        }

        public static T ShowPage<T>(string name) where T : WTUIPage, new()
        {
            return ShowPage<T>(name, null, null, false) as T;
        }

        public static void ShowByUIClassName(string clazzName)
        {
            Type type = Type.GetType(clazzName);
            object uiObject = Activator.CreateInstance(type);
            MethodInfo show = type.GetMethod("ShowSelf");
            show.Invoke(uiObject, null);
        }

        /// <summary>
        /// 显示一个UI到世界屏幕
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="layer">UI层级，默认已经加上1000，显示在UI层之前</param>
        /// <returns></returns>
        public static T ShowOnTransform<T>(Transform node, int layer) where T : WTUIPage, new()
        {
            return ShowOnTransform<T>(null, node, 1000 + layer) as T;
        }

        public static T ShowOnTransform<T>(Transform node) where T : WTUIPage, new()
        {
            return ShowOnTransform<T>(null, node, 1000) as T;
        }

        public static T ShowOnTransform<T>(string pageName, Transform node, int layer) where T : WTUIPage, new()
        {
            WTUIPage ui = ShowOnTransform<T>(pageName, null, null, false, node, 1000 + layer);
            return ui as T;
        }

        private static void ShowPage(string pageName, WTUIPage pageInstance)
        {
            ShowPage(pageName, pageInstance, null, null, false);
        }

        private static void ShowPage(string pageName, WTUIPage pageInstance, object pageData)
        {
            ShowPage(pageName, pageInstance, null, pageData, false);
        }

        /// <summary>
        /// 异步显示制定界面
        /// </summary>
        public static void ShowPage(string pageName, WTUIPage pageInstance, Action callback)
        {
            ShowPage(pageName, pageInstance, callback, null, true);
        }

        /// <summary>
        /// 关闭顶层界面
        /// </summary>
        public static void ClosePage()
        {
            //Debug.Log("Back&Close PageNodes Count:" + m_currentPageNodes.Count);
            //修改
            if (m_currentPageNodes == null || m_currentPageNodes.Count <= 0) return;

            WTUIPage closePage = m_currentPageNodes[m_currentPageNodes.Count - 1];
            m_currentPageNodes.RemoveAt(m_currentPageNodes.Count - 1);//从list中移除目前最后一个界面


            if (m_currentPageNodes.Count > 0)//还有其他界面
            {
                WTUIPage page = m_currentPageNodes[m_currentPageNodes.Count - 1];//移除过后最后一个界面
                if (page.isAsyncUI)
                    ShowPage(page.name, page, () =>
                    {
                        closePage.Hide();
                    });
                else
                {
                    ShowPage(page.name, page);
                    closePage.Hide();
                }
            }
        }

        /// <summary>
        /// 关闭目标界面
        /// </summary>
        public static void ClosePage(WTUIPage target)
        {
            if (target == null) return;
            if (target.isActive() == false)
            {
                if (m_currentPageNodes != null)
                {
                    for (int i = 0; i < m_currentPageNodes.Count; i++)
                    {
                        if (m_currentPageNodes[i] == target)
                        {
                            m_currentPageNodes.RemoveAt(i);
                            break;
                        }
                    }
                    return;
                }
            }

            if (m_currentPageNodes != null && m_currentPageNodes.Count >= 1 && m_currentPageNodes[m_currentPageNodes.Count - 1] == target)
            {
                m_currentPageNodes.RemoveAt(m_currentPageNodes.Count - 1);

                if (m_currentPageNodes.Count > 0)
                {
                    WTUIPage page = m_currentPageNodes[m_currentPageNodes.Count - 1];
                    if (page.isAsyncUI)
                        ShowPage(page.name, page, () =>
                        {
                            target.Hide();
                        });
                    else
                    {
                        //ShowPage(page.name, page);
                        //target.Hide();
                        target.getGComponent().Dispose();
                    }

                    return;
                }
            }
            else if (target.CheckIfNeedBack())
            {
                for (int i = 0; i < m_currentPageNodes.Count; i++)
                {
                    if (m_currentPageNodes[i] == target)
                    {
                        m_currentPageNodes.RemoveAt(i);
                        target.Hide();
                        break;
                    }
                }
            }

            allPages.Remove(target.name);
            target.window.Dispose();
            //target.Hide();
        }

        #endregion


    }
}