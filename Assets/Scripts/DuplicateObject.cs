using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DuplicateObject : MonoBehaviour
{

    public InputActionReference _cloneObjectReference;

    public AudioClip _audioClipOnDuplicate;

    void Awake()
    {
        // add Cloned and Detached events to action's .started and .canceled states
        _cloneObjectReference.action.started += Cloned;
        _cloneObjectReference.action.canceled += Detached;
    }

    void Start()
    {
        
    }

    private void Cloned(InputAction.CallbackContext context){
        // if the object is selected
        if (gameObject.GetComponent<XRGrabInteractable>().isSelected){
            // instantiate a copy of the current gameObject in the current position/rotation

            Color currentColor = GetObjectOriginalColor();

            GameObject clonedObject = Instantiate(gameObject, transform.position, transform.rotation);
            clonedObject.GetComponent<MeshRenderer>().material.color = currentColor;

            AudioSource.PlayClipAtPoint(_audioClipOnDuplicate, transform.position);
            
        }
        
    }

    private void Detached(InputAction.CallbackContext context)
    {
        // can specify custom behaviors for the original object when detached
    }

    //Getters
    private Color GetObjectOriginalColor(){
        return gameObject.GetComponent<HighlightObject>().GetObjectOriginalColor();
    }

}
