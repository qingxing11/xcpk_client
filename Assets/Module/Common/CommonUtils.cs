//using Config;
using FairyGUI;
//using GameData;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace utils
{
    public class CommonUtils
    {
        /// <summary>
        /// 世界坐标转UI坐标
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 WorldToUIPoint(Vector3 point)
        {
            Vector3 v = Camera.main.WorldToScreenPoint(point);
            v.z = 0;
            v.y = Stage.inst.stageHeight - v.y;
            v = GRoot.inst.GlobalToLocal(v);
            return v;
        }

        public static ulong CreateUid()
        {
            System.Random r = new System.Random();
            int n1 = r.Next(0, int.MaxValue);
            int n2 = r.Next(0, int.MaxValue);
            return (UInt64)n1 * (UInt64)n2;
        }

        public static GameObject RaycastHitGameObject;
        public static Vector3 ScenePointToMap(Vector3 scenePoint, string layer)
        {
            RaycastHitGameObject = null;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(scenePoint.x, scenePoint.y, Math.Abs(Camera.main.transform.position.z)));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000, 1 << LayerMask.NameToLayer(layer))) //,
            {
                RaycastHitGameObject = hit.transform.gameObject;
                return hit.point;
            }
            return Vector3.zero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenePoint">屏幕坐标</param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static Vector2 ScenePointToMap2D(Vector3 scenePoint, string layer)
        {
            RaycastHitGameObject = null;

            var position = Camera.main.ScreenToWorldPoint(new Vector3(scenePoint.x, scenePoint.y, Math.Abs(Camera.main.transform.position.z)));

            RaycastHit2D hit = Physics2D.Raycast(position, Vector3.forward, 10000, 1 << LayerMask.NameToLayer(layer));
            if (hit.collider != null)
            {
                RaycastHitGameObject = hit.transform.gameObject;
                return hit.point;
            }
            return Vector2.zero;

        }

        public static GameObject SelectGameObject(Vector3 scenePoint, string layer)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(scenePoint.x, scenePoint.y, Math.Abs(Camera.main.transform.position.z)));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000, 1 << LayerMask.NameToLayer(layer))) //,LayerMask.GetMask("WorldMap")
            {
                return hit.transform.gameObject;
            }
            return null;
        }

        public static RaycastHit[] SelectGameObjects(Vector3 scenePoint, string layer)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(scenePoint.x, scenePoint.y, Math.Abs(Camera.main.transform.position.z)));
            return Physics.RaycastAll(ray, 10000, 1 << LayerMask.NameToLayer(layer));
        }



        public static GameObject SelectGameObject2D(Vector3 scenePoint, string layer)
        {
            var position = Camera.main.ScreenToWorldPoint(new Vector3(scenePoint.x, scenePoint.y, Math.Abs(Camera.main.transform.position.z)));

            RaycastHit2D hit = Physics2D.Raycast(position, Vector3.forward, 10000, 1<<LayerMask.NameToLayer(layer));//

            if (hit.collider != null)
            {
                return hit.transform.gameObject;
            }

            return null;
        }

        /// <summary>
        /// 自适应后高度缩放比例,
        /// </summary>
        public static float GetHScale()
        {
            return 16f / 9f * Stage.inst.stageHeight / Stage.inst.stageWidth;
        }
        /// <summary>
        /// 检测敏感词汇
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        //        private static DataFilterWord filterWords;
        //        public static string JudgyFilterWord(string text)
        //        {
        //            filterWords = new DataFilterWord();
        //            Dictionary<int, DataFilterWord> all = Globle.Instance.Configs.DataFilterWord;
        //            foreach (var dataLinese in all)
        //            {
        //                if (text.Contains(dataLinese.Value.filterWord))
        //                {
        //                    int lg = dataLinese.Value.filterWord.Length;
        //                    string sg = "";
        //                    for (int i = 0; i < lg; i++)
        //                    {
        //                        sg += "*";
        //                    }
        //                    text = text.Replace(dataLinese.Value.filterWord, sg);
        //                }
        //            }
        //            return text;
        //        }

        public static void ResetShader(UnityEngine.Object obj)
        {
            List<Material> listMat = new List<Material>();
            listMat.Clear();
            if (obj is Material)
            {
                Material m = obj as Material;
                listMat.Add(m);
            }
            else if (obj is GameObject)
            {
                GameObject go = obj as GameObject;
                Renderer[] rends = go.GetComponentsInChildren<Renderer>();
                if (null != rends)
                {
                    foreach (Renderer item in rends)
                    {
                        Material[] materialsArr = item.sharedMaterials;
                        foreach (Material m in materialsArr)
                            listMat.Add(m);
                    }
                }
            }

            for (int i = 0; i < listMat.Count; i++)
            {
                Material m = listMat[i];
                if (null == m)
                    continue;
                var shaderName = m.shader.name;
                var newShader = Shader.Find(shaderName);
                if (newShader != null)
                    m.shader = newShader;
            }
        }
    }

}
