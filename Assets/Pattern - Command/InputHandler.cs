using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Camera _camera;
    private ObjectSelector _objectSelector;

    // Use this for initialization
    void Start()
    {
        _objectSelector = _camera.gameObject.GetComponent<ObjectSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && _camera.pixelRect.Contains(Input.mousePosition))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ground")
                {
                    if (_objectSelector.currentSelectedGameObject != null)
                    {
                        var selectedObjectId = _objectSelector.currentSelectedGameObject.GetComponent<PlayerObject>().ObjectId;
                        if (selectedObjectId != 0)
                        {
                            var pos = hit.point - hit.transform.position;
                            MovePlayerCommand command = new MovePlayerCommand(_player.PlayerId, selectedObjectId, pos.x, pos.z);
                            command.Execute(_objectSelector.currentSelectedGameObject);

                            //Send over network
                            Network.instance.SendMoveCommandOverNetwork(command);
                        }
                    }
                }
            }
        }
    }
}
