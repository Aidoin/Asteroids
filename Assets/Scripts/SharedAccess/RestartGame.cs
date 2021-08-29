using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public static void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
