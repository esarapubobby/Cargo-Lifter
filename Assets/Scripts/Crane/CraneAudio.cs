using UnityEngine;

public class CraneAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip pickupSound;
    public AudioClip moveUpSound;
    public AudioClip moveDownSound;
    public AudioClip moveSound;


    public void Pickup()
    {
        audioSource.PlayOneShot(pickupSound);
    }

    public void MoveUp()
    {
        audioSource.clip = moveUpSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void MoveDown()
    {
        audioSource.clip = moveDownSound;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void Move()
    {
        audioSource.clip = moveSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

}