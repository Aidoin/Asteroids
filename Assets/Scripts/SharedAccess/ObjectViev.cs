using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectViev : MonoBehaviour
{
    protected virtual void Update() {
        transform.position = TeleportWhenCrossingTheScreenBorder.CheckingPosition(new Vector2(transform.position.x, transform.position.y), new Vector2(Screen.width, Screen.height));
    }

    public virtual void Destruction() {
        Destroy(gameObject);
    }

    protected Vector2 SpeedNormalization(Vector2 speed) {

        return speed * (Screen.height / 1080f);
        //return new Vector2(speed.x / Screen.height, speed.y / Screen.height) * 1080;
    }

    protected float SpeedNormalization(float speed) {
        return speed * (Screen.height / 1080);
    }
}
