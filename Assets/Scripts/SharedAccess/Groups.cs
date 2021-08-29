using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Group
{
    Other,
    Player,
    Enemy
}

[RequireComponent(typeof(Rigidbody2D))]


public class Groups : MonoBehaviour
{
    [SerializeField] private Group myGroup; public Group MyGroup => myGroup;


    private void Awake() {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        rigidbody.gravityScale = 0;
        rigidbody.angularDrag = 0;
        rigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    public static bool CheckingCollision(Collision2D collisions, Group group) {
        if (collisions.rigidbody) {
            if (collisions.rigidbody.GetComponent<Groups>()) {
                if (collisions.rigidbody.GetComponent<Groups>().MyGroup == group) {
                    return false;
                } else { 
                    return true; 
                }
            } else {
                Debug.LogError("Не назначенно столкновение с объектами без Collisions");
                return false;
            }
        } else {
            Debug.LogError("Не назначенно столкновение с объектами без Rigidbody2D");
            return false;
        }
    }
}
