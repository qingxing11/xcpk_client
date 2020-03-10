using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// 音乐部分
/// WangTuo
/// </summary>
public class AudioControl : MonoBehaviour
{
    /// <summary>
    /// 最大同时音效数，根据音效索引计数
    /// </summary>
    private const int MaxAudioCount = 10;

    private static AudioControl instance = null;
    private Dictionary<int, int> AudioDictionary = new Dictionary<int, int>();

    /// <summary>
    /// 背景音乐源的引用
    /// </summary>
    private AudioSource BGMAudioSource;
    private AudioSource LastAudioSource;

    public static AudioControl Instance
    {
        get
        {
            if (instance == null)
            {
                throw new Exception("未添加声音组件,在canvas初始化时调用<AddAudioControl()>");
            }
            return instance;
        }
    }


    #region Mono Function  
    protected void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion


    #region 背景音乐  

    /// <summary>  
    /// 设置音量  
    /// </summary>  
    public void BGMSetVolume(float volume)
    {
        if (this.BGMAudioSource != null)
        {
            this.BGMAudioSource.volume = volume;
        }
    }

    /// <summary>  
    /// 播放背景音乐  
    /// </summary>  
    /// <param name="bgmname"></param>  
    /// <param name="volume"></param>  
    public void BGMPlay(int index, float volume = 1f)
    {
        BGMStop();

        AudioClip bgmsound = FileIO.LoadAudioClip(index);
        if (bgmsound != null)
        {
            this.PlayLoopBGMAudioClip(bgmsound, volume);
        }
    }

    /// <summary>  
    /// 暂停背景音乐  
    /// </summary>  
    public void BGMPause()
    {
        if (this.BGMAudioSource != null)
        {
            this.BGMAudioSource.Pause();
        }
    }

    /// <summary>  
    /// 停止背景音乐  
    /// </summary>  
    public void BGMStop()
    {
        if (this.BGMAudioSource != null && this.BGMAudioSource.gameObject)
        {
            Destroy(this.BGMAudioSource);
        }
    }

    /// <summary>  
    /// 重新播放  
    /// </summary>  
    public void BGMReplay()
    {
        if (this.BGMAudioSource != null)
        {
            this.BGMAudioSource.Play();
        }
    }

    public void BGMUnpause()
    {
        if (this.BGMAudioSource != null)
        {
            this.BGMAudioSource.UnPause();
        }
    }

    /// <summary>  
    /// 背景音乐控制器  
    /// </summary>  
    /// <param name="audioClip"></param>  
    /// <param name="volume"></param>  
    /// <param name="isloop"></param>  
    /// <param name="name"></param>  
    private void PlayBGMAudioClip(AudioClip audioClip, float volume = 1f, bool isloop = false, string name = null)
    {
        if (audioClip == null)
        {
            return;
        }
        else
        {
            AudioSource LoopClip = gameObject.AddComponent<AudioSource>();
            LoopClip.clip = audioClip;
            LoopClip.volume = volume;
            LoopClip.loop = true;
            LoopClip.pitch = 1f;
            LoopClip.Play();
            BGMAudioSource = LoopClip;
        }
    }

    /// <summary>  
    /// 播放一次的背景音乐  
    /// </summary>  
    /// <param name="audioClip"></param>  
    /// <param name="volume"></param>  
    /// <param name="name"></param>  
    private void PlayOnceBGMAudioClip(AudioClip audioClip, float volume = 1f, string name = null)
    {
        PlayBGMAudioClip(audioClip, volume, false, name == null ? "BGMSound" : name);
    }

    /// <summary>  
    /// 循环播放的背景音乐  
    /// </summary>  
    /// <param name="audioClip"></param>  
    /// <param name="volume"></param>  
    /// <param name="name"></param>  
    private void PlayLoopBGMAudioClip(AudioClip audioClip, float volume = 1f, string name = null)
    {
        PlayBGMAudioClip(audioClip, volume, true, name == null ? "LoopSound" : name);
    }

    #endregion

    #region  音效  

