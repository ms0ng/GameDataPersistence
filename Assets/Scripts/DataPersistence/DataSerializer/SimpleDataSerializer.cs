using System;
using System.Reflection;
using UnityEngine;
using System.Linq;

public class SimpleDataSerializer : IDataSerializer
{
    public string Serialize(IPersistenceData data)
    {
        if (data.GetType().GetCustomAttribute<SerializableAttribute>() == null)
        {
            Debug.LogError($"类{data.GetType().Name}未标记Attribute [Serializable]，可能无法正常保存");
        }
        return JsonUtility.ToJson(data);
    }
    public T Deserialize<T>(string data)
    {
        if (string.IsNullOrEmpty(data)) { return default; }
        return JsonUtility.FromJson<T>(data);
    }

}
