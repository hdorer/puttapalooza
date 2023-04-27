using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Where all audio for player goes
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] private AudioClip ballHit;
    [SerializeField] private AudioClip ballHitWall;
    [SerializeField] private AudioClip ballLandGround;
    [SerializeField] private AudioClip ballLandSand;
    [SerializeField] private AudioClip ballLandIce;
    [SerializeField] private AudioClip powerUpUse;
    [SerializeField] private AudioClip ballLandWater;
    [SerializeField] private AudioClip pickUP;

    private void Start() {
        audioPlayer.volume = GameManager.SfxVolume;
    }

    public void playBallHit() {
        audioPlayer.PlayOneShot(ballHit);
    }
    public void playBallWall() {
        audioPlayer.PlayOneShot(ballHitWall);
    }
    public void playBallGround() {
        audioPlayer.PlayOneShot(ballLandGround);
    }
    public void playBallSand() {
        audioPlayer.PlayOneShot(ballLandSand);
    }
    public void playBallIce() {
        audioPlayer.PlayOneShot(ballLandIce);
    }
    public void playPowerupUse() {
        audioPlayer.PlayOneShot(powerUpUse);
    }
    public void playBallWater(){
        audioPlayer.PlayOneShot(ballLandWater);
    }
    public void playPickup()
    {
        audioPlayer.PlayOneShot(pickUP);
    }
}
