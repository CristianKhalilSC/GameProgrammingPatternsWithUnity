using UnityEngine;

public class RotateSample : MonoBehaviour
{
    void Start()
    {
        iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
    }
}

