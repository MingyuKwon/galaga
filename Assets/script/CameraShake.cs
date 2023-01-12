using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration =0.5f;
    [SerializeField] float shakeMagnitude =0.5f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float startTime = Time.time;
        float currnetTime = startTime;
        while((currnetTime - startTime) < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude ;
            currnetTime = Time.time;
            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPosition;
        
    }


    void Sample()
    {
        float elapsedTime = 0;
        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
        }
    }

}



