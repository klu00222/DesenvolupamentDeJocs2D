using System;
using System.Collections.Generic;
using UnityEngine;

public class Localizer : MonoBehaviour
{
    public static Localizer Instance;

    public TextAsset dataSheet;

    private Language currentLanguage;
    public Language DefaultLanguage;

    public Dictionary<string, LanguageData> Data;

    public static event Action OnLanguageChange;

    private void Awake()
    {
        Instance = this;
        currentLanguage = DefaultLanguage;

        LoadLanguageSheet();
    }

    public static string GetText(string textKey)
    {
        return Instance.Data[textKey].GetText(Instance.currentLanguage);
    }

    public static void SetLanguage(Language language)
    {
        Instance.currentLanguage = language;
        OnLanguageChange?.Invoke();
    }

    public void LoadLanguageSheet()
    {
        string[] lines = dataSheet.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines.Length > 1) AddLanguageData(lines[i]);
        }
    }

    public void AddLanguageData(string text)
    {
        if (Data == null) Data = new Dictionary<string, LanguageData>();

        string[] entries = text.Split(';');
        var languageData = new LanguageData(entries);

        Data.Add(entries[0], languageData);
    }
}
