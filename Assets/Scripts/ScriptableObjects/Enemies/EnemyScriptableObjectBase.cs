using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemyScriptableObjectBase : ScriptableObject
{
    public Animator animator;

    public float maxHealth;
    public float currentHealth;
    public float moveSpeed;
    public float damage;
    public float playerRange;
    public float attackRange;

    public string EnemyType; //Decomposable, NonDecomposable, Recyclable
}
