using UnityEngine;

public class DestroyWhenObjectsCount : CachedMonoBehaviour
{
	[SerializeField]
	ArcadeGameObjectTags _tag;

    [SerializeField]
    int _count;

	void Update()
	{
		if (GameObject.FindGameObjectsWithTag(_tag.ToString()).Length == _count)
            Destroy(gameObject);
	}
}
