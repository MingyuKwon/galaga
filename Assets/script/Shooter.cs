using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] Transform laserShooter;
    

    [SerializeField] float shootingDelay = 0.2f;
    [SerializeField] float AIshootingDelay = 0.7f;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float laserLifeTime = 2f;

    [SerializeField] public bool isShooting;

    public bool isAI;

    Coroutine fireCoroutine; // 현재 실행되는 coroutine을 담아둬서 stop에 인수로 넘길수도 있고, null인지 아닌지를 현재 1개의 coroutine이 있는지 없는지 확인 가능
    AudioPlayer audioPlayer;

    void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start() {
        if(isAI)
        {
            isShooting = true;
            laserSpeed = -laserSpeed;
        }
    }

    void Update()
    {
        CoroutineFire();
    }

    void CoroutineFire()
    {
        if(isShooting && fireCoroutine == null) // 이래야 coroutine이 없는 상황에서만 shoot 요청이 왔을 때 coroutine을 만들어 준다
        {
            fireCoroutine = StartCoroutine(ContinouslyFire());
        }else if(fireCoroutine != null && !isShooting)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
        
    }
    IEnumerator ContinouslyFire()
    {
        while(true)
        {
            GameObject laser =  Instantiate(laserPrefab, 
            transform.position,
            Quaternion.identity,
            laserShooter);
            laser.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(0f, laserSpeed);
            Destroy(laser, laserLifeTime);

            audioPlayer.PlayShootingClip();

            if(isAI)
            {
                shootingDelay = Random.Range(shootingDelay, AIshootingDelay);
            }
            yield return new WaitForSecondsRealtime(shootingDelay);
        }    
    }
}
