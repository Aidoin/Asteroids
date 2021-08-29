using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameAfterDeath : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private Text endMassage;


    private void Start() {
        endScreen.SetActive(false);
    }

    private void OnDestroy() {
        endScreen.SetActive(true);
        endMassage.text = "яв╗р: " + FindObjectOfType<Score>().Points.ToString();
    }
}
