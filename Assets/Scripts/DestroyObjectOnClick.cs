using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyObjectOnClick : MonoBehaviour
{
    public InputActionReference _destroyObjectReference;
    public AudioClip _audioClipOnDestroy;
    public GameObject _particleEffect;

    void Awake()
    {
        // add Cloned and Detached events to action's .started and .canceled states
        _destroyObjectReference.action.started += DestroyObjectOnButtonClick;
        _destroyObjectReference.action.canceled += Detached;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void DestroyObjectOnButtonClick(InputAction.CallbackContext context){
        if (gameObject.GetComponent<XRGrabInteractable>().isSelected){
            

            AudioSource.PlayClipAtPoint(_audioClipOnDestroy, transform.position);
            
            Destroy(gameObject, 0.3f);

            GameObject particleEffect = Instantiate(_particleEffect, transform.position, transform.rotation);
            particleEffect.GetComponent<ParticleSystem>().Play();
            
            //Destroy(particleEffect);
            
        }

    }

    private void Detached(InputAction.CallbackContext context)
    {
        // can specify custom behaviors for the original object when detached
    }

}
