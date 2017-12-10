using UnityEngine;

public class RocketLauncher : PrimaryWeaponBase
{
    public Transform LaunchPosition;
    private GuidedKinematic rocket;

    void Start()
    {
        rocket = this.GetComponentInChildren<GuidedKinematic>();
        ResetRocket();
    }

    void FixedUpdate()
    {
        if (fireElapsed > 0)
        {
            fireElapsed -= Time.fixedDeltaTime;
            if (fireElapsed <= 0)
            {
                ResetRocket();
            }
        }
    }

    public override void Fire()
    {
        if (fireElapsed <= 0)
        {
            fireElapsed = Stats.RateOfFire;
            rocket.Launch();
        }
    }

    void ResetRocket()
    {
        rocket.gameObject.SetActive(true);
        rocket.transform.SetParent(this.transform);
        rocket.transform.position = LaunchPosition.position;
        rocket.transform.localEulerAngles = Vector3.zero;
    }
}
