using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData {
    public int id;
    public int difficulty;
    public Powerup startingPowerup;
    public Color color;
    public int[] holeScores;
}

public class GameManager : MonoBehaviour {
    private static GameManager instance;

    private int numPlayers;
    [SerializeField] private int numHoles;

    [SerializeField] private PlayerPanelController pPanel;
    [SerializeField] private Powerup[] powerups;

    private PlayerData[] players;
    public static PlayerData[] Players { get => instance.players; }

    public static int NumPlayers { get => instance.numPlayers; }
    public static int NumHoles { get => instance.numHoles; }

    private void Awake() {
        instance = this;
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy() {
        instance = null;
    }

    public static void initializeGame() {
        instance.numPlayers = instance.pPanel.CurrentNumOfPlayers;
        instance.players = new PlayerData[instance.numPlayers];

        for(int i = 0; i < instance.numPlayers; i++) {
            instance.players[i].id = instance.pPanel.POptions[i].id;
            instance.players[i].difficulty = instance.pPanel.POptions[i].difficulty;
            instance.players[i].startingPowerup = instance.powerups[instance.pPanel.POptions[i].StartingPowerup];
            instance.players[i].color = instance.pPanel.POptions[i].color;
            instance.players[i].holeScores = new int[instance.numHoles];
        }

        instance.pPanel = null;
    }

    public static void saveScore(int player, int hole, int score) {
        instance.players[player].holeScores[hole] = score;
    }

    public static int[] getHoleScores(int player) {
        int[] scores = new int[instance.numHoles];
        
        for(int i = 0; i < scores.Length; i++) {
            scores[i] = instance.players[player].holeScores[i];
        }

        return scores;
    }
}
