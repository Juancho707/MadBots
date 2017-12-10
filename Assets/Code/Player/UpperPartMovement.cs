using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperPartMovement : MonoBehaviour
{
    public Transform AimPoint;
    public float TurnSpeed;
    public float AimTolerance;

    public void Move()
    {
        Turn();
    }

    void Turn()
    {
        this.transform.LookAt(AimPoint);
        //var rot = this.transform.eulerAngles;
        //rot.y = 0;
        //this.transform.eulerAngles = rot;

        //var transformedPos = this.transform.InverseTransformPoint(AimPoint.position);
        //if (transformedPos.x > AimTolerance)
        //{
        //    this.transform.Rotate(Vector3.up * TurnSpeed);
        //}
        //else if (transformedPos.x < -AimTolerance)
        //{
        //    this.transform.Rotate(Vector3.up * -TurnSpeed);
        //}
    }
}
