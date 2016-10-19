using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour
{
    public Animator animator;
    public Text achievementLabel;
    private int _fireCounter = 0;

    void OnEnable()
    {
        FireBallPlayer.OnCatchFire += PlayerCatchFire;
    }

    void OnDisable()
    {
        FireBallPlayer.OnCatchFire -= PlayerCatchFire;
    }

    private void PlayerCatchFire()
    {
        _fireCounter++;
        switch (_fireCounter)
        {
            case 1: achievementLabel.text = "Good start!"; break;
            case 2: achievementLabel.text = "Double Kill"; break;
            case 3: achievementLabel.text = "Multi Kill"; break;
            case 4: achievementLabel.text = "Mega Kill"; break;
            case 5: achievementLabel.text = "Ultra Kill"; break;
            case 6: achievementLabel.text = "Monster Kill"; break;
            case 7: achievementLabel.text = "Ludicrous Kill"; break;
            case 8: achievementLabel.text = "HOLY S**T"; break;
        }
        animator.Play("AchievementTextAnm", -1, 0);
    }

}
