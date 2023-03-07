using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.Assertions.Must;

public class FullScoreDisplayGenerator : MonoBehaviour {
    [Header("Prefabs")]
    [SerializeField] private TextMeshProUGUI playerLabelPrefab;
    [SerializeField] private TextMeshProUGUI holeLabelPrefab;
    [SerializeField] private TextMeshProUGUI scoreSlotPrefab;

    [Header("Scene Transforms")]
    [SerializeField] private RectTransform scoreDisplayPanel;
    [SerializeField] private RectTransform playerLabelStartingPoint;
    [SerializeField] private RectTransform holeLabelStartingPoint;

    [Header("Parameters")]
    [SerializeField] private int players = 4;
    [SerializeField] private int holes = 5;
    [SerializeField] private float horizontalPadding = 15;
    [SerializeField] private float verticalPadding = 15;

    public void generatePanel() {
        clearTexts();
        generatePlayerLabels();
        generateHoleLabels();
    }

    private void clearTexts() {
        foreach(Transform t in scoreDisplayPanel.GetComponentsInChildren<Transform>()) {
            if(t.gameObject.tag == "DontDestroyThis") {
                continue;
            }

            DestroyImmediate(t.gameObject);
        }
    }

    private void generatePlayerLabels() {
        for(int i = 0; i < players; i++) {
            Vector3 position = playerLabelStartingPoint.position + new Vector3(0, playerLabelPrefab.rectTransform.rect.height * i, 0);
            TextMeshProUGUI text = Instantiate(playerLabelPrefab, position, Quaternion.identity);
            text.rectTransform.parent = scoreDisplayPanel;
            text.text = "Player " + i;
            text.gameObject.name = "Player" + i + "Label";
        }
    }

    private void generateHoleLabels() {
        int i;
        for(i = 0; i < holes; i++) {
            Vector3 position = holeLabelStartingPoint.position + new Vector3(holeLabelPrefab.rectTransform.rect.width * i, 0, 0);
            TextMeshProUGUI text = Instantiate(holeLabelPrefab, position, Quaternion.identity);
            text.rectTransform.parent = scoreDisplayPanel;
            text.text = i.ToString();
            text.gameObject.name = "Hole" + i + "Label";
        }

        Vector3 totalPosition = holeLabelStartingPoint.position + new Vector3(holeLabelPrefab.rectTransform.rect.width * (i + 1), 0, 0);
        TextMeshProUGUI totalText = Instantiate(holeLabelPrefab, totalPosition, Quaternion.identity);
        totalText.rectTransform.parent = scoreDisplayPanel;
        totalText.text = "T";
        totalText.gameObject.name = "TotalScoreLabel";
    }
}
