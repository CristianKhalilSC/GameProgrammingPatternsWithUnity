using UnityEngine;
using UnityEngine.UI;

public class HUDCounter : MonoBehaviour
{
    public Text scoreTxt;

    private int _currentScore;

    void OnEnable()
    {
        FireBallPlayer.OnCatchFire += PlayerCatchFire;
    }

    void OnDisable()
    {
        FireBallPlayer.OnCatchFire -= PlayerCatchFire;
    }

    void Start()
    {
        _currentScore = 0;
        scoreTxt.text = _currentScore.ToString();
    }

    private void PlayerCatchFire()
    {
        _currentScore++;
        scoreTxt.text = _currentScore.ToString();
    }

}
