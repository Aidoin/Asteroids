using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UFOController))]
[RequireComponent(typeof(Groups))]


public class UFOView : ObjectViev
{
    [SerializeField] private UFOController controller;
    [SerializeField] private GameObject bulletUFO;
    [SerializeField] private Groups group;
    [SerializeField] private AudioSource shotAudio;
    [SerializeField] private AudioSource deathAudio;



    private void Awake() {
        if (group == null) {
            group = GetComponent<Groups>();
        }

        if (controller == null) {
            controller = GetComponent<UFOController>();
        }
    }

    public void Moove(Vector2 vectorSpeed) {
        transform.Translate(SpeedNormalization(vectorSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collisions) {
        if (Groups.CheckingCollision(collisions, group.MyGroup)) {
            controller.Touched(collisions.rigidbody.gameObject);
        }
    }

    public void Shot(Vector2 directionOfShot, float speedBullet, float bulletLifetime) {
        GameObject newBullet = Instantiate(bulletUFO, transform.position, transform.rotation, transform.parent);
        newBullet.GetComponent<BulletUFO>().speedBullet = speedBullet;
        newBullet.GetComponent<BulletUFO>().direction = directionOfShot;
        Destroy(newBullet, bulletLifetime);
        shotAudio.Play();
    }

    public override void Destruction() {
        base.Destruction();
        deathAudio.gameObject.transform.parent = null;
        deathAudio.Play();
    }
}
