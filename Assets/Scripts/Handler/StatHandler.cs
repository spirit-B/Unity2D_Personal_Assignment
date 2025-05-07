using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Header("Charactor's Health Point")]
    [Range(1, 100)][SerializeField] private int hp = 10;

    public int Hp
    {
        get => hp;
        set => hp = Mathf.Clamp(value, 0, 100);
    }

    [Header("Charactor's Movement Speed")]
    [Range(1f, 20f)][SerializeField] private float speed = 8;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }

    [Header("Charactor's Jump Power")]
    [Range(1f, 10f)][SerializeField] private float jump = 8;

    public float Jump
    {
        get => jump;
        set => jump = Mathf.Clamp(value, 0, 10);
    }
}
