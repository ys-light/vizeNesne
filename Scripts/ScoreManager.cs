using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   [SerializeField]
    private Text txtScore;

    private int score = 0;

    [SerializeField]
    private PlayerController playerController;

    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
  public  void UpdateScore(int amount)
    {
        score += amount;
        txtScore.text = "SCORE: " + score;
        if(score%10==0 && score != 0)
        {
            playerController.UpdateLevel();
        }
    }
}
