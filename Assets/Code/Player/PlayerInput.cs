using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Transform LowerAimPoint;
    public Transform UpperAimPoint;
    public UpperPartMovement UpperMover;
    public float DeadZone;
    public float SeparationFactor;

    private LowerPartMovement lowerMover;

    // Use this for initialization
    void Start ()
    {
        lowerMover = this.GetComponent<LowerPartMovement>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    var lAxis = new Vector2(Input.GetAxis("LowerHoriz"), Input.GetAxis("LowerVert"));
	    if (lAxis.magnitude > DeadZone)
	    {
	        LowerAimPoint.position = this.transform.position + new Vector3(lAxis.x, 0f, lAxis.y) * SeparationFactor;
            lowerMover.Move();
	    }

        var uAxis = new Vector2(Input.GetAxis("UpperHoriz"), Input.GetAxis("UpperVert"));
	    if (uAxis.magnitude > DeadZone)
	    {
	        UpperAimPoint.position = this.transform.position + new Vector3(uAxis.x, 0f, uAxis.y) * SeparationFactor;
            UpperMover.Move();
	    }
    }
}
