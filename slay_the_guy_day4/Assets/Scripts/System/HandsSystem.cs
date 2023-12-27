using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsSystem
{
    private GameObject playerObject;
    private GameEvent gameEvent = null;
    private List<HandsComponent> handsList = new List<HandsComponent>();

    public HandsSystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        playerObject = player;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(HandsComponent hands)
    {
        hands.CardList.ForEach(card => gameEvent.AddComponentList?.Invoke(card.gameObject));
    }

    public void OnUpdate()
    {
        TurnComponent turn = playerObject.GetComponent<TurnComponent>();
        if (!turn.IsMyTurn || turn.TurnState != TurnState.Draw) return;

        for (int i = 0; i < handsList.Count; i++)
        {
            HandsComponent hands = handsList[i];
            if (!hands.gameObject.activeSelf) continue;

            DrawCard(hands);

            turn.TurnState = TurnState.Play;
            Debug.Log(turn.gameObject.name + "Battle phase");
        }
    }

    private void DrawCard(HandsComponent hands)
    {
        List<CardBaseComponent> cardList = gameEvent.Draw();
        for (int i = 0; i < cardList.Count; i++)
        {
            hands.CardList[i].CostPoint = cardList[i].CostPoint;
            hands.CardList[i].AttackPoint = cardList[i].AttackPoint;
            hands.CardList[i].Title = cardList[i].Title;
            hands.CardList[i].Description = cardList[i].Description;

            hands.CardList[i].CostPointText.text = cardList[i].CostPoint.ToString();
            hands.CardList[i].TitleText.text = cardList[i].Title;
            hands.CardList[i].DescriptionText.text = cardList[i].Description;

            hands.CardList[i].gameObject.SetActive(true);
            Debug.Log(hands.CardList[i].Title + "を手札に追加");
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        HandsComponent hands = gameObject.GetComponent<HandsComponent>();

        if (hands == null) return;

        handsList.Add(hands);

        Initialize(hands);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        HandsComponent hands = gameObject.GetComponent<HandsComponent>();

        if (hands == null) return;

        handsList.Remove(hands);
    }
}
