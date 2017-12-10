using UnityEngine;

public class SmokeBomb : SecondaryWeaponBase
{
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
            fireElapsed = Stats.RateOfFire;
        }
    }
}
