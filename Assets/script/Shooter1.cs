using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter1 : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] Transform laserShooter;

    [SerializeField] float shootingDelay = 0.2f;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float laserLifeTime = 1f;

    [SerializeField] public bool isShooting1;

    Coroutine fireCoroutine; // 현재 실행되는 coroutine을 담아둬서 stop에 인수로 넘길수도 있고, null인지 아닌지를 현재 1개의 coroutine이 있는지 없는지 확인 가능

    void Start() {
        StartCoroutine(ContinouslyFire());
    }


    IEnumerator ContinouslyFire()
    {
        while(true)
        {
            if(isShooting1)
            {
                GameObject laser =  Instantiate(laserPrefab, 
                transform.position,
                Quaternion.identity,
                laserShooter);
                laser.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(0f, laserSpeed);
                Destroy(laser, laserLifeTime);

                yield return new WaitForSecondsRealtime(shootingDelay);
            }
            yield return new WaitForEndOfFrame();
        }    
    }
}
