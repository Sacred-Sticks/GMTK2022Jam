using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCursor : MonoBehaviour
{
    [SerializeField] private PlayerInputs input;
    [SerializeField] private Vector2 levelSize;
    [SerializeField] private Vector3 offset;

    Vector3 aimLocation;

    private void Update()
    {
        aimLocation = new Vector3(input.GetAim().x/Screen.width * levelSize.x, input.GetAim().y/Screen.height * levelSize.y, transform.position.z);
        transform.position = aimLocation + offset;
    }
}
