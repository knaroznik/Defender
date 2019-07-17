using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : BulletBase
{
    public override ObjectType GetBulletType()
    {
        return ObjectType.BLUE;
    }

    public override Color GetColor()
    {
        return Color.blue;
    }
}
