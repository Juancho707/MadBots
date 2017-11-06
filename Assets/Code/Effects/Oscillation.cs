using UnityEngine;

public class Oscillation : MonoBehaviour
{
    public float OscillatorFactor;
    public float OscillatorFrequency;
    private float angle = 0f;
    private float originalY;

	// Use this for initialization
	void Start ()
	{
	    originalY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var oscillation = OscillatorFactor * Mathf.Sin(angle);
	    var newPos = transform.position;
        newPos.y = originalY + oscillation;
	    this.transform.position = newPos;

	    this.angle += OscillatorFrequency;
	}
}
