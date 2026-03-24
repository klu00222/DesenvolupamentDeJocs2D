using System.Collections.Generic;

/*
 * 
 * Crear un gameObject empty: Localizer, posar-li el script de Localizer, datasheet: el .csv
 * Al !botó! que canvia l'idioma: el script LanguageButton
 * Al !text! dins dels botons, o text individual: el script LocalizeText amb la que correspongui del .csv
 * 
 */

public enum Language
{
    English = 1,
    Catalan,
    Spanish
}

public class LanguageData
{
    public Dictionary<Language, string> Data;

    public LanguageData(string[] rawData)
    {
        Data = new Dictionary<Language, string>();

        for (int i = 1; i < rawData.Length; i++)
        {
            Data.Add((Language)i, rawData[i]);
        }
    }

    public string GetText(Language language)
    {
        return Data[language];
    }
}
