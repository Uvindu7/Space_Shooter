
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    private int score1 = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("Score",0);
    }

    public void IncreaseScore()
    {
        score1 += 1;
        score.text = "SCORE : " + score1;
        PlayerPrefs.SetInt("Score", score1);
    }
}
