using TMPro;
using UnityEngine;

public class LocalizeText : MonoBehaviour
{
    public string TextKey;
    private TextMeshProUGUI textValue;

    private void Start()
    {
        textValue = GetComponent<TextMeshProUGUI>();
        textValue.text = Localizer.GetText(TextKey);
    }

    private void OnEnable()
    {
        Localizer.OnLanguageChange += ChangeLanguage;
    }

    private void OnDisable()
    {
        Localizer.OnLanguageChange -= ChangeLanguage;
    }

    private void ChangeLanguage()
    {
        textValue.text = Localizer.GetText(TextKey);
    }
}
