using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScoreDisplayGenerator : MonoBehaviour {
    [Header("Prefabs")]
    [SerializeField] private TextMeshProUGUI playerLabelPrefab;
    [SerializeField] private TextMeshProUGUI holeLabelPrefab;
    [SerializeField] private TextMeshProUGUI scoreLabelPrefab;

    [Header("Scene Transforms")]
    [SerializeField] private RectTransform scoreDisplayPanel;
    [SerializeField] private RectTransform playerLabelStartingPoint;
    [SerializeField] private RectTransform holeLabelStartingPoint;

    [Header("Parameters")]
    [SerializeField] private int players = 4;
    [SerializeField] private int holes = 5;

    private FullScoreDisplay display;

    public void generatePanel() {
        display = GetComponent<FullScoreDisplay>();
        display.initializeArrays(players, holes);

        clearTexts();
        generatePlayerLabels();
        generateHoleLabels();
        generateScoreLabels();
        // resizePanel();
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
            Vector3 position = playerLabelStartingPoint.position - new Vector3(0, playerLabelPrefab.rectTransform.rect.height * i, 0);
            TextMeshProUGUI text = Instantiate(playerLabelPrefab, position, Quaternion.identity);
            text.rectTransform.SetParent(scoreDisplayPanel);
            text.text = "Player " + (i + 1);
            text.gameObject.name = "Player" + (i + 1) + "Label";
        }
    }

    private void generateHoleLabels() {
        int i;
        for(i = 0; i < holes; i++) {
            Vector3 position = holeLabelStartingPoint.position + new Vector3(holeLabelPrefab.rectTransform.rect.width * i, 0, 0);
            TextMeshProUGUI text = Instantiate(holeLabelPrefab, position, Quaternion.identity);
            text.rectTransform.SetParent(scoreDisplayPanel);
            text.text = (i + 1).ToString();
            text.gameObject.name = "Hole" + (i + 1) + "Label";
        }

        Vector3 totalPosition = holeLabelStartingPoint.position + new Vector3(holeLabelPrefab.rectTransform.rect.width * i, 0, 0);
        TextMeshProUGUI totalText = Instantiate(holeLabelPrefab, totalPosition, Quaternion.identity);
        totalText.rectTransform.SetParent(scoreDisplayPanel);
        totalText.text = "T";
        totalText.gameObject.name = "TotalScoreLabel";
    }

    private void generateScoreLabels() {
        for(int i = 0; i < players; i++) {
            int j;
            for(j = 0; j < holes; j++) {
                float posX = holeLabelStartingPoint.position.x + holeLabelPrefab.rectTransform.rect.width * j;
                float posY = playerLabelStartingPoint.position.y - playerLabelPrefab.rectTransform.rect.height * i;
                Vector3 position = new Vector3(posX, posY, 0);

                TextMeshProUGUI text = Instantiate(scoreLabelPrefab, position, Quaternion.identity);
                text.rectTransform.SetParent(scoreDisplayPanel);
                text.gameObject.name = "Player" + (i + 1) + "Hole" + (j + 1);

                display.addScoreLabel(i, j, text);
            }

            float totalPosX = holeLabelStartingPoint.position.x + holeLabelPrefab.rectTransform.rect.width * j;
            float totalPosY = playerLabelStartingPoint.position.y - playerLabelPrefab.rectTransform.rect.height * i;
            Vector3 totalPosition = new Vector3(totalPosX, totalPosY, 0);

            TextMeshProUGUI totalText = Instantiate(scoreLabelPrefab, totalPosition, Quaternion.identity);
            totalText.rectTransform.SetParent(scoreDisplayPanel);
            totalText.gameObject.name = "Player" + (i + 1) + "Total";

            display.addScoreLabel(i, totalText);
        }
    }

    private void resizePanel() {
        // TODO: this doesn't work and needs to be fixed
        
        float hPadding = playerLabelStartingPoint.position.x - playerLabelPrefab.rectTransform.rect.width / 2;
        float vPadding = holeLabelStartingPoint.position.y - holeLabelPrefab.rectTransform.rect.width / 2;

        float panelWidth = (holeLabelStartingPoint.position.x + holeLabelPrefab.rectTransform.rect.width * (holes - 1) + hPadding);
        float panelHeight = (playerLabelStartingPoint.position.y + playerLabelPrefab.rectTransform.rect.height * (players - 1) + vPadding);

        scoreDisplayPanel.sizeDelta = new Vector2(panelWidth, panelHeight);

        scoreDisplayPanel.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
