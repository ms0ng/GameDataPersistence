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
            Debug.Log($"��{type.Name}�ѱ��Ϊ�ɴ浵");
            if (type.GetCustomAttribute<SerializableAttribute>() == null)
            {
                Debug.LogWarning($"��{type.Name}δ���Attribute [Serializable]");
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
