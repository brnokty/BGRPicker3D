﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float lerpSpeed = 5f;
    public float speed = 5f;
    public float horizontalSpeed = 5f;
    public float maxHorizontalDistance = 3f;
    public ScreenSpaceJoytick screenSpaceJoytick;
    private bool isFinished = false;
    private bool isStarted = false;
    private bool isEnteredCase = false;
    private bool isMouseDown = false;
    private Vector3 mouseStartPosition;
    private Vector3 lastMouseStartPosition;
    private float horizontalDelta = 0f;


    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MainManager.Instance.EventManager.Register(EventTypes.KeepMove, KeepMove);
    }

    void FixedUpdate()
    {
        if (!isFinished && !isEnteredCase)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        var velocity = rigidbody.velocity;
        velocity = new Vector3(screenSpaceJoytick.Horizontal * horizontalSpeed, velocity.y,
            speed);
        rigidbody.velocity = velocity;

        Vector3 position;
        position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, -maxHorizontalDistance,
                maxHorizontalDistance),
            (position = rigidbody.position).y,
            position.z);
        rigidbody.position = position;
    }

    private void StopPlayer()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    // Finish Trigger'ına çarpıldığında tetiklenecek olan metot
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && !isFinished)
        {
            isFinished = true;
            StopPlayer();
            var objects = Physics.BoxCastAll(throwCollider.bounds.center, throwCollider.transform.localScale,
                throwCollider.transform.forward,
                throwCollider.transform.rotation, 2);
            other.gameObject.GetComponent<FinishHandler>().FinishEffect(objects);
            // ThrowBalls();
            // MainManager.Instance.EventRunner.Win();
        }

        if (other.CompareTag("CaseEnter"))
        {
            StopPlayer();
            other.enabled = false;
            isEnteredCase = true;
            print("Entered - " + other.name);
            ThrowBalls();
        }
    }


    [SerializeField] private Collider throwCollider;

    private void ThrowBalls()
    {
        var objects = Physics.BoxCastAll(throwCollider.bounds.center, throwCollider.transform.localScale,
            throwCollider.transform.forward,
            throwCollider.transform.rotation, 2);
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].collider.CompareTag("Carriable"))
            {
                objects[i].collider.GetComponent<Carriable>().GiveForce();
            }
        }
    }

    private void KeepMove(EventArgs args)
    {
        isEnteredCase = false;
    }
}