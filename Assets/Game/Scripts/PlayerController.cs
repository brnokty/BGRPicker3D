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
        if (other.CompareTag("Finish"))
        {
            isFinished = true;
            StopPlayer();
        }

        if (other.CompareTag("CaseEnter"))
        {
            StopPlayer();
            other.enabled = false;
            isEnteredCase = true;
            print("Entered - " + other.name);
        }
    }
}