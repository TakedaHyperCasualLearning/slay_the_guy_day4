using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    private int damagePoint = 0;

    public int DamagePoint { get => damagePoint; set => damagePoint = value; }
}
