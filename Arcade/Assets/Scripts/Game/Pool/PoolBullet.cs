using UnityEngine;

using ObjectsPool;

public class PoolBullet : Pool<Bullet>
{
    public PoolBullet(GameObject prefab, int capacity): base(prefab, capacity) { }

    public override Bullet ConvertToPoolObject(GameObject gameObject, int index)
    {
        gameObject.SetActive(false);

        var bullet = gameObject.GetComponent<Bullet>();
		bullet.SetPool(this, index);

        return bullet;
    }

    public override GameObject ConvertToGameObject(Bullet poolObject)
    {
        return poolObject.gameObject;
    }
}