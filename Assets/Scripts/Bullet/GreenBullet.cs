using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : BulletBase
{
    public override ObjectType GetBulletType()
    {
        return ObjectType.GREEN;
    }

    public override Color GetColor()
    {
        return Color.green;
    }
}
