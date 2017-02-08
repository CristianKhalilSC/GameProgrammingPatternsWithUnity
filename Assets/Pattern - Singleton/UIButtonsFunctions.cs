using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonsFunctions : MonoBehaviour
{

    [SerializeField]
    private Text soundManagerInstanceIDTxt;

    // Use this for initialization
    void Start()
    {
        soundManagerInstanceIDTxt.text = $"SoundManager instance ID: {SoundManager.instance.GetInstanceID().ToString()}";
    }

    public void CallTheSoundManagerAndPlayTheSpecialSound()
    {
        SoundManager.instance.PlayOurVerySpecialSound();
    }

    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name == "MainSingleton1")
            SceneManager.LoadScene("MainSingleton2", LoadSceneMode.Single);
        else
            SceneManager.LoadScene("MainSingleton1", LoadSceneMode.Single);
    }

}
