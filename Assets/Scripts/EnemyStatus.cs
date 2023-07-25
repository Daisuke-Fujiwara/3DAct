using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStatus
{
    [SerializeField] string enemyName;
    [SerializeField] int hP;
    [SerializeField] int mP;
    [SerializeField] int attack;
    [SerializeField] int defence;

    public string EnemyName { get => enemyName; set => enemyName = value; }
    public int HP { get => hP; set => hP = value; }
    public int MP { get => mP; set => mP = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Defence { get => defence; set => defence = value; }
}
