using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Groups))]


public class Laser : Projectile
{
    private void Start() {
        Destroy(gameObject, 0.1f);
    }

    protected override void Hit(Collision2D collisions) {
        // none
    }
}
