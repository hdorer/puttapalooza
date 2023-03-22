using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour {
    private bool initialized = false;
    public bool Initialized { set => initialized = initialized ? initialized : value; }

    private int id;
    public int Id { get => id; }

    public void initialize(PlayerData player) {
        if(initialized) {
            return;
        }

        id = player.id;
        Debug.Log(gameObject.name + " ID: " + id);
    }
}
