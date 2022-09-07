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
    private float timer;

    private void Start()
    {
        endTxt.text = "";
        scoreM = this;

        player = GameObject.FindObjectOfType<RollerBall>();
        collectionEffects.SetActive(false);

        winScore = GameObject.FindObjectsOfType<PickUps>().Length;
        timer = 0;
        counting = true;
    }

    private void Update()
    {
        if (counting)
        {
            timer += Time.deltaTime;
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
            endTxt.text = "You Win! \n Your time: " + (Mathf.Round(timer * 100) / 100) + " seconds";

            player.toggleActive(false);
        }
    }
}