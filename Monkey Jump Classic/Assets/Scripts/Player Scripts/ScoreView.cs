using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Text highScore;
    private int preScore;
    private int hscore;


    // Start is called before the first frame update
    void Start()
    {   
        highScore = GameObject.Find("scorer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
     hscore = PlayerPrefs.GetInt("highscore");
     preScore = PlayerPrefs.GetInt("Score");

     if (preScore > hscore)
     {
        highScore.text = "Best: " + preScore.ToString();
        PlayerPrefs.SetInt("highscore",preScore);
     }
     else
     {
         highScore.text = "Best :" + hscore.ToString();
     }
     
    }
}
