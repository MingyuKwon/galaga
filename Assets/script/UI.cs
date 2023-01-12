using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI : MonoBehaviour
{
    Slider slider;
    TextMeshProUGUI score;
    Score scoreKeeper;



    TextMeshProUGUI[] texts;

    void Awake() {
        scoreKeeper = FindObjectOfType<Score>();
        slider = GetComponentInChildren<Slider>();
        texts = GetComponentsInChildren<TextMeshProUGUI>();

        if(scoreKeeper != null)
        {
            Debug.Log("scoreKeeper: " + scoreKeeper.gameObject.name) ;

        }

        for(int i=0;i<texts.Length; i++)
        {
            if(texts[i].gameObject.name == "Score")
            {
                score = texts[i];
            }
        }
        
    }

    void Start() {
        UpdateScore();
    }

    public void changeSlide(float value)
    {
        if(slider != null)
        {
            slider.value = value;            
        }
    }

    public void UpdateScore()
    {
        if(score != null)
        {
            if(scoreKeeper != null)
            {
                score.text = scoreKeeper.GetScore().ToString("00000");
            }else
            {
                Debug.Log("Scorekeeper Missing 2");

            }
        }
    }



}
