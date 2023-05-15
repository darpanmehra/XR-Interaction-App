using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// to be attached to the controller for which you want to toggle RayInteractor
/// switches between RayInteractor and DirectInteractor
/// </summary>
public class ToggleRay : MonoBehaviour
{
    // define a public InputActionReference for toggle button
    public InputActionReference _toggleReference;
    // and a reference to the rayInteractor GameObject to be toggled
    public GameObject _rayInteractor;
    // need a global variable for the XRDirectInteractor reference
    XRDirectInteractor _directInteractor;

    void Awake()
    {
        // add Pressed and Released events to action's .started and .canceled states
        _toggleReference.action.started += Pressed;
        _toggleReference.action.canceled += Released;
        // get a reference to the XRDirectInteractor attached to current gameObject
        _directInteractor = GetComponent<XRDirectInteractor>();
    }

    private void OnDestroy()
    {
        // remove event listeners when destroyed
    }

    void Pressed(InputAction.CallbackContext context)
    {
        // toggle the Ray
        Toggle();
    }

    void Released(InputAction.CallbackContext context)
    {
        // toggle the Ray
        Toggle();
    }

    void Toggle()
    {
        // get a bool, isToggled, for the current state of the rayInteractor
        bool isToggled = _rayInteractor.activeSelf;
        // setActive of the rayInteractor based on the bool value
        // set enable of the directInteractor based on the bool value
        if (!isToggled){
            _directInteractor.enabled = false;
            _rayInteractor.SetActive(true);            
        } else {
            _directInteractor.enabled = true;
            _rayInteractor.SetActive(false);
        }
        
    }
}
