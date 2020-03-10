/**
* 命名空间: Assets.Editor
* 功 能： N/A
* 类 名： AutoFindComponenttClass1
* 作用：
* Ver 变更日期 负责人 刘辉 变更内容
* V0.01 2018/3/21 16:09:28 
* Copyright (c) 2017 NanJingDianYing.
*/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class AutoFindComponent
{
    private const string TRAN = "Transform";

    private const string OBJ = "GameObject";

    private const string BTN = "Button";

    private const string TEXT = "Text";

    private const string IMAGE = "Image";

   

    private static string[] components = new string[]
    {
        TRAN,  //Transform
        OBJ,   // GameObject
        BTN,   //Button
        TEXT,   // Text
        IMAGE,   //Image  
     
        //如有需要可继续添加
    };


    private static Transform targetTran;

    private static string scriptName;

    public static string scriptURL = Application.dataPath + "/Gen/PartScript/";

    private static Dictionary<string, string> mTranDict = new Dictionary<string, string>();
    private static Dictionary<string, string> mObjDict = new Dictionary<string, string>();
    private static Dictionary<string, string> mBtnDict = new Dictionary<string, string>();
    private static Dictionary<string, string> mTextDict = new Dictionary<string, string>();
    private static Dictionary<string, string> mImageDict = new Dictionary<string, string>();

    static StringBuilder sbConst;

    static int mIndex;

    //[MenuItem("WT/AssetBunlde资源管理/自动生成预制体中定义的组件")]
    [MenuItem("Assets/自动生成预制体中定义的组件")]
    static void AutoFindComponents()
    {
        //AutoFindComponent changeFormat = EditorWindow.GetWindow(typeof(AutoFindComponent)) as AutoFindComponent;
        FindComponents();
    }

    static void FindComponents()
    {

        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        if (SelectedAsset.Length <= 0)
        {
            Debug.Log("请至少选择一个UI预制体！");
            return;
        }

        for (int i = 0; i < SelectedAsset.Length; i++)
        {
            GameObject target = (GameObject)SelectedAsset[i];

            targetTran = target.transform;

            scriptName = target.name;

            GetComponents(targetTran);

            writeComponents(scriptName);

            mClearDict();
        }
    }

    static void writeComponents(string scriptName)
    {

        //string paritUrl = scriptURL + scriptName;

        StringBuilder sbi = new StringBuilder();

        sbi.Append(@"

"
        );

        sbi = mGetStrBuilder(sbi);

        FileIO.WriteAllAbName(scriptURL, "Part" + scriptName + ".cs", sbi.ToString());

        sbi.Append("");

        AssetDatabase.Refresh();

    }

    static StringBuilder mGetStrBuilder(StringBuilder sb)
    {
        sb.Append(@"
/// <summary>
/// 自动生成代码,请勿编辑
/// </summary>" + "\n" + @"
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using WT.UI;
using System;" + "\n" +

"partial class " + scriptName + @"
{"
            );
        mGetAttribute(sb);

        mGetMethod(sb);

        sb.Append(@"
}");
        return sb;
    }

    /// <summary>
    /// 得到属性条目
    /// </summary>
    /// <param name="sb"></param>
    /// <returns></returns>
    static StringBuilder mGetAttribute(StringBuilder sb)
    {

        StringBuilder temp = new StringBuilder();
        mIndex = 0;
        sbConst = new StringBuilder();
        foreach (string sti in mTranDict.Keys)
        {
            temp.Append("m_"+sti.ToLower() + ",");
        }
        if (!string.IsNullOrEmpty(temp.ExtendStr(";")))
        {
            sb.Append(@"
    private Transform  " + temp.ExtendStr(";") + "\n");

        }

        temp = new StringBuilder();
        foreach (string sti in mObjDict.Keys)
        {
            temp.Append("m_" + sti.ToLower() + ",");
        }
        if (!string.IsNullOrEmpty(temp.ExtendStr(";")))
        {
            sb.Append(@"
    private GameObject  " + temp.ExtendStr(";") + "\n");
        }

        temp = new StringBuilder();
        foreach (string sti in mBtnDict.Keys)
        {
            temp.Append("m_" + sti.ToLower() + ",");
            sbConst.Append(@"
    private const int " + sti.ToUpper() + " = " + mIndex + " ;\n");
            mIndex++;
        }
        if (!string.IsNullOrEmpty(temp.ExtendStr(";")))
        {
            sb.Append(@"
    private Button  " + temp.ExtendStr(";") + "\n");
        }

        temp = new StringBuilder();
        foreach (string sti in mTextDict.Keys)
        {
            temp.Append("m_" + sti.ToLower() + ",");
        }
        if (!string.IsNullOrEmpty(temp.ExtendStr(";")))
        {
            sb.Append(@"
    private Text  " + temp.ExtendStr(";") + "\n");
        }

        temp = new StringBuilder();
        foreach (string sti in mImageDict.Keys)
        {
            temp.Append("m_" + sti.ToLower() + ",");
        }
        if (!string.IsNullOrEmpty(temp.ExtendStr(";")))
        {
            sb.Append(@"
    private Image  " + temp.ExtendStr(";") + "\n");
        }

        sb.Append(@" 
    private Action<int> disptchEvent ;" + "\n");

        sb.Append(sbConst.ToString());

        return sb;

    }

    static string mGetType(string key)
    {
        string sti = "";

        for (int i = 0; i < components.Length; i++)
        {
            if (components[i].Contains(key))
            {
                return components[i];
            }
        }
        return sti;
    }
    static bool isContains(string name)
    {
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i].Contains(name))
            {
                return true;
            }
        }
        return false;
    }
    static void GetComponents(Transform tran)
    {
        foreach (Transform tr in tran)
        {
            string[] strs = tr.name.Split('_'); //TRAN_xxxx
            if (strs.Length > 1)
            {
                string endName = strs[0];

                if (isContains(endName))
                {
                    string url = getTranUrl(tr);
                    if (!string.IsNullOrEmpty(url))
                    {
                        switch (mGetType(endName))
                        {
                            case TRAN:
                                if (!mTranDict.AddValue(tr.name, url))
                                {
                                    Logs(tr.name, url);
                                }
                                break;
                            case OBJ:
                                if (!mObjDict.AddValue(tr.name, url))
                                {
                                    Logs(tr.name, url);
                                }
                                break;
                            case BTN:
                                if (!mBtnDict.AddValue(tr.name, url))
                                {
                                    Logs(tr.name, url);
                                }
                                break;
                            case TEXT:
                                if (!mTextDict.AddValue(tr.name, url))
                                {
                                    Logs(tr.name, url);
                                }
                                break;
                            case IMAGE:
                                if (!mImageDict.AddValue(tr.name, url))
                                {
                                    Logs(tr.name, url);
                                }
                                break;

                            
                        }
                    }
                }
            }
             
            GetComponents(tr);
        }
    }
    static string getTranUrl(Transform tran)
    {
        string url = "/" + tran.name;
        while (tran.parent != null)
        {
            tran = tran.parent;

            url = targetTran == tran ? "" + url : "/" + tran.name + url;
        }
        url = url.Remove(0, 1);
        return url;
    }
    static void mClearDict()
    {
        mTranDict.Clear();
        mObjDict.Clear();
        mTextDict.Clear();
        mImageDict.Clear();
        mBtnDict.Clear();
    }
    /// <summary>
    /// 得到方法条目
    /// </summary>
    /// <param name="sb"></param>
    /// <returns></returns>
    static StringBuilder mGetMethod(StringBuilder sb)
    {
        StringBuilder tempSb = new StringBuilder();
        mIndex = 0;
        sb.Append(@"
    public override void Awake(GameObject go)
    {
");

        foreach (KeyValuePair<string, string> item in mTranDict)
        {
            sb.Append("        " + "m_"+item.Key.ToLower() + " = FindComponent<Transform>(" + "\"" + item.Value + "\"" + ");\n\n");
        }
        foreach (KeyValuePair<string, string> item in mObjDict)
        {
            sb.Append("        " + "m_"+item.Key.ToLower() + " = FindComponent<GameObject>(" + "\"" + item.Value + "\"" + ").gameObject;\n\n");
        }
        foreach (KeyValuePair<string, string> item in mBtnDict)
        {
            sb.Append("        " + "m_" + item.Key.ToLower() + " = FindComponent<Button>(" + "\"" + item.Value + "\"" + ");\n\n");
            sb.Append("        " + "m_" + item.Key.ToLower() + ".onClick.AddListener(" + item.Key.ToLower() + "click" + ");\n\n");
            tempSb.Append(@"
    private void " +  item.Key.ToLower() + "click" + "()" + @"
    {" + @"
        ClickButtonEvent(" + mIndex + ");" + @"      
    }");
            mIndex++;
        }
        foreach (KeyValuePair<string, string> item in mTextDict)
        {
            sb.Append("        " + "m_" + item.Key.ToLower() + " = FindComponent<Text>(" + "\"" + item.Value + "\"" + ");\n\n");
        }
        foreach (KeyValuePair<string, string> item in mImageDict)
        {
            sb.Append("        " + "m_" + item.Key.ToLower() + " = FindComponent<Image>(" + "\"" + item.Value + "\"" + ");\n\n");
        }


        sb.Append(@"
    }");

        //do something
        sb.Append(tempSb.ToString());

        sb.Append(@"
    private void ClickButtonEvent(int index)
    {
       if(disptchEvent!=null)
       {
            disptchEvent(index);  
       }       
    }    
    private void AddButtonEvent(Action<int> method)
    {
       this.disptchEvent = method;
    }
");

        return sb;
    }
    static void Logs(string name, string url)
    {
        Debug.LogError("控件名称:" + name + "  路径:" + url + "  已经存在请重新命名控件名称！");
    }
}
