using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This is used to customize the player
//Includes color, difficulty, and starting power
public class PerPlayerCustomize : MonoBehaviour
{
    [SerializeField] private int playerNum;
    [SerializeField] private Image PlayerBall;
    [SerializeField] private TMP_Dropdown difficultyDropdown, powerUpDropdown;
    private int playerDifficulty;
    private int startingPowerup;
    [SerializeField] private Color playerColor;

    public int id { get => playerNum; }
    public int difficulty { get => playerDifficulty; }
    public int StartingPowerup { get => startingPowerup; }
    public Color color { get => playerColor; }

    private void OnEnable() {
        difficultyDropdown.onValueChanged.AddListener(delegate { ChangeDifficulty(difficultyDropdown.value); });
        powerUpDropdown.onValueChanged.AddListener(delegate { ChangeStartPowerup(powerUpDropdown.value); });
    }

    private void Start()
    {
        //Set color too thing
        PlayerBall.color = playerColor;
    }
    private void OnDisable()
    {
        difficultyDropdown.onValueChanged.RemoveAllListeners();
        powerUpDropdown.onValueChanged.RemoveAllListeners();
    }
    private void ChangeStartPowerup(int option)
    {
        startingPowerup = option;
    }
    private void ChangeDifficulty(int option)
    {
        playerDifficulty = option + 1;

        switch(option)
        {
            case 1:
                Debug.Log("Easy");
                break;
            case 2:
                Debug.Log("Medium");
                break;
            case 3:
                Debug.Log("Hard");
                break;
        }
    }
    public void ChangeColor(int colorNum)
    {
        switch(colorNum)
        {
            //Red
            case 1:
            PlayerBall.color = Color.red;
            playerColor = Color.red;
            break;
            //Blue
            case 2:
            PlayerBall.color = Color.blue;
            playerColor = Color.blue;
            break;
            //Black
            case 3:
            PlayerBall.color = Color.black;
            playerColor = Color.black;
            break;
            //Green
            case 4:
            PlayerBall.color = Color.green;
            playerColor = Color.green;
            break;
            //Yellow
            case 5:
            PlayerBall.color = Color.yellow;
            playerColor = Color.yellow;
            break;
            //
            case 6:
            PlayerBall.color = Color.magenta;
            playerColor = Color.magenta;
            break;
        }
        //Send To thing
    }
}
