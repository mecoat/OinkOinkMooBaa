using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Scriptable Animal")]
public class ScriptableAnimal : ScriptableObject
{
    public Animal Animal;

    public BaseAnimal animalPrefab;

    public AudioClip animalSound;

}
public enum Animal
{
    pig,
    cow,
    sheep,
    duck,
    horse,
    hen
}