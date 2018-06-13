using UnityEngine;

public static class Utils
{
	public static bool IsNaN(Vector3 vector)
	{
		return float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z);
	}

	public static bool IsNaN(Vector2 vector)
	{
		return float.IsNaN(vector.x) || float.IsNaN(vector.y);
	}
}
