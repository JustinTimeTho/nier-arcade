using UnityEngine;

public class TargetFramerate : MonoBehaviour
{
	[SerializeField]
	int _framerate;

	[SerializeField]
	bool _drawFPSLabel;

	float _fps;

	void Awake()
	{
		Application.targetFrameRate = _framerate;
	}

	void Update()
	{
		if ( ! _drawFPSLabel)
			return;
		_fps = 1f / Time.deltaTime;
	}

	void OnGUI()
	{
		if (_drawFPSLabel)
			GUI.Label(new Rect(0, 0, 100, 50), "FPS: " + _fps);
	}
}