    /// <summary>  
    /// 播放音效
    /// </summary>  
    /// <param name="audioname"></param>  
    public void SoundPlay(int index, float volume = 1,bool loop = false)
    {
        volume = CacheManager.soundValue;
        if (CacheManager.PlaySound)
        {
            if (AudioDictionary.ContainsKey(index))
            {
                if (AudioDictionary[index] <= MaxAudioCount)
                {
                    AudioClip sound = FileIO.LoadAudioClip(index);

                    if (sound != null)
                    {
                        if (!loop)
                        {
                            StartCoroutine(this.PlayClipEnd(sound, index));
                        }

                        this.PlayClip(sound, volume, null, loop);
                        AudioDictionary[index]++;
                    }
                }
            }
            else
            {
                AudioDictionary.Add(index, 1);
                AudioClip sound = FileIO.LoadAudioClip(index);
                if (sound != null)
                {
                    StartCoroutine(this.PlayClipEnd(sound, index));
                    this.PlayClip(sound, volume);
                    AudioDictionary[index]++;
                }
            }
        }
    }

    /// <summary>  
    /// 暂停  
    /// </summary>  
    /// <param name="audioname"></param>  
    public void SoundPause()
    {

        if (this.LastAudioSource != null)
        {
            this.LastAudioSource.Pause();
        }
    }

    /// <summary>  
    /// 停止特定的音效  
    /// </summary>  
    /// <param name="audioname"></param>  
    public void SoundStop()
    {
        if (this.LastAudioSource != null)
        {
            this.LastAudioSource.Stop();
        }
    }

    /// <summary>  
    /// 关闭所有音效音乐
    /// 1.BGM打开的情况下，不暂停BGM     
    /// 2.BGM关闭，不处理
    /// </summary>  
    public void SoundAllPause()
    {
        AudioSource[] allsource = FindObjectsOfType<AudioSource>();
        if (allsource != null && allsource.Length > 0)
        {
            if (this.BGMAudioSource == null)
            {
                BGMPause();
                for (int i = 0; i < allsource.Length; i++)
                {
                    allsource[i].Pause();
                }
            }
            else
            {
                for (int i = 0; i < allsource.Length; i++)
                {
                    allsource[i].Pause();
                }
                BGMUnpause();
            }
        }
    }

    /// <summary>
    /// 打开所有音效
    /// 1.BGM打开情况下，不处理     
    /// 2.BGM关闭，打开音效，不能播放BGM
    /// </summary>
    public void SoundAllUnPause()
    {
        AudioSource[] allsource = FindObjectsOfType<AudioSource>();
        if (allsource != null && allsource.Length > 0)
        {
            if (this.BGMAudioSource != null)
            {
                for (int i = 0; i < allsource.Length; i++)
                {
                    allsource[i].UnPause();
                }
            }
            else
            {
                for (int i = 0; i < allsource.Length; i++)
                {
                    allsource[i].UnPause();
                }
                BGMPause();
            }
        }
    }

    

    /// <summary>  
    /// 播放音效  
    /// </summary>  
    /// <param name="audioClip"></param>  
    /// <param name="volume"></param>  
    /// <param name="name"></param>  
    private void PlayClip(AudioClip audioClip, float volume = 1f, string name = null,bool loop = false)
    {
        if (audioClip == null)
        {
            return;
        }
        else
        {
            GameObject obj = new GameObject(name == null ? "SoundClip" : name);
            obj.transform.parent = gameObject.transform;
            AudioSource source = obj.AddComponent<AudioSource>();
            if (!loop)
            {
                StartCoroutine(this.PlayClipEndDestroy(audioClip, obj));
            }
            
            source.pitch = 1f;
            source.volume = volume;
 
            source.loop = loop;
            source.clip = audioClip;
            source.Play();
           
            this.LastAudioSource = source;
        }
    }

    /// <summary>  
    /// 开始删除播放结束音效任务
    /// </summary>  
    /// <param name="audioclip"></param>  
    /// <param name="soundobj"></param>  
    /// <returns></returns>  
    private IEnumerator PlayClipEndDestroy(AudioClip audioclip, GameObject soundobj)
    {
        if (soundobj == null || audioclip == null)
        {
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(audioclip.length * Time.timeScale);
            Destroy(soundobj);
        }
    }

    /// <summary>  
    /// 开始删除播放结束音效任务
    /// </summary>  
    /// <returns></returns>  
    private IEnumerator PlayClipEnd(AudioClip audioclip, int index)
    {
        if (audioclip != null)
        {
            yield return new WaitForSeconds(audioclip.length * Time.timeScale);
            AudioDictionary[index]--;
            if (AudioDictionary[index] <= 0)
            {
                AudioDictionary.Remove(index);
            }
        }
        yield break;
    }
    #endregion

}