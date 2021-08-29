using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform PlayingField;

    [SerializeField] private GameObject[] meteors;
    [SerializeField] private Vector2 MinMaxSpawnTimeMeteor;
    private float spawntimeMeteor;
    private float timerMeteor;

    [SerializeField] private GameObject uFO;
    [SerializeField] private Vector2 MinMaxSpawnTimeUFO;
    private float spawntimeUFO;
    private float timerUFO;


    void Start() {
        spawntimeMeteor = Random.Range(MinMaxSpawnTimeMeteor.x, MinMaxSpawnTimeMeteor.y);
        spawntimeUFO = Random.Range(MinMaxSpawnTimeUFO.x, MinMaxSpawnTimeUFO.y);
    }

    void Update() {
        timerMeteor += Time.deltaTime;
        timerUFO += Time.deltaTime;

        if (timerMeteor > spawntimeMeteor) {
            spawntimeMeteor = Random.Range(MinMaxSpawnTimeUFO.x, MinMaxSpawnTimeUFO.y);
            timerMeteor = 0;
            SpawnMeteor();
        }

        if (timerUFO > spawntimeUFO) {
            spawntimeUFO = Random.Range(MinMaxSpawnTimeUFO.x, MinMaxSpawnTimeUFO.y);
            timerUFO = 0;
            SpawnUFO();
        }
    }


    private void SpawnMeteor() {
        Instantiate(meteors[Random.Range(0, meteors.Length)], RandomSpawnPoint(), Quaternion.identity, PlayingField);
    }

    private void SpawnUFO() {
        Instantiate(uFO, RandomSpawnPoint(), Quaternion.identity, PlayingField);
    }

    private Vector2 RandomSpawnPoint() {
        Side edge = (Side)Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;

        if (edge == Side.Right) {
            spawnPoint.x = Screen.width;
            spawnPoint.y = Random.Range(0, Screen.height);
        } else
        if (edge == Side.Left) {
            spawnPoint.x = 0;
            spawnPoint.y = Random.Range(0, Screen.height);
        } else
        if (edge == Side.Up) {
            spawnPoint.y = Screen.height;
            spawnPoint.x = Random.Range(0, Screen.width);
        } else
        if (edge == Side.Down) {
            spawnPoint.y = 0;
            spawnPoint.x = Random.Range(0, Screen.width);
        } else {
            Debug.LogError("Кто трогал енум Side!? Верните правильнвй порядок: Right, Left, Up, Down. И никак иначе!");
        }
        return spawnPoint;
    }
}
