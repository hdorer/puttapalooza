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
    public AudioSource audioPlayer;
    public AudioClip pauseClip;
    void OnEnable()
    {
        pause.Enable();
        pause.performed += onPause;
    }
    void OnDisable()
    {
        pause.Disable();
        pause.performed -= onPause;
    }
    void Start()
    {
        PausePanel.SetActive(false);
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
