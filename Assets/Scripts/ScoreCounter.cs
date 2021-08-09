using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;

    public static int score, currentScore;

    //private void Awake()
    //{
        
    //    currentScore = 0;
    //}

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateScore();
        scoreText.text = "Score: " + score;

    }

    public void UpdateScore()
    {
        //score ++;
        

    }
}
