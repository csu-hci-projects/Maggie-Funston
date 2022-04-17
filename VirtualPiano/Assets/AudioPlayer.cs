using UnityEngine;
using System.Collections;

public class NotePlayer : MonoBehaviour
{
    bool isActive = false;
    AudioSource audioSource;
    public AudioClip audioClip;
    public string note;
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 6, true);

        Debug.Log("LOADED NOTE PLAYER");

        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        if((this.transform.position.y < 1.3f) && (isActive == false)){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+0.01f, this.transform.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.relativeVelocity.magnitude > 0.7)) {
            Debug.Log("collision occured");
            Debug.Log(collision.gameObject.transform.parent.name + " " + note + " " + collision.relativeVelocity.magnitude);
            isActive = true;
            audioSource.PlayOneShot(audioClip, 1.0f);
            this.transform.position = new Vector3(this.transform.position.x, 1.2f, this.transform.position.z);
        }

    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("letting go");
        isActive = false;
    }
}