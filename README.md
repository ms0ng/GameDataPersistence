# GameDataPersistence
游戏数据存档相关
## 使用方法/ Usage
#### 定义数据类 / Define Data Class
定义一个新的数据类或在已有的类上继承接口 `IPersistenceData`
``` Csharp
[Serializable]//!!不要忘记添加Serializable
public class PlayerData : IPersistenceData
{
    public const string SAVE_KEY = "PlayerData";
    public string GetSaveKey()
    {
        return SAVE_KEY;
    }

    [SerializeField, HideInInspector]
    private int number;
}
```

#### 存档读档 / Save&Load
``` Csharp
PlayerData playerData = new();
GameDataPersistenceManager.Instance.SaveData(playerData);

//---

playerData = GameDataPersistenceManager.Instance.LoadData<PlayerData>(PlayerData.SAVE_KEY);
Debug.Log("Last Save Number: " + playerData.Number);
```

#### 自定义接口/ Custom Interfaces
自定义你的序列化器，接口和示例位于 `~\Assets\Scripts\DataPersistence\DataSerializer\`

自定义你的文件存储，接口和示例位于
`~\Assets\Scripts\DataPersistence\DataFileHandler\`

在GameDataPersistenceManager中修改你自定义的实现：
该文件位于`~\Assets\Scripts\DataPersistence\GameDataPersistenceManager.cs`
``` Csharp
    private GameDataPersistenceManager()
    {
        //fileHandler = new SimpleDataFileHandler();
        //serializer = new SimpleDataSerializer();
        // ->
        fileHandler = new MyDataFileHandler();
        serializer = new MyDataSerializer();
    }
```