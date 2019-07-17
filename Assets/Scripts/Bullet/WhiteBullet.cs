using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBullet : BulletBase
{
    public override ObjectType GetBulletType()
    {
        return ObjectType.WHITE;
    }

    public override Color GetColor()
    {
        return Color.white;
    }
}
