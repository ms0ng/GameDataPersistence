using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// Using <see cref="GameSaver.Instance"/> to call methods.
/// </summary>
public class GameSaver
{
    public static GameSaver Instance
    {
        get
        {
            if (instance == null) instance = new GameSaver();
            return instance;
        }
    }
    private static GameSaver instance;

    private GameSaver()
    {
        var e = Assembly.GetExecutingAssembly().GetTypes().GetEnumerator();
        while (e.MoveNext())
        {
            Type type = (Type)e.Current;
            if (type.GetInterface(nameof(ISaveable)) == null) continue;
            Debug.Log($"类{type.Name}已标记为可存档");
            if (type.GetCustomAttribute<SerializableAttribute>() == null)
            {
                Debug.LogWarning($"类{type.Name}未标记Attribute [Serializable]");
            }
        }
    }

    public void Add<T>(string saveKey, T saveObject)
    {
        typeof(T).Attributes.ToString();
    }

    public void Commit(string saveKey = "")
    {

    }
}
