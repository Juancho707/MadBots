using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBallMovement : LowerPartMovement
{
    public BallRotation Ball;
    public float BallRotation;

    public override void Move()
    {
        myBody.AddForce(this.transform.forward * RollSpeed);
        Turn();
        Ball.Rotate(BallRotation);
    }

    protected override void FixedUpdate()
    {
        if (dashElapsed > 0)
        {
            dashElapsed -= Time.fixedDeltaTime;
            myBody.AddForce(this.transform.forward * DashForce);
            Ball.Rotate(BallRotation * 5);
        }
        else
        {
            if (myBody.velocity.magnitude > TopSpeed)
            {
                myBody.AddForce(-myBody.velocity.normalized * 900);
            }
        }
    }
}
