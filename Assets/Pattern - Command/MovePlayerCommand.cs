using System;
using UnityEngine;

[Serializable]
public class MovePlayerCommand : ICommand
{
    public int PlayerID { get; set; }
    public int ObjectID { get; set; }

    private float _x;
    private float _z;

    public MovePlayerCommand(int playerId, int objectId, float x, float z)
    {
        PlayerID = playerId;
        ObjectID = objectId;
        _x = x;
        _z = z;
    }

    public void Execute(GameObject obj)
    {
        iTween.MoveTo(obj, iTween.Hash("position", new Vector3(_x, obj.transform.position.y, _z), "islocal", true, "time", 1));
    }

}
