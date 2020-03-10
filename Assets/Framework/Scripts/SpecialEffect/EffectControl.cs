using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 特效部分
/// </summary>
public class EffectControl : MonoBehaviour
{
    private int CurState = 0;
    private static EffectControl instance = null;
    public static EffectControl Instance
    {
        get
        {
            if (instance == null)
            {
                throw new Exception("特效图集未赋值!");
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /// <summary>
    /// 播放特效 
    /// </summary>
    /// <param name="MyTargetSp"></param>
    /// <param name="totalCount"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    IEnumerator PlayEffect(Image MyTargetSp, int totalCount, int[] spriteItem, int i)
    {
        int Count = 0;
        MyTargetSp.GetComponent<Image>().sprite = FileIO.LoadSprite(spriteItem[Count]);
        while (true)
        {
            yield return new WaitForSeconds(0.08f);
            Count++;
            if (Count > totalCount)
            {
                Count = 0;
                if (i == 0)
                {
                    MyTargetSp.gameObject.SetActive(false);
                    break;
                }
            }
            if (MyTargetSp != null)
                MyTargetSp.GetComponent<Image>().sprite = FileIO.LoadSprite(spriteItem[Count]);
        }
    }

    public void StartEffect(Image MyTargetSp, int totalCount, int[] spriteItem, int i)
    {
        StartCoroutine(PlayEffect(MyTargetSp, totalCount, spriteItem, i));
    }
    public void StopEffect()
    {
        StopAllCoroutines();
    }
    IEnumerator WaitForEffect(Image special, float time, int count, int[] sprite, Transform tran)
    {
        yield return new WaitForSeconds(time);
        special.gameObject.SetActive(true);
        special.transform.parent = tran;
        special.transform.localPosition = Vector3.zero;
        EffectControl.Instance.StartEffect(special, count, sprite, 0);
    }
    public void WaitTime(Image special, float time, int count, int[] sprite, Transform tran)
    {
        StartCoroutine(WaitForEffect(special, time, count, sprite, tran));
    }
}
