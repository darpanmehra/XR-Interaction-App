using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnWandCollision : MonoBehaviour
{

    MeshRenderer rend;

    public AudioClip _audioClipOnWandCollision;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider collider){
        GameObject collisionObject = collider.gameObject;
        if (collisionObject != null && collisionObject.name == "WandTop")
        {
            Color color = collisionObject.GetComponentInParent<ChangeWandColor>().GetWandColor();
            rend.material.color = color;
            PlayAudioOnWandCollision(_audioClipOnWandCollision);
        }
    }

    private void PlayAudioOnWandCollision(AudioClip audioClip){
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
}
