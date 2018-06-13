using UnityEngine;

public class HitsToDestroy : CachedMonoBehaviour
{
	public int Hits;

	public bool Invulnerable;

	void OnCollisionEnter(Collision collision)
	{
		if (Invulnerable)
			return;

		if ( ! collision.gameObject.CompareTag(ArcadeGameObjectTags.Bullet.ToString()))
			return;

		if (Hits > 0)
		{
			Hits -= 1;
			if (Hits == 0)
				Destroy(gameObject);
		}
	}
}
