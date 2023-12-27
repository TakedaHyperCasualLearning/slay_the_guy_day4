using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardBaseComponent : MonoBehaviour
{
    private int costPoint = 0;
    private string title = "";
    private string description = "";
    [SerializeField] private TextMeshProUGUI costPointText = null;
    [SerializeField] private TextMeshProUGUI titleText = null;
    [SerializeField] private TextMeshProUGUI descriptionText = null;

    public int CostPoint { get => costPoint; set => costPoint = value; }
    public string Title { get => title; set => title = value; }
    public string Description { get => description; set => description = value; }
    public TextMeshProUGUI CostPointText { get => costPointText; set => costPointText = value; }
    public TextMeshProUGUI TitleText { get => titleText; set => titleText = value; }
    public TextMeshProUGUI DescriptionText { get => descriptionText; set => descriptionText = value; }
}
