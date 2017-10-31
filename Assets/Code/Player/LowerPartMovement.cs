using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPartMovement : MonoBehaviour
{
    public Transform AimPoint;
    public float TurnSpeed;
    public float RollSpeed;

    private Rigidbody myBody;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody>();
    }

    public void Move()
    {
        myBody.AddForce(this.transform.forward * RollSpeed);
        Turn();
    }

    void Turn()
    {
        var transformedPos = this.transform.InverseTransformPoint(AimPoint.position);
        if (transformedPos.x > 0)
        {
            myBody.AddTorque(Vector3.up * TurnSpeed);
        }
        else
        {
            myBody.AddTorque(Vector3.up * -TurnSpeed);
        }
    }
}
