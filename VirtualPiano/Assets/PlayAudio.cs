using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    //public AudioSource pianoSound;
    bool isPressed = false;

    void Start()
    {
        Physics.IgnoreLayerCollision(6, 6, true);
        Debug.Log("LOADED NOTE PLAYER");
    }

    void Update(){
        if((this.transform.position.y < 1.3f) && (isPressed == false)){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+0.01f, this.transform.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.relativeVelocity.magnitude > 0.1)) {
            Debug.Log("collision occured");
            isPressed = true;
            //pianoSound.Play();
            this.transform.position = new Vector3(this.transform.position.x, 1.2f, this.transform.position.z);
        }

    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("letting go");
        //pianoSound.Stop();
        isPressed = false;
    }
}
