using UnityEngine;

public class LocalArchiveManager
{
    private const bool isDebug = false;
    public const string LAST_LOGIN_HOST = "LAST_LOGIN_HOST";
    public const string LAST_LOGIN_NAME = "LAST_LOGIN_NAME";

    public const string GUEST_ACCOUNT = "GUEST_ACCOUNT";
    public const string ACCOUNT = "ACCOUNT";
    public const string PASSWORD = "PASSWORD";

    public const string IS_SupplementaryAccount = "SupplementaryAccount";

    public const string LANGUAGE = "LANGUAGE";

    public static SystemLanguage languages = Application.systemLanguage;

    public static void SetLanguages(SystemLanguage m_Languages)
    {
        languages = m_Languages;
        if (isDebug)
        {
            Debug.Log("m_Languages.ToString():" + (int)m_Languages);
        }

        PlayerPrefs.SetString(LANGUAGE, (int)m_Languages+"");
    }

    public static void LoadLanguage()
    {
        string languages_save = PlayerPrefs.GetString(LANGUAGE);
        if (isDebug)
        {
            Debug.Log("languages_save:" + languages_save);
        }
        if (!string.IsNullOrEmpty(languages_save))
        {
            languages = (SystemLanguage)(int.Parse(languages_save));
        }
    }


}