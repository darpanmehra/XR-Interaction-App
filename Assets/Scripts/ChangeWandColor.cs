using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeWandColor : MonoBehaviour
{
    public InputActionReference _changeColorReference;
    public Color[] colors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow, Color.magenta };
    GameObject wandTopGameObject;
    public AudioClip _audioClipOnWandColorChange;
    
    void Awake()
    {
        // add Cloned and Detached events to action's .started and .canceled states
        _changeColorReference.action.started += ChangeColorListner;
        _changeColorReference.action.canceled += Detached;
    }

    void Start()
    {
        wandTopGameObject = gameObject.transform.GetChild(0).gameObject;

        //Get Original Color of the top
        //originalColor = wandTopGameObject.GetComponent<MeshRenderer>().material.color;
        
        //Set the color of the top 
        wandTopGameObject.GetComponent<MeshRenderer>().material.color = GetRandomColor();
    }

    private void ChangeColorListner(InputAction.CallbackContext context)
    {
        
        if (gameObject.GetComponent<XRGrabInteractable>().isSelected){
            
            Color newColor = GetNewWandTopColor();
            
            SetWandTopColor(wandTopGameObject, newColor);
            
            PlayAudioOnWandColorChange(_audioClipOnWandColorChange);
        }

        // can specify custom behaviors for the clone here
        // can do additional things like playing an sfx
    }

    //Get New Color for Wand
    private Color GetNewWandTopColor()
    {
        Color color = GetRandomColor();
        return color;
    }

    private void Detached(InputAction.CallbackContext context)
    {
        // can specify custom behaviors for the original object when detached
    }

    
    // Set Color of the given GameObject
    private void SetWandTopColor(GameObject gameObject, Color color){
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }

    
    public Color GetWandColor(){
        return wandTopGameObject.GetComponent<MeshRenderer>().material.color;
    }

    private Color GetRandomColor()
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        float g = UnityEngine.Random.Range(0f, 1f);
        float b = UnityEngine.Random.Range(0f, 1f);

        return new Color(r, g, b);
    }

    private void PlayAudioOnWandColorChange(AudioClip audioClip){
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
 
}
