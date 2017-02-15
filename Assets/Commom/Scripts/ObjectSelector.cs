using UnityEngine;

public class ObjectSelector : MonoBehaviour
{

    public GameObject currentSelectedGameObject;
    private ISelectible[] currentSelections;
    [SerializeField]
    private Camera _camera;

    // Use this for initialization
    void Start()
    {
        if (_camera == null)
        {
            Debug.Log("Object Selector - Camera not defined!");
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ISelectible[] selectable = hit.transform.GetComponents<ISelectible>();
                if (selectable != null && selectable.Length > 0)
                {
                    if (currentSelections != null)
                    {
                        for (int i = 0; i < currentSelections.Length; i++)
                        {
                            currentSelections[i].OnDeselected();
                        }
                    }

                    for (int j = 0; j < selectable.Length; j++)
                    {
                        selectable[j].OnSelected();
                    }
                    currentSelections = selectable;
                    currentSelectedGameObject = hit.transform.gameObject;
                }
            }
        }
    }
}
