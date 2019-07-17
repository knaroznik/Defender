using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase
{
    public abstract Color GetColor();
    public abstract ObjectType GetBulletType();
}

public enum ObjectType { RED, WHITE, GREEN, BLUE}
