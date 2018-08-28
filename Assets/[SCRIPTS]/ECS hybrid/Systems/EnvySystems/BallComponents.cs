using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponents : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D _rigidBody2D = null;

    public Rigidbody2D Rigidbody2D
    {
        get { return _rigidBody2D; }
    }

    public void AddForce(Vector2 force)
    {
        _rigidBody2D.AddForce(force);
    }
}
