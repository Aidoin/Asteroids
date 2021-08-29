using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletUFO : Projectile
{
    public Vector2 direction;
    public float speedBullet = 500;


    protected override void Update() {
        base.Update();
        transform.Translate(SpeedNormalization(new Vector3(direction.x, direction.y, 0) * speedBullet * Time.deltaTime));
    }
}
