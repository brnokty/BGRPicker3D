using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [SerializeField] private float speed = 5f;
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float maxHorizontalDistance = 3f;
    [SerializeField] private ScreenSpaceJoytick screenSpaceJoytick;

    [SerializeField] private float failTime = 0.5f;
    [SerializeField] private Collider throwCollider;
    [SerializeField] private LayerMask carriableLayerMask;

    #endregion

    #region PRIVATE PROPERTIES

    private bool isFinished = false;
    private bool isStarted = false;
    private bool isEnteredCase = false;
    private bool isMouseDown = false;
    private Vector3 mouseStartPosition;
    private Vector3 lastMouseStartPosition;
    private float horizontalDelta = 0f;
    private Rigidbody rigidbody;

    #endregion

    #region UNITY METHODS

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MainManager.Instance.EventManager.Register(EventTypes.KeepMove, KeepMove);
        MainManager.Instance.EventManager.Register(EventTypes.LevelStart, StartPlayer);
    }

    void FixedUpdate()
    {
        if (!isStarted)
            return;

        if (!isFinished && !isEnteredCase)
        {
            MovePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && !isFinished)
        {
            isFinished = true;
            StopPlayer();
            var objects = Physics.BoxCastAll(throwCollider.bounds.center, throwCollider.transform.localScale,
                throwCollider.transform.forward,
                throwCollider.transform.rotation, 2, carriableLayerMask);
            other.gameObject.GetComponent<FinishHandler>().FinishEffect(objects);
        }

        if (other.CompareTag("CaseEnter"))
        {
            StopPlayer();
            other.enabled = false;
            isEnteredCase = true;
            ThrowBalls(other.transform.parent.GetComponent<CaseHandler>());
        }
    }

    #endregion

    #region PRIVATE METHODS

    private void MovePlayer()
    {
        var velocity = rigidbody.velocity;
        velocity = new Vector3(screenSpaceJoytick.Horizontal * horizontalSpeed, 0, speed);
        rigidbody.velocity = velocity;

        Vector3 position = rigidbody.position;
        position = new Vector3(Mathf.Clamp(rigidbody.position.x, -maxHorizontalDistance, maxHorizontalDistance), 0,
            position.z);
        rigidbody.position = position;
    }

    private void StartPlayer(EventArgs args)
    {
        isStarted = true;
    }

    private void StopPlayer()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    private void ThrowBalls(CaseHandler caseHandler)
    {
        var objects = Physics.BoxCastAll(throwCollider.bounds.center, throwCollider.transform.localScale,
            throwCollider.transform.forward,
            throwCollider.transform.rotation, 2, carriableLayerMask);

        print("Count ->" + objects.Length);

        if (objects.Length <= 0 || objects.Length < caseHandler.requiredCarriableCount)
        {
            StartCoroutine(WaitAndFail(failTime));
            return;
        }

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].collider.CompareTag("Carriable"))
            {
                objects[i].collider.GetComponent<Carriable>().GiveForce();
            }
        }
    }

    private IEnumerator WaitAndFail(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        MainManager.Instance.EventRunner.Fail();
    }

    private void KeepMove(EventArgs args)
    {
        isEnteredCase = false;
    }

    #endregion
}