using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsComponent : MonoBehaviour
{
    [SerializeField] private List<CardBaseComponent> cardList = new List<CardBaseComponent>();

    public List<CardBaseComponent> CardList { get => cardList; set => cardList = value; }
}
