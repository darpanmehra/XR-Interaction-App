using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    public Color highlightColor;
    public AudioClip _audioClipOnHover;
    
    MeshRenderer _renderer;
    Color currentColor;
    bool isHighlighted = false;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        currentColor = _renderer.material.color;
    }

    // void Update(){
        
    // }

    void Highlight()
    {
        currentColor = _renderer.material.color;

        //Play Audio on hover
        AudioSource.PlayClipAtPoint(_audioClipOnHover, transform.position);
        // set isHighlighted true
        isHighlighted = true;
        // change the material color to highlightColor
        _renderer.material.color = highlightColor;
    }

    void Dehighlight()
    {
        // set isHighlighted false
        isHighlighted = false;
        // change the material color to originalColor
        _renderer.material.color = currentColor;
    }

    public void ToggleHighlight()
    {
        if (!isHighlighted){
            Highlight();
        } else{
            Dehighlight();
        }
    }

    public Color GetObjectOriginalColor(){
        return currentColor;
    }
}
