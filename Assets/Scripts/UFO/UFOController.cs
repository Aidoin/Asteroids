using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UFOView))]

public class UFOController : MonoBehaviour
{
    [SerializeField] private UFOView view;
    private UFOModel model = new UFOModel();
    private Transform player;

    #region Input
    private void Awake() {
        if (view == null) {
            view = GetComponent<UFOView>();
        }
        model.controller = this;
    }

    private void Start() {
        model.ChangingPath();
        if (FindObjectOfType<ShipView>()) {
            player = FindObjectOfType<ShipView>().transform;
        }
    }

    private void Update() {
        model.Counter(Time.deltaTime);

        if (player == null) {
            if (FindObjectOfType<ShipView>()) {
                player = FindObjectOfType<ShipView>().transform;
                model.Moove(transform, player.transform);
            } else {
                model.Moove(transform, null);
            }
        } else {
            model.Moove(transform, player.transform);
        }
    }

    public void Touched(GameObject other) {
        model.Touched(other);
    }

    #endregion

    #region Output
    public void Moove(Vector2 vectorSpeed) {
        view.Moove(vectorSpeed);
    }

    public void Shot(Vector2 directionOfShot, float speedBullet, float bulletLifetime) {
        view.Shot(directionOfShot, speedBullet, bulletLifetime);
    }

    public void Destruction() {
        view.Destruction();
    }

    public void AddPoints(int value) {
        FindObjectOfType<Score>().AddPoints(value);
    }
    #endregion
}
