using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume;

    [Header("Damage")]
    [SerializeField] AudioClip playerHitClip;
    [SerializeField] [Range(0f, 1f)] float playerHitVolume = 0.5f;

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayHitClip()
    {
        PlayClip(playerHitClip, playerHitVolume);
    }

    void PlayClip(AudioClip clip, float volume){
        if(clip != null)
        {
            Vector3 camerapos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,camerapos, volume);
        }
    }

}
