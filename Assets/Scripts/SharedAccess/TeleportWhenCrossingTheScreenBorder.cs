using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TeleportWhenCrossingTheScreenBorder
{
    public static Vector2 CheckingPosition(Vector2 position, Vector2 screenSize) {

        if (position.x > screenSize.x + 10) {
            return new Vector2(-5, position.y);
        } else if (position.x < -10) {
            return new Vector2(screenSize.x + 5, position.y);
        } else if (position.y > screenSize.y + 10) {
            return new Vector2(position.x, -5);
        } else if (position.y < -10) {
            return new Vector2(position.x, screenSize.y + 5);
        } else {
            return position;
        }
    }
}
