using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Where all audio for player goes
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] private AudioClip ballHit;

    private void Start() {
        audioPlayer.volume = GameManager.SfxVolume;
    }

    public void playBallHit() {
        audioPlayer.PlayOneShot(ballHit);
    }
}
