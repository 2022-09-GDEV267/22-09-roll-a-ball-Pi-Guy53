using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreM;
    private int currentScore;

    public Text scoreTxt;
    public Text endTxt;
    public int winScore;

    private RollerBall player;

    private void Start()
    {
        endTxt.text = "";
        scoreM = this;

        player = GameObject.FindObjectOfType<RollerBall>();
    }

    public void collectableTouched(int v)
    {
        currentScore += v;
        updateScoreing();
    }

    void updateScoreing()
    {
        scoreTxt.text = "Score: " + currentScore;

        if(currentScore >= winScore)
        {
            endTxt.text = "You Win!";
            player.toggleActive(false);
        }
    }
}