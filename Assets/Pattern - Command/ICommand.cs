using UnityEngine;

public interface ICommand
{
    int PlayerID { get; set; }
    int ObjectID { get; set; }
    void Execute(GameObject obj);
}
