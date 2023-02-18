using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class Storage
{
    private readonly string _filePath;
    private BinaryFormatter _formatter;

    public Storage()
    {
        var directory = Application.persistentDataPath + "/Saves";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        _filePath = directory + "/1.save";
        InitBinaryFormatter();
    }

    private void InitBinaryFormatter()
    {
        _formatter = new BinaryFormatter();
        var selector = new SurrogateSelector();

        var v3Surrogate = new Vector3SerializationSurrogate();
        var quaternionSurrogate = new QuaternionSerializationSurrogate();

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3Surrogate);
        selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All),
            quaternionSurrogate);

        _formatter.SurrogateSelector = selector;
    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(_filePath))
        {
            if (saveDataByDefault != null)
            {
                Save(saveDataByDefault);
            }

            return saveDataByDefault;
        }

        var file = File.Open(_filePath, FileMode.Open);
        var saveData = _formatter.Deserialize(file);
        file.Close();
        return saveData;
    }

    public void Save(object data)
    {
        var file = File.Create(_filePath);
        _formatter.Serialize(file, data);
        file.Close();
    }
}