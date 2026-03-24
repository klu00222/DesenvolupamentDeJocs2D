using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LanguageButton : MonoBehaviour
{
    public Language Language;
    private TextMeshProUGUI localizedText;

    private void Start()
    {
        localizedText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        localizedText.text = Language.ToString();
    }

    public void PressLanguageButton()
    {
        Language += 1;
        if (Language > Language.Spanish) Language = Language.English;

        Localizer.SetLanguage(Language);
        localizedText.text = Language.ToString();
    }
}
