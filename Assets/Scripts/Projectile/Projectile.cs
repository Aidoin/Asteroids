using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Groups))]


public class Projectile : ObjectViev
{
    [SerializeField] private Groups group;


    private void Awake() {
        if (group == null) {
            group = GetComponent<Groups>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collisions) {
        if (Groups.CheckingCollision(collisions, group.MyGroup)) {
            Hit(collisions);
        }
    }

    protected virtual void Hit(Collision2D collisions) {
        Destroy(gameObject);
    }
}
