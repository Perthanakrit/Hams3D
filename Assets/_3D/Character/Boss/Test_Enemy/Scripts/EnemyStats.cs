using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float Hp;
    public float walkSpeed;
    public float runSpeed;
    public float attackRate;
    public float damage;
    public int searcherDuration;
    public int searchTurnSpeed;
}
