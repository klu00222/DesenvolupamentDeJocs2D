using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager Instance;

    public List<ColorEntity> AllEntities;
    private int currentIndex;

    public ColorEntity CurrentEntity => AllEntities[currentIndex];

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        AllEntities = GetComponentsInChildren<ColorEntity>().ToList();
    }

    public void SetNext()
    {
        currentIndex++;
        currentIndex %= AllEntities.Count;
    }

    public static List<ColorEntity> GetRandomEntities(int n)
    {
        return Instance.GetEntities(n);
    }

    private List<ColorEntity> GetEntities(int n)
    {
        List<int> chosen = new();

        int rdm = 0;

        for (int i = 0; i < n; i++)
        {
            while (chosen.Contains(rdm))
            {
                rdm = Random.Range(0, AllEntities.Count);
            }

            chosen.Add(rdm);
        }

        List<ColorEntity> entities = new();

        for (int i = 0; i < n; i++)
        {
            entities.Add(AllEntities[chosen[i]]);
        }

        return entities;
    }
}
