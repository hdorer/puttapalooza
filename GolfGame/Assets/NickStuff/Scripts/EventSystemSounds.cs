using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemSounds : MonoBehaviour
{
    [SerializeField] private AudioClip ballSelect;
    [SerializeField] private AudioClip playerJoin;
    [SerializeField] private AudioClip menuButton;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip startGame;

    public void playInputAudio(AudioClip audio)
    {
        audioPlayer.PlayOneShot(audio);
    }
    public void playBallSelect()
    {
        audioPlayer.PlayOneShot(ballSelect);
    }
    public void playPlayerJoin()
    {
        audioPlayer.PlayOneShot(playerJoin);
    }
    public void playMenuButton()
    {
        audioPlayer.PlayOneShot(menuButton);
    }
    public void playStartGame()
    {
        audioPlayer.PlayOneShot(startGame);
    }
}
