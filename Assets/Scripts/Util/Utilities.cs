using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Vector3 ScreenToWorldPosition(Vector3 position)
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(position);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
}
