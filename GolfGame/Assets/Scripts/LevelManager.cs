using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private static LevelManager instance;

    [SerializeField] private int levelId;
    [SerializeField] private int nextSceneIndex;

    [SerializeField] private GameObject[] players;

    public static int LevelId { get => getLevelId(); }

    private void Awake() {
        instance = this;
    }

    private void OnDestroy() {
        instance = null;
    }

    public static void loadNextLevel() {
        SceneManager.LoadScene(instance.nextSceneIndex);
    }

    public static PlayerScore getPlayerScore(int player) {
        return instance.players[player].GetComponent<PlayerScore>();
    }

    private static int getLevelId() {
        return instance.levelId;
    }
}
