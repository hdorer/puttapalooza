using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private static LevelManager instance;

    [Header("Level Data")]
    [SerializeField] private int levelId;
    [SerializeField] private int nextSceneIndex;

    [Header("Player Prefab")]
    [SerializeField] private GameObject playerPrefab;
    private GameObject[] players;

    [Header("Hole Start")]
    [SerializeField] private Transform holeStart;

    [Header("UI")]
    [SerializeField] private PowerupButton powerupIcon;
    [SerializeField] private ScoreDisplay scoreDisplay;

    public static int LevelId { get => instance.levelId; }

    private void Awake() {
        instance = this;
    }

    private void Start() {
        Debug.Log("This code is being reached");

        players = new GameObject[GameManager.NumPlayers];

        for(int i = 0; i < players.Length; i++) {
            players[i] = Instantiate(playerPrefab, holeStart.position, Quaternion.identity);
            players[i].name = "Player" + i;
            players[i].GetComponent<PlayerTurn>().initialize(GameManager.Players[i]);
            players[i].GetComponent<PlayerTurn>().Initialized = true;
        }
    }

    private void OnDestroy() {
        instance = null;
    }

    public static void loadNextLevel() {
        SceneManager.LoadScene(instance.nextSceneIndex);
    }

    public static int getPlayerCurrentScore(int player) {
        return instance.players[player].GetComponent<PlayerScore>().CurrentScore;
    }

    public static int getPlayerTotalScore(int player) {
        return instance.players[player].GetComponent<PlayerScore>().TotalScore;
    }

    public static void updateButtonState(PlayerMovement pMovement, PlayerPowerups pPowerups) {
        instance.powerupIcon.updateButtonState(pMovement, pPowerups);
    }

    public static void updateScoreText(PlayerScore pScore) {
        instance.scoreDisplay.updateScoreText(pScore.CurrentScore);
    }
}
