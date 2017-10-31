using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperPartMovement : MonoBehaviour
{
    public Transform AimPoint;
    public float TurnSpeed;

    public void Move()
    {
        Turn();
    }

    void Turn()
    {
        var transformedPos = this.transform.InverseTransformPoint(AimPoint.position);
        if (transformedPos.x > 0)
        {
            this.transform.Rotate(Vector3.up * TurnSpeed);
        }
        else
        {
            this.transform.Rotate(Vector3.up * -TurnSpeed);
        }
    }
}
