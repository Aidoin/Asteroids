using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text text;
    private int points = 0; public int Points => points;


    private void Start() {
        AddPoints(0);
    }

    public void AddPoints(int value) {
        points += value;
        UpdateScorePoints();
    }

    private void UpdateScorePoints() {
        text.text = points.ToString();
    }
}
