using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelPause : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private InputAction pause;
    private bool isPause;
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
    private void onPause(InputAction.CallbackContext context)
    {
        isPause = !isPause;

        if(isPause)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }

    }
}
