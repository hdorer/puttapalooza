using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    private AudioSource aSource;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private int mainMenuIndex;

    private void Awake() {
        aSource = GetComponent<AudioSource>();
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);

        aSource.clip = menuMusic;
        aSource.Play();

        SceneManager.activeSceneChanged += onSceneChanged;
    }

    private void onSceneChanged(Scene current, Scene next) {
        if(next.buildIndex == 0) {
            Destroy(gameObject);
        } else {
            aSource.Stop();
            aSource.clip = gameMusic;
            aSource.Play();
        }
    }
}
