using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipModel
{
    public ShipController controller;
    private Vector2 velocity;
    private int laserCharges = ShipValues.MaxNumberOfLaserCharges;
    private float laserTimer;
    private bool laserIsReady = true;
    private float shotTimer;
    private bool shotIsReady = true;
    private float elapsedTime;


    public void MoveForward(Vector2 forward) {
        velocity += forward * ShipValues.IncreasingSpeed * elapsedTime;

        if (velocity.magnitude > ShipValues.MaxSpeed) {
            velocity = velocity.normalized * ShipValues.MaxSpeed;
        }
        controller.SetSpeed(velocity);
    }

    public void SlowingDown() {
        velocity = Vector2.Lerp(velocity, Vector2.zero, ShipValues.SpeedReduction * elapsedTime);
        controller.SetSpeed(velocity);
    }

    public void Rotate(Side side) {
        if (side == Side.Left) {
            controller.Rotate(ShipValues.TurningSpeed * elapsedTime);
        } else if (side == Side.Right) {
            controller.Rotate(-ShipValues.TurningSpeed * elapsedTime);

        } else {
            Debug.LogError("Действие для поворота " + side + " не назначено");
        }
    }

    public bool ShotGun() {
        if (shotIsReady == false) {
            return false;
        }

        controller.ShotGun(ShipValues.SpeedBullet, ShipValues.BulletLifetime);
        shotIsReady = false;
        shotTimer = 0;
        return true;
    }

    public bool ShotLaser() {
        if (laserCharges < 1) {
            return false;
        }

        laserCharges--;
        controller.ShotLaser();
        controller.SetValueLaserBar(0);
        controller.DisplayingNumberOfLaserCharges(laserCharges);
        return true;
    }

    public void Touched(GameObject other) {
        controller.Destruction();
    }


    public void Counter(float elapsedTime) {
        this.elapsedTime = elapsedTime;

        if (shotIsReady == false) {
            if (shotTimer < ShipValues.ShotInterval) {
                shotTimer += elapsedTime;
            } else {
                shotIsReady = true;
            }
        }

        if (laserCharges < ShipValues.MaxNumberOfLaserCharges) {
            if (laserTimer < ShipValues.LaserRechargeTime) {
                laserTimer += elapsedTime;

                if (laserTimer > ShipValues.LaserRechargeTime) laserTimer = ShipValues.LaserRechargeTime;
                controller.SetValueLaserBar(laserTimer / ShipValues.LaserRechargeTime * 100);
            } else {
                laserCharges++;
                laserTimer = 0;
                controller.SetValueLaserBar(0);
                controller.DisplayingNumberOfLaserCharges(laserCharges);
            }
        }
    }

    public void UpdateUI() {
        controller.SetValueLaserBar(100);
        controller.DisplayingNumberOfLaserCharges(laserCharges);
    }
}
