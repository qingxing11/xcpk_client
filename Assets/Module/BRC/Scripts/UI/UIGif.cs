using Room;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIGif : WTUIPage<UI_Gif, GifCtrl>
{
    public UIGif() : base(UIType.PopUp, UIMode.DoNothing, R.UI.ROOM)
    {
    }
    /// <summary>
    /// 通杀场动画播放
    /// </summary>
    public void PlayGifAnim(int startPos, int endPos, int emojiId)
    {
        UIPage.m_c1.SetSelectedIndex(0);
        Vector2 startVect = Vector2.zero;
        Vector2 endVect = Vector2.zero;
        switch (startPos)
        {
            case 0:
                startVect = UIPage.m_pos0.position;
                break;
            case 1:
                startVect = UIPage.m_pos1.position;
                break;
            case 2:
                startVect = UIPage.m_pos2.position;
                break;
            case 3:
                startVect = UIPage.m_pos3.position;
                break;
            case 4:
                startVect = UIPage.m_pos4.position;
                break;
            case 5:
                startVect = UIPage.m_pos5.position;
                break;
            case 6:
                startVect = UIPage.m_pos6.position;
                break;
            case 7:
                startVect = UIPage.m_pos7.position;
                break;
            case 8:
                startVect = UIPage.m_pos8.position;
                break;
            case 9:
                startVect = UIPage.m_pos9.position;
                break;
            default:
                break;
        }
        switch (endPos)
        {
            case 0:
                endVect = UIPage.m_pos0.position;
                break;
            case 1:
                endVect = UIPage.m_pos1.position;
                break;
            case 2:
                endVect = UIPage.m_pos2.position;
                break;
            case 3:
                endVect = UIPage.m_pos3.position;
                break;
            case 4:
                endVect = UIPage.m_pos4.position;
                break;
            case 5:
                endVect = UIPage.m_pos5.position;
                break;
            case 6:
                endVect = UIPage.m_pos6.position;
                break;
            case 7:
                endVect = UIPage.m_pos7.position;
                break;
            case 8:
                endVect = UIPage.m_pos8.position;
                break;
            default:
                break;
        }
        switch (emojiId)
        {
            case 0:
                UIPage.m_flowerGif.visible = true;
                UIPage.m_flowerGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_flowerGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_flowerGif.playing = true;
                    UIPage.m_flowerGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_flowerGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_flowerGif.visible = false;
                    });
                });
                break;
            case 1:
                UIPage.m_cheersGif.visible = true;
                UIPage.m_cheersGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_cheersGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_cheersGif.playing = true;
                    UIPage.m_cheersGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_cheersGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_cheersGif.visible = false;
                    });
                });
                break;
            case 2:
                UIPage.m_kissGif.visible = true;
                UIPage.m_kissGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_kissGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_kissGif.playing = true;
                    UIPage.m_kissGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_kissGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_kissGif.visible = false;
                    });
                });
                break;
            case 3:
                UIPage.m_eggGif.visible = true;
                UIPage.m_eggGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_eggGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_eggGif.playing = true;
                    UIPage.m_eggGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_eggGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_eggGif.visible = false;
                    });
                });
                break;
            case 4:
                UIPage.m_shoeGif.visible = true;
                UIPage.m_shoeGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_shoeGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_shoeGif.playing = true;
                    UIPage.m_shoeGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_shoeGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_shoeGif.visible = false;
                    });
                });
                break;
            case 5:
                UIPage.m_bombGif.visible = true;
                UIPage.m_bombGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_bombGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_bombGif.playing = true;
                    UIPage.m_bombGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_bombGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_bombGif.visible = false;
                    });
                });
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 经典场表情动画播放
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <param name="emojiId"></param>
    public void PlayGifAnimClassic(int startPos, int endPos, int emojiId)
    {
        UIPage.m_c1.SetSelectedIndex(1);
        Vector2 startVect = Vector2.zero;
        Vector2 endVect = Vector2.zero;
        switch (startPos)
        {
            case 0:
                startVect = UIPage.m_pos0.position;
                break;
            case 1:
                startVect = UIPage.m_pos1.position;
                break;
            case 2:
                startVect = UIPage.m_pos2.position;
                break;
            case 3:
                startVect = UIPage.m_pos3.position;
                break;
            case 4:
                startVect = UIPage.m_pos4.position;
                break;
            default: break;
        }
        switch (endPos)
        {
            case 0:
                endVect = UIPage.m_pos0.position;
                break;
            case 1:
                endVect = UIPage.m_pos1.position;
                break;
            case 2:
                endVect = UIPage.m_pos2.position;
                break;
            case 3:
                endVect = UIPage.m_pos3.position;
                break;
            case 4:
                endVect = UIPage.m_pos4.position;
                break;
            default: break;
        }
        switch (emojiId)
        {
            case 0:
                UIPage.m_flowerGif.visible = true;
                UIPage.m_flowerGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_flowerGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_flowerGif.playing = true;
                    UIPage.m_flowerGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_flowerGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_flowerGif.visible = false;
                    });
                });
                break;
            case 1:
                UIPage.m_cheersGif.visible = true;
                UIPage.m_cheersGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_cheersGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_cheersGif.playing = true;
                    UIPage.m_cheersGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_cheersGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_cheersGif.visible = false;
                    });
                });
                break;
            case 2:
                UIPage.m_kissGif.visible = true;
                UIPage.m_kissGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_kissGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_kissGif.playing = true;
                    UIPage.m_kissGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_kissGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_kissGif.visible = false;
                    });
                });
                break;
            case 3:
                UIPage.m_eggGif.visible = true;
                UIPage.m_eggGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_eggGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_eggGif.playing = true;
                    UIPage.m_eggGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_eggGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_eggGif.visible = false;
                    });
                });
                break;
            case 4:
                UIPage.m_shoeGif.visible = true;
                UIPage.m_shoeGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_shoeGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_shoeGif.playing = true;
                    UIPage.m_shoeGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_shoeGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_shoeGif.visible = false;
                    });
                });
                break;
            case 5:
                UIPage.m_bombGif.visible = true;
                UIPage.m_bombGif.SetPosition(startVect.x, startVect.y, 0);
                UIPage.m_bombGif.TweenMove(endVect, 1f).OnComplete(() =>
                {
                    UIPage.m_bombGif.playing = true;
                    UIPage.m_bombGif.SetPlaySettings(0, -1, 1, 0);
                    UIPage.m_bombGif.onPlayEnd.Add(() =>
                    {
                        UIPage.m_bombGif.visible = false;
                    });
                });
                break;
            default:
                break;
        }
    }
}