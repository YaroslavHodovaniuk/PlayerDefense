using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        Instantiate(Bullet, shootPoint.position, new Quaternion(0, 0, 0.5f, 17));
        Instantiate(Bullet, shootPoint.position, new Quaternion(0, 0, -0.5f, 17));
    }
}
