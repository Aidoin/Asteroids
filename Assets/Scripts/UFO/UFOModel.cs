using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOModel
{
    public UFOController controller;
    private Vector2 direction; public Vector2 Velocity => direction;
    private float elapsedTime;
    private float travelTime;
    private float pathChangeInterval;
    private float shotTimer;
    private bool playerIsExists = false;


    public void Counter(float elapsedTime) {
        this.elapsedTime = elapsedTime;
        travelTime += elapsedTime;

        // Shot time
        if (shotTimer < UFOValues.ShotInterval) {
            shotTimer += elapsedTime;
        } else {
            if (playerIsExists) {
                Shot();
            }
        }
    }

    public void Moove(Transform me, Transform player) {

        if (player == null) {
            playerIsExists = false;

            if (travelTime > pathChangeInterval)
                ChangingPath();
        } else {
            playerIsExists = true;
            direction = (player.position - me.position).normalized;
        }
        controller.Moove(direction * UFOValues.Speed * elapsedTime);
    }

    public void Shot() {
        controller.Shot(direction, UFOValues.SpeedBullet, UFOValues.BulletLifetime);
        shotTimer = 0;
    }

    public void ChangingPath() {
        pathChangeInterval = Random.Range(0f, UFOValues.MaxTimeBeforeChangingPath);
        travelTime = 0f;
        direction = new Vector2(Random.Range(-100, 101), Random.Range(-100, 101)).normalized;
    }

    public void Touched(GameObject other) {
        controller.Destruction();
        AddPoints();
    }

    private void AddPoints() {
        controller.AddPoints(UFOValues.Points);
    }
}
