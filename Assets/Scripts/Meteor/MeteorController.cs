using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeteorView))]


public class MeteorController : MonoBehaviour
{
    [SerializeField] private MeteorView view;
    private MeteorModel model = new MeteorModel();


    private void Awake() {
        if (view == null) {
            view = GetComponent<MeteorView>();
        }
        model.controller = this;
        model.DirectionMovement = new Vector2(Random.Range(-100, 101), Random.Range(-100, 101)).normalized;
    }

    #region Input
    private void Update() {
        model.Moove(Time.deltaTime);
    }

    public void Touched(GameObject other) {
        model.Touched(other);
    }

    public void SetMeteorSize(MeteorSize size) {
        model.CurrentMeteorSize = size;
    }

    public void AddSpeedToFragment(float value) {
        model.AdditionalSpeedOfFragment += value;
    }

    #endregion


    #region Output
    public void Moove(Vector2 mooveVector) {
        view.Moove(mooveVector);
    }

    public void Destruction() {
        view.Destruction();
    }

    public void AddPoints(int value) {
        FindObjectOfType<Score>().AddPoints(value);
    }

    public void CreateMeteors(MeteorSize size, float additionalSpeed) {
        view.CreateMeteors(size, additionalSpeed);
    }

    #endregion
}
