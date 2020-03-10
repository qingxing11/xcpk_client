using FairyGUI;
using System.Collections.Generic;
using Classic;
using UnityEngine;
using WT.UI;
using System.Collections;

/// <summary>
/// 万人场比牌
/// </summary>
public  class UIComparePoker : WTUIPage<UI_ComparerPoker, TenThousandRoomCtrl>
{
    public UIComparePoker() : base(UIType.PopUp, UIMode.DoNothing, R.UI.TENTHOUSANDFIELD)
    {      
        
    }


    private List<GLoader> cardS;

    public override void Awake()
    {
        cardS = new List<GLoader>();

        cardS.Add(UIPage.m_card_back1);
        cardS.Add(UIPage.m_card_back2);
        cardS.Add(UIPage.m_card_back3);
        cardS.Add(UIPage.m_card_back4);
        cardS.Add(UIPage.m_card_back5);
        cardS.Add(UIPage.m_card_back6);
    }

    internal IEnumerator Init(int pos0, int pos1, int lossPos, bool isLook = false, List<PokerVO> pokerVOs = null, int selfPos = 0)
    {
        UIPage.m_n43.visible = true;
        PlayerSimpleData playerSimpleData0 = CacheManager.ManyPeopleRoomPlayers[pos0];
        PlayerSimpleData playerSimpleData1 = CacheManager.ManyPeopleRoomPlayers[pos1];

        UIPage.m_text_nickName0.text = playerSimpleData0.nickName;
        UIPage.m_text_nickName1.text = playerSimpleData1.nickName;   

        UIPage.m_head0.texture = new NTexture(playerSimpleData0.headIcon);
        UIPage.m_head1.texture = new NTexture(playerSimpleData1.headIcon);
        UIPage.m_boom.visible = true;


        Vector3 vec0 = Vector3.zero;
        Vector3 vec1 = Vector3.zero;
        Vector3 vec2 = Vector3.zero;
        Vector3 vec3 = Vector3.zero;
        Vector3 vec4 = Vector3.zero;
        Vector3 vec5 = Vector3.zero;

        switch (pos0)
        {
            case 0:     //362,268
                vec0 = new Vector3(332, 268, 0);
                vec1 = new Vector3(382, 268, 0);
                vec2 = new Vector3(432, 268, 0);
                break;
            case 1:
                vec0 = new Vector3(559, 281, 0);
                vec1 = new Vector3(579, 281, 0);
                vec2 = new Vector3(619, 281, 0);
                break;
            case 2:
                vec0 = new Vector3(559, 130, 0);
                vec1 = new Vector3(579, 130, 0);
                vec2 = new Vector3(619, 130, 0);
                break;
            case 3:
                vec0 = new Vector3(154, 130, 0);
                vec1 = new Vector3(174, 130, 0);
                vec2 = new Vector3(194, 130, 0);
                break;
            case 4:
                vec0 = new Vector3(154, 281, 0);
                vec1 = new Vector3(174, 281, 0);
                vec2 = new Vector3(194, 281, 0);
                break;
            default:
                break;
        }

        switch (pos1)
        {
            case 0:
                vec3 = new Vector3(332, 268, 0);
                vec4 = new Vector3(387, 268, 0);
                vec5 = new Vector3(442, 268, 0);
                break;
            case 1:
                vec3 = new Vector3(559, 281, 0);
                vec4 = new Vector3(584, 281, 0);
                vec5 = new Vector3(609, 281, 0);
                break;
            case 2:
                vec3 = new Vector3(559, 130, 0);
                vec4 = new Vector3(584, 130, 0);
                vec5 = new Vector3(609, 130, 0);
                break;
            case 3:
                vec3 = new Vector3(154, 130, 0);
                vec4 = new Vector3(179, 130, 0);
                vec5 = new Vector3(204, 130, 0);
                break;
            case 4:
                vec3 = new Vector3(154, 281, 0);
                vec4 = new Vector3(179, 281, 0);
                vec5 = new Vector3(204, 281, 0);
                break;
            default:
                break;
        }
        cardS[0].scale = Vector2.one;
        cardS[1].scale = Vector2.one;
        cardS[2].scale = Vector2.one;
        cardS[3].scale = Vector2.one;
        cardS[4].scale = Vector2.one;
        cardS[5].scale = Vector2.one;
        cardS[0].texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        cardS[1].texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        cardS[2].texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        cardS[3].texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        cardS[4].texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        cardS[5].texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        cardS[0].SetPosition(vec0.x, vec0.y, vec0.z);
        cardS[0].visible = true;
        cardS[1].SetPosition(vec1.x, vec1.y, vec1.z);
        cardS[1].visible = true;
        cardS[2].SetPosition(vec2.x, vec2.y, vec2.z);
        cardS[2].visible = true;
        cardS[3].SetPosition(vec3.x, vec3.y, vec3.z);
        cardS[3].visible = true;
        cardS[4].SetPosition(vec4.x, vec4.y, vec4.z);
        cardS[4].visible = true;
        cardS[5].SetPosition(vec5.x, vec5.y, vec5.z);
        cardS[5].visible = true;


        if (isLook)
        {
            if (selfPos == pos0)
            {
                if (pokerVOs != null)
                {
                    if (pokerVOs[0] != null)
                    {
                        cardS[0].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[0].value));
                        cardS[0].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[0].texture = new NTexture(Pokers.GetPokerFace(0));
                            cardS[0].TweenScaleX(1, 0.4f);
                        });
                    }
                    if (pokerVOs[1] != null)
                    {
                        cardS[1].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[1].value));
                        cardS[1].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[1].texture = new NTexture(Pokers.GetPokerFace(0));
                            cardS[1].TweenScaleX(1, 0.4f);
                        });
                    }
                    if (pokerVOs[2] != null)
                    {
                        cardS[2].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[2].value));
                        cardS[2].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[2].texture = new NTexture(Pokers.GetPokerFace(0));
                            cardS[2].TweenScaleX(1, 0.4f);
                        });
                    }
                }
            }
            else if (selfPos == pos1)
            {
                if (pokerVOs != null)
                {
                    if (pokerVOs[0] != null)
                    {
                        cardS[3].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[0].value));
                        cardS[3].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[3].texture = new NTexture(Pokers.GetPokerFace(0));
                            cardS[3].TweenScaleX(1, 0.4f);
                        });
                    }
                    if (pokerVOs[1] != null)
                    {
                        cardS[4].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[1].value));
                        cardS[4].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[4].texture = new NTexture(Pokers.GetPokerFace(0));
                            cardS[4].TweenScaleX(1, 0.4f);
                        });
                    }
                    if (pokerVOs[2] != null)
                    {
                        cardS[5].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[2].value));
                        cardS[5].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[5].texture = new NTexture(Pokers.GetPokerFace(0));
                            cardS[5].TweenScaleX(1, 0.4f);
                        });
                    }
                }
            }
        }


        cardS[0].TweenMove(new Vector2(266, 210), 1f);
        cardS[1].TweenMove(new Vector2(291, 210), 1f);
        cardS[2].TweenMove(new Vector2(316, 210), 1f);
        cardS[3].TweenMove(new Vector2(437, 210), 1f);
        cardS[4].TweenMove(new Vector2(462, 210), 1f);
        cardS[5].TweenMove(new Vector2(482, 210), 1f);

        yield return new WaitForSeconds(1f);
        BaseCanvas.PlaySound(R.AudioClip.CLASSIC_SHANDIAN);
        UIPage.m_anim.visible = true;
        if (pos0 == lossPos)
        {
            UIPage.m_boom.SetPosition(259, 190, 0);
        }
        else
        {
            UIPage.m_boom.SetPosition(424, 190, 0);
        }
        yield return new WaitForSeconds(1.0f);
        UIPage.m_t_boom.Play();      //播放炸弹
        BaseCanvas.PlaySound(R.AudioClip.CLASSIC_BOOM);


        yield return new WaitForSeconds(0.5f);

        if (pos0 == lossPos)
        {
            if (pos0 == 0)
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_BIPAILOSER);
            else if (pos1 == 0)
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_BIPAIWIN);
        }
        else
        {
            if (pos0 == 0)
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_BIPAIWIN);
            else if (pos1 == 0)
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_BIPAILOSER);
        }


        UIPage.m_n43.visible = false;
        cardS[0].TweenMove(vec0, 2f).OnComplete(() => { cardS[0].visible = false; });
        cardS[1].TweenMove(vec1, 2f).OnComplete(() => { cardS[1].visible = false; });
        cardS[2].TweenMove(vec2, 2f).OnComplete(() => { cardS[2].visible = false; });
        cardS[3].TweenMove(vec3, 2f).OnComplete(() => { cardS[3].visible = false; });
        cardS[4].TweenMove(vec4, 2f).OnComplete(() => { cardS[4].visible = false; });
        cardS[5].TweenMove(vec5, 2f).OnComplete(() => { cardS[5].visible = false; });

        if (isLook)
        {
            if (selfPos == pos0)
            {
                if (pokerVOs != null)
                {
                    if (pokerVOs[0] != null)
                    {
                        cardS[0].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[0].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[0].value));
                            cardS[0].TweenScaleX(1, 0.4f);
                        });
                    }
                    if (pokerVOs[1] != null)
                    {
                        cardS[1].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[1].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[1].value));
                            cardS[1].TweenScaleX(1, 0.4f);
                        });
                    }
                    if (pokerVOs[2] != null)
                    {
                        cardS[2].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[2].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[2].value));
                            cardS[2].TweenScaleX(1, 0.4f);
                        });
                    }
                }
            }
            else if (selfPos == pos1)
            {
                if (pokerVOs != null)
                {
                    if (pokerVOs[0] != null)
                    {
                        cardS[3].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[3].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[0].value));
                            cardS[3].TweenScaleX(1, 0.4f);
                        });
                    }
                    if (pokerVOs[1] != null)
                    {
                        cardS[4].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[4].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[1].value));
                            cardS[4].TweenScaleX(1, 0.4f);
                        });
                    }
                    if (pokerVOs[2] != null)
                    {
                        cardS[5].TweenScaleX(0, 0.4f).OnComplete(() =>
                        {
                            cardS[5].texture = new NTexture(Pokers.GetPokerFace(pokerVOs[2].value));
                            cardS[5].TweenScaleX(1, 0.4f);
                        });
                    }
                }
            }
        }
        yield return new WaitForSeconds(4f);
        base.Hide();
        UIPage.m_anim.visible = false;
        yield return null;
    }
}