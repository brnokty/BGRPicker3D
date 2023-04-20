using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriable : MonoBehaviour
{
    public float force = 10f;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void GiveForce()
    {
        rigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Case"))
        {
            // tag = "Untagged";
            var caseHandler = other.GetComponent<CaseHandler>();
            caseHandler.AddCarriable(rigidbody);
        }

        // if (other.CompareTag("Finish"))
        // {
        //     tag = "Untagged";
        //     other.GetComponent<FinishHandler>().FinishEffect(transform);
        // }
    }
}