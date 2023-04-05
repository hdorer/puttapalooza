using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private static LevelManager instance;

    [Header("Level Data")]
    [SerializeField] private int levelId;
    [SerializeField] private bool finalLevel = false;
    [SerializeField] private int nextSceneIndex;
    [SerializeField] private float levelEndDelay = 3f;

    [Header("Player Prefab")]
    [SerializeField] private GameObject playerPrefab;
    private GameObject[] players;
    private int currentPlayer = 0;

    [Header("Level Objects")]
    [SerializeField] private Transform holeStart;
    [SerializeField] private Hole hole;
    [SerializeField] private CameraSwitcher camSwitcher;

    [Header("UI")]
    [SerializeField] private PowerupButton powerupIcon;
    [SerializeField] private ScoreDisplay scoreDisplay;
    [SerializeField] private FullScoreDisplay fullScoreDisplay;
    [SerializeField] private WinnerDisplay winnerDisplay;
    [SerializeField] private PowerSliderScript powSlider;

    public static int LevelId { get => instance.levelId; }
    public static Transform HoleStart { get => instance.holeStart; }

    private void Awake() {
        instance = this;
    }

    private void Start() {
        Debug.Log("This code is being reached");

        players = new GameObject[GameManager.NumPlayers];

        for(int i = 0; i < players.Length; i++) {
            players[i] = Instantiate(playerPrefab, holeStart.position, Quaternion.identity);
            players[i].name = "Player" + i;
            players[i].GetComponent<PlayerTurn>().initialize(GameManager.Players[i].id, GameManager.Players[i].color);
            players[i].GetComponent<PlayerMovement>().initialize(GameManager.Players[i].difficulty, hole, powSlider);
            players[i].GetComponent<PlayerPowerups>().initialize(GameManager.Players[i].startingPowerup);
            players[i].SetActive(false);
        }

        camSwitcher.initialize(players);

        players[currentPlayer].SetActive(true);
        players[currentPlayer].GetComponent<PlayerTurn>().startTurn();
    }

    private void OnDestroy() {
        instance = null;
    }

    public static bool finishLevel() {
        for(int i = 0; i < GameManager.NumPlayers; i++) {
            if(!instance.players[i].GetComponent<PlayerTurn>().HoleCompleted) {
                return false;
            }
        }

        // show full score display
        instance.StartCoroutine(instance.showFullScoreDisplay());
        return true;
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
        instance.scoreDisplay.updateScoreText(pScore.GetComponent<PlayerTurn>().Id, pScore.CurrentScore);
    }

    public static void goToNextTurn() {
        instance.players[instance.currentPlayer].SetActive(false);

        do {
            instance.currentPlayer++;
            if(instance.currentPlayer >= GameManager.NumPlayers) {
                instance.currentPlayer = 0;
            }
        } while(instance.players[instance.currentPlayer].GetComponent<PlayerTurn>().HoleCompleted);

        instance.players[instance.currentPlayer].SetActive(true);
        instance.camSwitcher.switchActiveCam(instance.currentPlayer);

        instance.players[instance.currentPlayer].GetComponent<PlayerTurn>().startTurn();
    }

    public void loadNextLevel() {
        SceneManager.LoadScene(nextSceneIndex);
    }

    private IEnumerator showFullScoreDisplay() {
        fullScoreDisplay.show();
        fullScoreDisplay.disableInput();

        yield return new WaitForSeconds(levelEndDelay);

        if(finalLevel) {
            winnerDisplay.show(GameManager.getWinner());
        } else {
            loadNextLevel();
        }
    }
}
