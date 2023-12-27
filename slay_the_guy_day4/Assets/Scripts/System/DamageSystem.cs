using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem
{
    private List<CharacterBaseComponent> characterBaseList = new List<CharacterBaseComponent>();
    private List<DamageComponent> damageList = new List<DamageComponent>();

    public DamageSystem(GameEvent gameEvent)
    {
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < characterBaseList.Count; i++)
        {
            CharacterBaseComponent characterBase = characterBaseList[i];
            DamageComponent damage = damageList[i];

            if (!damage.gameObject.activeSelf) continue;

            damage.DamagePoint -= characterBase.DefensePoint;
            if (damage.DamagePoint <= 0)
            {
                damage.DamagePoint = 0;
                characterBase.DefensePoint = 0;
                continue;
            };

            characterBase.HitPoint -= damage.DamagePoint;
            damage.DamagePoint = 0;
            characterBase.DefensePoint = 0;

            if (characterBase.HitPoint <= 0)
            {
                characterBase.HitPoint = 0;
                damage.DamagePoint = 0;
                characterBase.gameObject.SetActive(false);
            }
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        CharacterBaseComponent characterBase = gameObject.GetComponent<CharacterBaseComponent>();
        DamageComponent damage = gameObject.GetComponent<DamageComponent>();

        if (characterBase == null || damage == null) return;

        characterBaseList.Add(characterBase);
        damageList.Add(damage);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        CharacterBaseComponent characterBase = gameObject.GetComponent<CharacterBaseComponent>();
        DamageComponent damage = gameObject.GetComponent<DamageComponent>();

        if (characterBase == null || damage == null) return;

        characterBaseList.Remove(characterBase);
        damageList.Remove(damage);
    }
}
