using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Where all audio for player goes
public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioPlayer;

    [SerializeField]
    private AudioClip ballHit;

    public void playeBallHit()
    {
        audioPlayer.PlayOneShot(ballHit);
    }
}
