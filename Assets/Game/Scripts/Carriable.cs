using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriable : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    public float force = 10f;

    #endregion

    #region PRIVATE PROPERTIES

    private Rigidbody rigidbody;
    private bool isUsed;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Case") && !isUsed)
        {
            // tag = "Untagged";
            isUsed = true;
            var caseHandler = other.GetComponent<CaseHandler>();
            caseHandler.AddCarriable(rigidbody);
        }
    }

    #endregion

    #region PUBLIC METHODS

    public void GiveForce()
    {
        rigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }

    #endregion
}