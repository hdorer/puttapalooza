using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelPause : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private List<GameObject> otherUI;
    [SerializeField] private InputAction pause;
    private bool isPause;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip pauseClip;
    private void OnEnable()
    {
        pause.Enable();
        pause.performed += onPause;
    }
    private void Start() {
        PausePanel.SetActive(false);
        audioPlayer.volume = GameManager.SfxVolume;
    }
    private void OnDisable()
    {
        pause.Disable();
        pause.performed -= onPause;
    }
    public void SwitchScene()
    {
        if(isPause)
        {
            Time.timeScale = 1;
            SceneChange.SwitchToScene(0);
        }
    }
    private void onPause(InputAction.CallbackContext context)
    {
        isPause = !isPause;
        audioPlayer.PlayOneShot(pauseClip);

        if(isPause)
        {
            PausePanel.SetActive(true);
            foreach(GameObject obj in otherUI)
            {
                obj.SetActive(false);
            }
            Time.timeScale = 0;
        }
        else
        {
            PausePanel.SetActive(false);
            foreach(GameObject obj in otherUI)
            {
                obj.SetActive(true);
            }
            Time.timeScale = 1;
        }

    }
}
