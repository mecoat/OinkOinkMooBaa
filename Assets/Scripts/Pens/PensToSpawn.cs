using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PensToSpawn
{
    public ScriptablePen pen;
    public SpawnSite spawnSite;
    public int noAnimals;
}

public enum SpawnSite
{
    leftWhole,
    leftTop,
    leftBottom,
    rightWhole,
    rightTop,
    rightBottom,
    top,
    bottom
}
