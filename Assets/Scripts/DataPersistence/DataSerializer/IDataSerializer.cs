
public interface IDataSerializer
{
    public string Serialize(IPersistenceData data);
    public T Deserialize<T>(string data);
}
