using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance;

    [SerializeField] private int players;
    [SerializeField] private int holes;
    
    private int[,] holeScores;

    public static int Players { get => getPlayers(); }
    public static int Holes { get => getHoles(); }

    private void Awake() {
        instance = this;
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy() {
        instance = null;
    }

    public static void initializeScores() {
        if(instance == null) {
            throw new NullSingletonException("GameManager");
        }

        instance.holeScores = new int[instance.players, instance.holes];
    }

    public static void saveScore(int player, int hole, int score) {
        if(instance == null) {
            throw new NullSingletonException("GameManager");
        }

        instance.holeScores[player, hole] = score;
    }

    public static int[] getHoleScores(int player) {
        if(instance == null) {
            throw new NullSingletonException("GameManager");
        }

        int[] scores = new int[instance.holes];
        
        for(int i = 0; i < scores.Length; i++) {
            scores[i] = instance.holeScores[player, i];
        }

        return scores;
    }

    private static int getPlayers() {
        if(instance == null) {
            throw new NullSingletonException("GameManager");
        }

        return instance.players;
    }

    private static int getHoles() {
        if(instance == null) {
            throw new NullSingletonException("GameManager");
        }

        return instance.holes;
    }
}
