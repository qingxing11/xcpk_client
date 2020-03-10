partial class BaseCanvas
{

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="index"></param>
    /// <param name="volume"></param>
    public static void PlaySound(int index, float volume = 1,bool loop = false)
    {
        AudioControl.Instance.SoundPlay(index, volume, loop);
    }

    public static void PlaySound(int index, bool loop = false)
    {
        AudioControl.Instance.SoundPlay(index, 1, loop);
    }

    public static void PlaySound(int index)
    {
        AudioControl.Instance.SoundPlay(index, 1, false);
    }

    public static void SoundStop()
    {
        AudioControl.Instance.SoundStop();
    }

    /// <summary>
    /// 暂停最后一个音效
    /// </summary>
    /// <param name="index"></param>
    public static void PauseSound()
    {
        AudioControl.Instance.SoundPause();
    }

    /// <summary>
    /// 暂停音效
    /// </summary>
    public static void PauseAllSound()
    {
        AudioControl.Instance.SoundAllPause();
    }

    /// <summary>
    /// 继续播放音效
    /// </summary>
    public static void UnPauseAllSound()
    {
        AudioControl.Instance.SoundAllUnPause();
    }

    public static void PlayBGM(int index, float volume = 1)
    {
        if (CacheManager.PlayMusic == true)
        {
            AudioControl.Instance.BGMPlay(index, volume);
        }
    }

    public static void PauseBGM()
    {
        AudioControl.Instance.BGMPause();
    }

    public static void StopBGM()
    {
        AudioControl.Instance.BGMStop();
    }

    public static void ReplayBGM()
    {
        AudioControl.Instance.BGMReplay();
    }

    public static void UnPauseBGM()
    {
        AudioControl.Instance.BGMUnpause();
    }
    /// <summary>
    /// 设置背景音乐音量大小
    /// </summary>
    /// <param name="volume"></param>
    public static void BGMSetVolume(float volume)
    {
        AudioControl.Instance.BGMSetVolume(volume);
    }


}