using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ShipController))]
[RequireComponent(typeof(Groups))]


public class ShipView : ObjectViev
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject laser;
    [SerializeField] private Transform[] guns;
    [SerializeField] private ShipController controller;
    [SerializeField] private Groups group;
    [SerializeField] private AudioSource laserAudio;
    [SerializeField] private AudioSource shotAudio;
    [SerializeField] private AudioSource deathAudio;

    [Header("UI")]
    [SerializeField] private Text coordinates;
    [SerializeField] private Text rotationAngle;
    [SerializeField] private Text speed;
    [SerializeField] private Image LaserBar;
    [SerializeField] private List<GameObject> numberOfLaserCharges;


    private void Awake() {
        if (group == null) {
            group = GetComponent<Groups>();
        }

        if (controller == null) {
            controller = GetComponent<ShipController>();
        }
    }

    private void Start() {
        DisplayingRotationAngle(transform.rotation.z);
        DisplayingSpeed(0);
        DisplayingCoordinates(transform.position);
        DisplayingNumberOfLaserCharges(ShipValues.MaxNumberOfLaserCharges);
        SetValueLaserBar(0);
    }

    public void ShotLaser() {
        for (int i = 0; i < guns.Length; i++) {
            Instantiate(laser, guns[i].position, transform.rotation, transform.parent);
            laserAudio.Play();
        }
    }

    public void ShotGun(float speedBullet, float bulletLifetime) {
        for (int i = 0; i < guns.Length; i++) {
            GameObject newBullet = Instantiate(bullet, guns[i].position, transform.rotation, transform.parent);
            newBullet.GetComponent<Bullet>().speedBullet = speedBullet;
            Destroy(newBullet, bulletLifetime);
            shotAudio.Play();
        }
    }

    public void Moove(Vector2 vectorSpeed) {
        Vector2 speedNormalization = SpeedNormalization(vectorSpeed);
        transform.position = transform.position + new Vector3(speedNormalization.x, speedNormalization.y, 0);
        DisplayingCoordinates(transform.position);
        DisplayingSpeed(vectorSpeed.magnitude);
    }

    public void Rotate(float angle) {
        transform.Rotate(Vector3.forward, angle);
        DisplayingRotationAngle((int)transform.eulerAngles.z);
    }

    private void OnCollisionEnter2D(Collision2D collisions) {
        if (Groups.CheckingCollision(collisions, group.MyGroup)) {
            controller.Touched(collisions.rigidbody.gameObject);
        }
    }


    public void DisplayingNumberOfLaserCharges(int value) {
        if (value > numberOfLaserCharges.Count) {
            int difference = value - numberOfLaserCharges.Count;
            for (int i = 0; i < difference; i++) {
                numberOfLaserCharges.Add(Instantiate(numberOfLaserCharges[0], numberOfLaserCharges[0].transform.parent));
            }
        }

        for (int i = 0; i < numberOfLaserCharges.Count; i++) {
            if (i > value - 1) {
                numberOfLaserCharges[i].SetActive(false);
            } else {
                numberOfLaserCharges[i].SetActive(true);
            }
        }
    }
    public void SetValueLaserBar(float value) {
        LaserBar.fillAmount = value / 100;
    }
    private void DisplayingCoordinates(Vector2 position) {
        coordinates.text = "x" + (int)position.x + " y" + (int)position.y;
    }
    public void DisplayingSpeed(float value) {
        speed.text = ((int)(value * 100)).ToString();
    }
    public void DisplayingRotationAngle(float angle) {
        rotationAngle.text = angle + "°";
    }

    public override void Destruction() {
        base.Destruction();
        deathAudio.gameObject.transform.parent = null;
        deathAudio.Play();
    }
}
