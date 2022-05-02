using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float volume=0.8f;
    bool isPressed = false;
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    void Start()
    {
        Physics.IgnoreLayerCollision(6, 6, true);
    }

    void Update(){

        if((this.transform.position.y < 1.3f) && (isPressed == false)){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+0.01f, this.transform.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if ((collision.relativeVelocity.magnitude > 0.3)) {
            Debug.Log("collision occured");
            isPressed = true;
            Debug.Log(audioSource.time);
            audioSource.time = 2f;
            audioSource.Play();
            StartCoroutine(StartFade(audioSource, 5f, 0.1f));
            this.transform.position = new Vector3(this.transform.position.x, 1.2f, this.transform.position.z);
        }

    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("letting go");
        isPressed = false;
    }
}
