using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    [FormerlySerializedAs("_playerSpeed")] public float playerSpeed = 100f;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (!Mathf.Approximately(_movement.x, 0) || !Mathf.Approximately(_movement.y, 0))
        {
            MovePlayer(_movement);
        }

    }

    void MovePlayer(Vector2 newLocation)
    {
        _rigidbody2D.MovePosition((Vector2)transform.position + (newLocation * playerSpeed * Time.deltaTime));

    }
}
