using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenThousandField;
using WT.UI;
using UnityEngine;
using FairyGUI;
using DG.Tweening;
using Config;
public class UIYaZhu : WTUIPage<UI_yaZhu, TenThousandRoomCtrl>
{
    public UIYaZhu() : base(UIType.Normal, UIMode.DoNothing, R.UI.TENTHOUSANDFIELD)
    {
    }

    public override void Awake()
    {

    }


    public void SetYaZhuValue(int yaZhuValue)
    {
        Debug.Log("yaZhuValue ;"+ yaZhuValue);
        string path = EnumChouMaType.GetTitle(yaZhuValue);
        UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(path));
    }


    GTweener Tween;
    public void MoveTo(Vector3 startPos, Vector3 endPos)
    {
        UIPage.position = startPos;
        Tween = UIPage.TweenMove(endPos, 0.5f).OnComplete(() =>
        {
            Tween.Kill();
        });
    }


    public void MoveToHide(Vector3 endPos)
    {
        Tween = UIPage.TweenMove(endPos, 1f).OnComplete(() =>
        {
            Tween.Kill();
            Hide();
        });
    }

    public void SetShowIndex(int  index)
    {
        if (isActive())
        {
            UIPage.m_big.selectedIndex = index;
        }
    }
}