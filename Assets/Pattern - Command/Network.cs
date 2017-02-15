using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Network : MonoBehaviour
{
    public static Network instance = null;

    public delegate void MoveCommandOverNetwork(MovePlayerCommand cmd);
    public static event MoveCommandOverNetwork OnMoveCommandOverNetwork;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            DestroyObject(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SendMoveCommandOverNetwork(MovePlayerCommand command)
    {
        //Serialize
        var serialized = SerializeForNetwork(command);

        //Send data ---

        //Deserialize
        var cmd = DeserializeFromNetwork(serialized);

        if (OnMoveCommandOverNetwork != null)
            OnMoveCommandOverNetwork(cmd);
    }

    public MovePlayerCommand DeserializeFromNetwork(byte[] networkSerialized)
    {
        MemoryStream stream = new MemoryStream(networkSerialized);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        return (MovePlayerCommand)binaryFormatter.Deserialize(stream);
    }

    public byte[] SerializeForNetwork(MovePlayerCommand moveCmdToSerialize)
    {
        MemoryStream stream = new MemoryStream();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, moveCmdToSerialize);
        return stream.GetBuffer();
    }

}
