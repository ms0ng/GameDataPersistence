using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDataPersistenceManager
{
    public static GameDataPersistenceManager Instance
    {
        get
        {
            if (instance == null) instance = new GameDataPersistenceManager();
            return instance;
        }
    }
    private static GameDataPersistenceManager instance;

    public List<IPersistenceData> datas;

    private IDataFileHandler fileHandler;
    private IDataSerializer serializer;

    private GameDataPersistenceManager()
    {
        datas = new List<IPersistenceData>();
        fileHandler = new SimpleDataFileHandler();
        serializer = new SimpleDataSerializer();
    }

    public bool RegisterPersistenceData(IPersistenceData data)
    {
        if (data == null) return false;
        if (datas.Contains(data)) return false;
        datas.Add(data);
        return true;
    }

    public void SaveData()
    {
        foreach (IPersistenceData data in datas)
        {
            fileHandler.WriteData(serializer.Serialize(data), data.GetSaveKey());
        }
    }

    public void SaveData(IPersistenceData data)
    {
        RegisterPersistenceData(data);
        fileHandler.WriteData(serializer.Serialize(data), data.GetSaveKey());
    }

    public T LoadData<T>(string key) where T : IPersistenceData
    {
        string data = fileHandler.ReadData(key);
        T t = serializer.Deserialize<T>(data);
        RegisterPersistenceData(t);
        return t;
    }
}
