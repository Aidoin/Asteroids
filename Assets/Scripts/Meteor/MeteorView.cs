using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeteorController))]
[RequireComponent(typeof(Groups))]


public class MeteorView : ObjectViev
{
    [SerializeField] private MeteorSize currentMeteorSize = MeteorSize.Big;
    [SerializeField] private GameObject[] Meteors;
    [SerializeField] private MeteorController controller;
    [SerializeField] private Groups group;
    [SerializeField] private AudioSource deathAudio;


    private void Awake() {
        if (group == null) {
            group = GetComponent<Groups>();
        }

        if (controller == null) {
            controller = GetComponent<MeteorController>();
        }
    }

    private void Start() {
        controller.SetMeteorSize(currentMeteorSize);
    }


    public void Moove(Vector2 mooveVector) {
        transform.Translate(SpeedNormalization(mooveVector));
    }

    private void OnCollisionEnter2D(Collision2D collisions) {
        if (Groups.CheckingCollision(collisions, group.MyGroup)) {
            controller.Touched(collisions.rigidbody.gameObject);
        }
    }

    public void CreateMeteors(MeteorSize size, float additionalSpeed) {
        MeteorView newMeteor = Instantiate(Meteors[(int)size], transform.position, transform.rotation, transform.parent).GetComponent<MeteorView>();
        newMeteor.currentMeteorSize = size;
        newMeteor.AddSpeedToFragment(additionalSpeed);
    }

    public void AddSpeedToFragment(float value) {
        controller.AddSpeedToFragment(value);
    }

    public override void Destruction() {
        base.Destruction();
        deathAudio.gameObject.transform.parent = null;
        deathAudio.Play();
    }
}
