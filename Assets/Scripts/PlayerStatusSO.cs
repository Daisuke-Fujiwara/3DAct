using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu]
public class PlayerStatusSO : ScriptableObject
{
    [SerializeField] int hP;
    [SerializeField] int mP;
    [SerializeField] int attack;
    [SerializeField] int defence;

    public int HP { get => hP; }
    public int MP { get => mP; }
    public int Attack { get => attack; }
    public int Defence { get => defence; }
}
