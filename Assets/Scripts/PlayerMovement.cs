using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSaber _playerSaber;
    
    [SerializeField] private Rigidbody2D _rigidbody2D;
    
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float dashSpeed = 2f;
    private float timeRemaining = 0.15f;
    
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        if (Input.GetKey(KeyCode.Space))
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                _rigidbody2D.velocity = movement * (dashSpeed * (moveSpeed * Time.deltaTime));
            }
            else if (timeRemaining <= 0)
            {
                _rigidbody2D.velocity = movement * (moveSpeed * Time.deltaTime);
            }
            
        }
        else
        {
            _rigidbody2D.velocity = movement * (moveSpeed * Time.deltaTime);
            timeRemaining = 0.15f;
        }
        
    }

    private void Update()
    {
        if (_playerSaber.saberOn)
        {
            moveSpeed = 75f;
        }
        else if (!_playerSaber.saberOn)
        {
            moveSpeed = 250f;
        }
    }
}
