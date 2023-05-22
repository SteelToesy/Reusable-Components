using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    void MoveHorizontal()
    {
        rb.velocity = new Vector2//(HorizontalWrapMode, VerticalWrapMode);
    }
}
