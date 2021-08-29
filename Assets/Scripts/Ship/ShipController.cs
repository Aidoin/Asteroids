using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipView))]


public class ShipController : MonoBehaviour
{
    [SerializeField] private ShipView view;
    private ShipModel model = new ShipModel();

    [SerializeField] private KeyCode MooveForward = KeyCode.W;
    [SerializeField] private KeyCode RotateRight = KeyCode.D;
    [SerializeField] private KeyCode RotateLeft = KeyCode.A;
    [SerializeField] private KeyCode Shot = KeyCode.Mouse0;
    [SerializeField] private KeyCode laserGun = KeyCode.Mouse1;


    private void Awake() {
        if (view == null) {
            view = GetComponent<ShipView>();
        }
        model.controller = this;
    }

    #region Input
    void Update() {
        model.Counter(Time.deltaTime);

        if (Input.GetKey(MooveForward)) {
            model.MoveForward(view.transform.up);
        } else {
            model.SlowingDown();
        }

        if (Input.GetKey(RotateRight) && Input.GetKey(RotateLeft)) { /*None*/ } else {
            if (Input.GetKey(RotateRight)) {
                model.Rotate(Side.Right);
            }
            if (Input.GetKey(RotateLeft)) {
                model.Rotate(Side.Left);
            }
        }

        if (Input.GetKey(Shot)) {
            model.ShotGun();
        }
        if (Input.GetKeyDown(laserGun)) {
            model.ShotLaser();
        }
    }

    public void Touched(GameObject other) {
        model.Touched(other);
    }

    #endregion


    #region Output
    /// <summary>
    /// Значение в процентах от 0% до 100%
    /// </summary>
    /// <param name="value"></param>
    public void SetValueLaserBar(float value) {
        if (value < 0 || value > 100) {
            Debug.LogError("Значение бара перезарядки лазера выходит за рамки диапазолна 0-100 и имеет значение: " + value);
            return;
        }
        view.SetValueLaserBar(value);
    }

    public void DisplayingNumberOfLaserCharges(int value) {
        view.DisplayingNumberOfLaserCharges(value);
    }

    public void ShotGun(float speedBullet, float bulletLifetime) {
        view.ShotGun(speedBullet, bulletLifetime);
    }

    public void ShotLaser() {
        view.ShotLaser();
    }

    public void SetSpeed(Vector2 vectorSpeed) {
        view.Moove(vectorSpeed);
    }

    public void Rotate(float angle) {
        view.Rotate(angle);
    }

    public void Destruction() {
        view.Destruction();
    }

    #endregion
}
