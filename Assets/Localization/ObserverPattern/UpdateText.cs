using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    private TextMeshProUGUI textValue;

    private void Start()
    {
        textValue = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        PlayerLife.OnLifeChanged += ChangeText;
    }

    private void OnDisable()
    {
        PlayerLife.OnLifeChanged -= ChangeText;
    }

    private void ChangeText(int health)
    {
        textValue.text = health + "";
    }
}
