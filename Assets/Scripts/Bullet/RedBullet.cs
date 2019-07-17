using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : BulletBase
{
    public override ObjectType GetBulletType()
    {
        return ObjectType.RED;
    }

    public override Color GetColor()
    {
        return Color.red;
    }
}
