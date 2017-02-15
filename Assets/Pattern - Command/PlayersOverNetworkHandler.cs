using System.Linq;
using UnityEngine;

public class PlayersOverNetworkHandler : MonoBehaviour
{
    [SerializeField]
    private Player[] _players;

    // Use this for initialization
    void Awake()
    {
        Network.OnMoveCommandOverNetwork += MoveCommandFromNetworkReceived;
    }

    void OnDestroy()
    {
        Network.OnMoveCommandOverNetwork -= MoveCommandFromNetworkReceived;
    }

    void MoveCommandFromNetworkReceived(MovePlayerCommand cmd)
    {
        ExecuteCommandFromNetwork(cmd);
    }

    void ExecuteCommandFromNetwork(ICommand command)
    {
        print("Cmd received - " + command.PlayerID + " - " + command.ObjectID);
        foreach (var player in _players)
        {
            if (player.PlayerId == command.PlayerID)
            {
                foreach (var pObj in player.PlayerObjects)
                {
                    if (pObj.ObjectId == command.ObjectID)
                    {
                        print(player.PlayerId + " - " + pObj.ObjectId);
                        command.Execute(pObj.gameObject);
                    }
                }
            }
        }
    }
}
