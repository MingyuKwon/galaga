using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static Score instance;

    [SerializeField] int score = 0;

    void Awake() {
        
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore(){
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ClearScore()
    {
        score = 0;
    }

    
}
