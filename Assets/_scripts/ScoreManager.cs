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

    private bool counting;

    float m = 0, s = 0;

    private void Start()
    {
        endTxt.text = "";
        scoreM = this;

        player = GameObject.FindObjectOfType<RollerBall>();
        collectionEffects.SetActive(false);

        winScore = GameObject.FindObjectsOfType<PickUps>().Length;
        s = 55;
        counting = true;

        //TESTING
        winScore = 2;
    }

    private void Update()
    {
        if (counting)
        {
            s += Time.deltaTime;
            if(s > 60)
            {
                s = 0;
                m++;
            }
        }
    }

    public void collectableTouched(int v)
    {
        currentScore += v;
        collectionCount++;

        updateScoreing();

        collectionEffects.SetActive(true);
        collectionEffects.transform.position = transform.position;

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
            counting = false;

            if (m > 1)
            {
                endTxt.text = "You Win! \n Your time: " + m + " minuets & " + (Mathf.Round(s * 100) / 100) + " seconds";
            }
            else
            {
                endTxt.text = "You Win! \n Your time: " + m + " minuet & " + (Mathf.Round(s * 100) / 100) + " seconds";
            }

            player.toggleActive(false);
        }
    }
}