using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    private GameEvent gameEvent;

    private DamageSystem damageSystem;
    // UI
    private HitPointUISystem hitPointUISystem;

    void Start()
    {
        gameEvent = new GameEvent();

        damageSystem = new DamageSystem(gameEvent);

        // UI
        hitPointUISystem = new HitPointUISystem(gameEvent);

        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemy);
    }

    void Update()
    {
        damageSystem.OnUpdate();

        // UI
        hitPointUISystem.OnUpdate();
    }
}
