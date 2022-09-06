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
    private int collectionCount;

    public GameObject collectionEffects;

    private RollerBall player;

    private void Start()
    {
        endTxt.text = "";
        scoreM = this;

        player = GameObject.FindObjectOfType<RollerBall>();
        collectionEffects.SetActive(false);

        winScore = GameObject.FindObjectsOfType<PickUps>().Length;
    }

    public void collectableTouched(int v)
    {
        currentScore += v;
        updateScoreing();

        collectionEffects.SetActive(true);
        collectionEffects.transform.position = transform.position;

        collectionCount++;

        Invoke("resetEffects", .5f);
    }

    void resetEffects()
    {
        CancelInvoke("resetEffects");
        collectionEffects.SetActive(false);
    }

    void updateScoreing()
    {
        scoreTxt.text = "Score: " + currentScore;

        if(collectionCount >= winScore)
        {
            endTxt.text = "You Win!";
            player.toggleActive(false);
        }
    }
}