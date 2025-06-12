using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pen", menuName = "Scriptable Pen")]
public class ScriptablePen : ScriptableObject
{
    public Pen Pen;

    public ScriptableAnimal Animal;

    public BasePen penPrefab;
}

public enum Pen
{
    pig,
    cow,
    sheep,
    duck,
    horse,
    hen
}