using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class UIFactory
{
    private static Dictionary<string, Type> algorithmUIsByName;
    private static bool isInitialized => algorithmUIsByName != null;


    private static void InitializeFactory()
    {
        if(isInitialized)
        {
            return;
        }

        var algorithmTypes = Assembly.GetAssembly(typeof(AlgorithmUI)).GetTypes().
            Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(AlgorithmUI)));

        algorithmUIsByName = new Dictionary<string, Type>();

        foreach(var type in algorithmTypes)
        {
            var instance = Activator.CreateInstance(type) as AlgorithmUI;
            algorithmUIsByName[instance.Name] = type;
        }
    }

    public static AlgorithmUI GetAlgorithmUI(string name)
    {
        InitializeFactory();

        if(algorithmUIsByName.ContainsKey(name))
        {
            Type type = algorithmUIsByName[name];
            var instance = Activator.CreateInstance(type) as AlgorithmUI;
            return instance;
        }

        return null;
    }

    public static IEnumerable<string> getAlgorithmUINames()
    {
        InitializeFactory();

        return algorithmUIsByName.Keys;
    }

}
