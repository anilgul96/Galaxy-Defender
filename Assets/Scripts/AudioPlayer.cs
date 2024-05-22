using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] 
    [SerializeField] private AudioClip shootingClip;

    [SerializeField] [Range(0f,1f)] private float shootingVolume = 1f;
    
    [Header("Damage")] 
    [SerializeField] private AudioClip damageClip;

    [SerializeField] [Range(0f,1f)] private float damageVolume = 1f;

    public static AudioPlayer instance;

    /*public AudioPlayer GetInstance()
    {
        return instance;
    }*/

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if (instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void DamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }
    
    void PlayClip(AudioClip clip, float volume)
        {
            if(clip != null)
            {
                Vector3 cameraPos = Camera.main.transform.position;
                AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
            }
        }


}
