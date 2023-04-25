using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance;

    private int numPlayers;
    [SerializeField] private int numHoles;

    private PlayerPanelController pPanel;
    [SerializeField] private Powerup[] powerups;

    private PlayerData[] players;

    private float sfxVolume = 1f;

    private bool mercyRule = true;
    private int mercyScore = 15;

    public static int NumPlayers { get => instance.numPlayers; }
    public static int NumHoles { get => instance.numHoles; }
    public static PlayerData[] Players { get => instance.players; }
    public static float SfxVolume { get => instance.sfxVolume; set => instance.sfxVolume = value; }
    public static int MercyScore { get => instance.mercyScore; }

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public static void initializeGame() {
        instance.numPlayers = instance.pPanel.CurrentNumOfPlayers;
        instance.players = new PlayerData[instance.numPlayers];

        for(int i = 0; i < instance.numPlayers; i++) {
            instance.players[i] = new PlayerData(
                instance.pPanel.POptions[i].id,
                instance.pPanel.POptions[i].difficulty,
                instance.powerups[instance.pPanel.POptions[i].StartingPowerup],
                instance.pPanel.POptions[i].color
            );
        }

        instance.pPanel = null;
    }

    public static void saveScore(int player, int hole, int score) {
        instance.players[player].holeScores[hole] = score;
        instance.players[player].totalScore += score;
    }

    public static int[] getHoleScores(int player) {
        int[] scores = new int[instance.numHoles];
        
        for(int i = 0; i < scores.Length; i++) {
            scores[i] = instance.players[player].holeScores[i];
        }

        return scores;
    }

    public static PlayerData getWinner() {
        int lowestScore = int.MaxValue;
        int lowestIndex = NumPlayers - 1;
        for(int i = NumPlayers - 1; i >= 0; i--) {
            if(instance.players[i].totalScore < lowestScore) {
                lowestScore = instance.players[i].totalScore;
                lowestIndex = i;
            }
        }
        
        return instance.players[lowestIndex];
    }

    public static void setPlayerPanel(PlayerPanelController pPanel) {
        if(instance.pPanel == null) {
            instance.pPanel = pPanel;
        }
    }

    public static void savePowerup(int player, Powerup powerup) {
        instance.players[player].powerup = powerup;
    }

    public void setMercyRule(int sliderValue) {
        switch(sliderValue) {
            case 0:
                mercyRule = false;
                break;
            case 1:
                mercyRule = true;
                mercyScore = 10;
                break;
            case 2:
                mercyRule = true;
                mercyScore = 15;
                break;
            case 3:
                mercyRule = true;
                mercyScore = 20;
                break;
        }
    }
}
