using UnityEngine;

public class GatlingGun : WeaponBase
{
    public Rotator BarrelRotator;
    public ParticleSystem Muzzle;
    private AudioSource GunClip;

    public GameObject ShotHitPf;
    public GameObject ShotLinePf;

    private float fireElapsed;

    void Start()
    {
        GunClip = this.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (fireElapsed > 0)
        {
            fireElapsed -= Time.fixedDeltaTime;
        }
    }

    public override void Fire()
    {
        if(fireElapsed <= 0)
        {
            Muzzle.Emit(1);
            fireElapsed = Stats.RateOfFire;
            BarrelRotator.StartRotating();
            GunClip.Play();
        
        RaycastHit hit;
        var dir = this.transform.forward * 10;
        dir.x += Random.Range(-Stats.Inaccuracy, Stats.Inaccuracy);
        dir.y += Random.Range(-Stats.Inaccuracy, Stats.Inaccuracy);
        dir.z += Random.Range(-Stats.Inaccuracy, Stats.Inaccuracy);

        var ray = new Ray(Muzzle.transform.position, dir);
        if (Physics.Raycast(ray, out hit, Stats.Range))
        {
            DisplayGunshot(hit.point);
            Instantiate(ShotHitPf, hit.point, Quaternion.identity);
            Push(hit);
        }
        else
        {
            DisplayGunshot(ray.GetPoint(Stats.Range));
        }
        }
    }

    void DisplayGunshot(Vector3 pos2)
    {
        var line = Instantiate(ShotLinePf, Muzzle.transform.position, Quaternion.identity).GetComponent<LineRenderer>();
        line.SetPosition(0, Muzzle.transform.position);
        line.SetPosition(1, pos2);
    }

    void Push(RaycastHit hit)
    {
        if (hit.collider.tag.Equals("Physical"))
        {
            var body = hit.collider.GetComponent<Rigidbody>();
            var pushVector = body.transform.position + Vector3.Lerp(hit.point, body.transform.position, 1);
            body.AddForce(pushVector * Stats.PushForce);
        }
    }
}
