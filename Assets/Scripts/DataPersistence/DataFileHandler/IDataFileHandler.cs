internal interface IDataFileHandler
{
    public void WriteData(string data, string key);
    public string ReadData(string key);
}
