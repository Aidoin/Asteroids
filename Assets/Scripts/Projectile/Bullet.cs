using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : Projectile
{
    public float speedBullet = 700;


    protected override void Update() {
        base.Update();
        transform.Translate(SpeedNormalization(Vector3.up * speedBullet * Time.deltaTime));
    }
}
