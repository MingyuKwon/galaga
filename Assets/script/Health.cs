using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;

    int maxHealth = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem HitEffect;
    [SerializeField] CameraShake cameraShake;
    AudioPlayer audioPlayer;
    Score scoreKeeper;
    UI ui;
    LevelManager lm;

    void Awake() {
        lm = FindObjectOfType<LevelManager>();
        ui = FindObjectOfType<UI>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<Score>();
    }

    void Start() {
        maxHealth = health;
    }

    public int GetHealth()
    {
        return health;
    }

    void OnTriggerEnter2D(Collider2D other)  
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
    
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            audioPlayer.PlayHitClip();
            MakeHitEffect();
            damageDealer.Hit();
        }   
    }

    void TakeDamage(int damage)
    {   
        health -= damage;
        if(transform.tag == "Player" && cameraShake != null)
         {
            cameraShake.Play();
            float percent = (float)health / maxHealth;
            ui.changeSlide(percent);           
         }
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
            ui.UpdateScore();
            
        }else
        {
            lm.LoadResult();
        }

        Destroy(gameObject);

        
    }

    void MakeHitEffect()
    {
        if(HitEffect != null)
        {
            ParticleSystem a = Instantiate(HitEffect,
                    transform.position,
                    Quaternion.identity);

            Destroy(a.gameObject, a.main.duration + a.main.startLifetime.constantMax);
        }
        

        
    }

}
