using System;
using System.IO;
using UnityEngine;

public class SimpleDataFileHandler : IDataFileHandler
{
    public string ReadData(string key)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, key);
        if (!File.Exists(fullPath)) return null;
        try
        {
            using (FileStream fs = new(fullPath, FileMode.Open))
            {
                using (StreamReader sr = new(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Something went wrong when saving game data...");
            Debug.LogError(e);
            return null;
        }
    }

    public void WriteData(string data, string key)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, key);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            using (FileStream fs = new(fullPath, FileMode.Create))
            {
                using (StreamWriter sw = new(fs))
                {
                    sw.Write(data);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Something went wrong when saving game data...");
            Debug.LogError(e);
        }
    }
}
