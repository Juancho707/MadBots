using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPartMovement : MonoBehaviour
{
    public Transform AimPoint;
    [HideInInspector]public float TurnSpeed;
    [HideInInspector] public float RollSpeed;
    public float DashForce;
    public float DashDuration;
    public float TopSpeed;
    public float DashCooldown;

    protected bool dashIsCoolingDown;
    protected float dashElapsed;
    protected float dashCooldownElapsed;
    protected Rigidbody myBody;

    protected void Start()
    {
        myBody = this.GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        if (dashIsCoolingDown)
        {
            dashCooldownElapsed -= Time.fixedDeltaTime;
            if (dashCooldownElapsed < 0)
            {
                dashIsCoolingDown = false;
            }
        }
        if (dashElapsed > 0)
        {
            dashElapsed -= Time.fixedDeltaTime;
            myBody.AddForce(this.transform.forward * DashForce);
            if (dashElapsed < 0)
            {
                dashIsCoolingDown = true;
                dashCooldownElapsed = DashCooldown;
            }
        }
        else
        {
            {
                if (myBody.velocity.magnitude > TopSpeed)
                {
                    myBody.AddForce(-myBody.velocity.normalized * 900);
                }
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
        if (!dashIsCoolingDown)
        {
            dashElapsed = DashDuration;
            dashIsCoolingDown = true;
            dashCooldownElapsed = DashCooldown;
        }
    }

    protected void Turn()
    {
        this.transform.LookAt(AimPoint);
        //var rot = this.transform.eulerAngles;
        //rot.y = 0;
        //this.transform.eulerAngles = rot;


        //var transformedPos = this.transform.InverseTransformPoint(AimPoint.position);
        //if (transformedPos.x > 0)
        //{
        //    myBody.AddTorque(Vector3.up * TurnSpeed);
        //}
        //else
        //{
        //    myBody.AddTorque(Vector3.up * -TurnSpeed);
        //}
    }
}
