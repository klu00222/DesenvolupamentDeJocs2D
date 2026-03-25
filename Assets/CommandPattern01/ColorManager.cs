using System.Collections.Generic;
using UnityEngine;

public class ColorManager : ICommand
{
    private List<ColorEntity> entities;
    private Color color;

    private List<Color> entitiesHistory;

    public ColorManager(List<ColorEntity> entities, Color color)
    {
        this.entities = entities;
        this.color = color;
    }

    public void Execute()
    {
        entitiesHistory = new List<Color>();

        for (int i = 0; i < entities.Count; i++)
        {
            entitiesHistory.Add(entities[i].GetColor());
            entities[i].SetColor(color);
        }
    }

    public void Undo()
    {
        for (int i = 0; i < entities.Count;i++)
        {
            entities[i].SetColor(entitiesHistory[i]);
        }
    }
}
