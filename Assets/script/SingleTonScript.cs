using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SingleTonScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI socoreText;
    Score score;

    void Awake() {
        score = FindObjectOfType<Score>();
    }

    void Start() {
        socoreText.text = "You Scored : \n" +  score.GetScore().ToString("00000");
    }
}
