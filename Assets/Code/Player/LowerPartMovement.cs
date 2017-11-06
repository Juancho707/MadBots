using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPartMovement : MonoBehaviour
{
    public Transform AimPoint;
    public float TurnSpeed;
    public float RollSpeed;
    public float DashForce;
    public float DashDuration;
    public float TopSpeed;

    protected float dashElapsed;
    protected Rigidbody myBody;

    protected void Start()
    {
        myBody = this.GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        if (dashElapsed > 0)
        {
            dashElapsed -= Time.fixedDeltaTime;
            myBody.AddForce(this.transform.forward * DashForce);
        }
        else
        {
            if (myBody.velocity.magnitude > TopSpeed)
            {
                myBody.AddForce(-myBody.velocity.normalized * 900);
            }
        }
    }

    public virtual void Move()
    {
        myBody.AddForce(this.transform.forward * RollSpeed);
        Turn();
    }

    public void DashForward()
    {
        dashElapsed = DashDuration;
    }

    protected void Turn()
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
