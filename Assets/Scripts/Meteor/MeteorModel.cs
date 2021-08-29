using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeteorModel
{
    public MeteorController controller;
    public Vector2 DirectionMovement;
    public MeteorSize CurrentMeteorSize;
    public float AdditionalSpeedOfFragment;


    public void Moove(float elapsedTime) {
        controller.Moove(DirectionMovement * (MeteorValues.Speed + AdditionalSpeedOfFragment) * elapsedTime);
    }

    public void Touched(GameObject other) {
        // Если метеор не самого малого размера то создаются его осколки
        if ((int)CurrentMeteorSize < Enum.GetNames(typeof(MeteorSize)).Length - 1) {
            CreateMeteors(MeteorValues.NumberFragments, (MeteorSize)(int)CurrentMeteorSize + 1);
        }
        controller.Destruction();
        AddPoints();
    }

    private void AddPoints() {
        controller.AddPoints(MeteorValues.Points[(int)CurrentMeteorSize]);
    }

    private void CreateMeteors(int count, MeteorSize size) {
        for (int i = 0; i < count; i++) {
            controller.CreateMeteors(size, AdditionalSpeedOfFragment + MeteorValues.AdditionalSpeedOfFragments);
        }
    }
}
