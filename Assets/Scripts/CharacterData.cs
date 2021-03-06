using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "CustomScripts/Character")]
public class CharacterData : ScriptableObject
{
    public new string name;
    public int maxHp;
    public int strength;
    public int defense;
    public int intelligence;
    public int movementCase;
    [Tooltip("Chances for the attack to succeed. Must be between 0 and 1")]
    public float precision;
    [Tooltip("Description stats du personnage")]
    public string Description;

    private float currentHp;
    private float currentPosition;

    public int HP
    {
        get
        {
            return Mathf.RoundToInt(currentHp);
        }
    }

    public int Move
    {
        get
        {
            return Mathf.RoundToInt(currentPosition);
        }
    }

    void OnEnable()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(float damage)
    {
        currentHp = Mathf.Max(currentHp - damage, 0);
    }

    public void Heal(float health)
    {
        currentHp = Mathf.Min(maxHp, currentHp + health);
    }

    public void Movement()
    {
        currentPosition += movementCase;
    }
}


