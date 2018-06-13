using UnityEngine;

public class OnDestroySetInvulnerable : CachedMonoBehaviour
{
    [SerializeField]
    HitsToDestroy _hitsToDestory;

    [SerializeField]
    bool _invulnerable;

    void OnDestroy()
    {
        _hitsToDestory.Invulnerable = _invulnerable;
    }
}