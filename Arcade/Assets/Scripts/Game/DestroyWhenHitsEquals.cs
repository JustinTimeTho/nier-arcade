using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(HitsToDestroy))]
public class DestroyWhenHitsEquals : MonoBehaviour
{
    [SerializeField]
    DestroyCondition[] _conditions;

    HitsToDestroy _hitsToDestroy;

    void Awake()
    {
        _hitsToDestroy = GetComponent<HitsToDestroy>();
    }

    void Update()
    {
        for (int i = 0; i < _conditions.Length; i++)
            if (_conditions[i].Hits == _hitsToDestroy.Hits)
                Destroy(_conditions[i].gameObject);
    }

    [System.Serializable]
    struct DestroyCondition
    {
        public int Hits;
        public GameObject gameObject;
    }
}