using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData {
    public int id;
    public int[] holeScores;
}

public class GameManager : MonoBehaviour {
    private static GameManager instance;

    [SerializeField] private int numPlayers;
    [SerializeField] private int numHoles;

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
        instance.players = new PlayerData[instance.numPlayers];

        for(int i = 0; i < instance.numPlayers; i++) {
            instance.players[i].id = i;
            instance.players[i].holeScores = new int[instance.numHoles];
        }
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
