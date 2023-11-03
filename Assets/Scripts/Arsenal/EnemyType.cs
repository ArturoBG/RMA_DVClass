using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Enemies/Type", order = 1)]
public class EnemyType : ScriptableObject
{
    public int Damage;
    public int TotalHealth;
    public float Speed;
    public float timerToDamage;

}
