using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject card;

    private GameEvent gameEvent;

    private DamageSystem damageSystem;
    // カード
    private CardSelectSystem cardSelectSystem;
    // UI
    private HitPointUISystem hitPointUISystem;
    private ManaUISystem manaUISystem;

    void Start()
    {
        gameEvent = new GameEvent();

        damageSystem = new DamageSystem(gameEvent);
        // カード
        cardSelectSystem = new CardSelectSystem(gameEvent);
        // UI
        hitPointUISystem = new HitPointUISystem(gameEvent);
        manaUISystem = new ManaUISystem(gameEvent);

        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemy);
        gameEvent.AddComponentList?.Invoke(card);
    }

    void Update()
    {
        damageSystem.OnUpdate();
        // カード
        cardSelectSystem.OnUpdate();
        // UI
        hitPointUISystem.OnUpdate();
        manaUISystem.OnUpdate();
    }
}
