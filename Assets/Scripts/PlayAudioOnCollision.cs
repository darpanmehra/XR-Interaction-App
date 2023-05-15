using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnCollision : MonoBehaviour
{

    AudioSource _audioSource;

    // public AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnCollisionEnter(Collision collision){
        
        if (_audioSource.clip){
            _audioSource.Play();
        }
        
    }
}
