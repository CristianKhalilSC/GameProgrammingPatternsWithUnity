using UnityEngine;

public class FireBallPlayer : MonoBehaviour
{

    public delegate void CatchFire();
    public static event CatchFire OnCatchFire;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Destroy(other.gameObject);
            if (OnCatchFire != null)
                OnCatchFire();
        }
    }

}
