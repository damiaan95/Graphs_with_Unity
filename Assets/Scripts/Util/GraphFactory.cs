using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GraphFactory
{
    private static Dictionary<string, GameObject> prefabDictionary;
    private static bool isInitialized => prefabDictionary != null;
    private static void InitializeFactory()
    {
        if(isInitialized)
        {
            return;
        }

        prefabDictionary = new Dictionary<string, GameObject>();
        Object[] prefabs = Resources.LoadAll("Prefabs", typeof(GameObject));

        foreach(Object prefab in prefabs)
        {
            GameObject p = prefab as GameObject;
            string name = p.name;
            prefabDictionary[name] = p;
        }
    }

    public static GameObject GetGraphElement(string name)
    {
        InitializeFactory();

        GameObject graphElement = prefabDictionary[name];

        if(graphElement == null)
        {
            throw new System.NullReferenceException(name + " cannot be found in the dictionary");
        }

        return graphElement;
    }
}
