using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] private float _addSecondTime = 0.5f;

	private bool _isCount;

	public float CurrentTime { get; private set; }

	private void OnEnable()
	{
		StartCoroutine(Count());

		MouseInputHandler.OnMouseClick += Toggle;
	}

	private void Start()
	{
		Reset();
	}

	private void OnDisable()
	{
		MouseInputHandler.OnMouseClick -= Toggle;
	}

	[ContextMenu(nameof(Play))]
	public void Play()
	{
		_isCount = true;
	}

	[ContextMenu(nameof(Stop))]
	public void Stop()
	{
		_isCount = false;
	}

	[ContextMenu(nameof(Reset))]
	public void Reset()
	{
		CurrentTime = 0;
		_isCount = false;
	}

	public void Toggle()
	{
		if (_isCount)
		{
			Stop();
		}
		else
		{
			Play();
		}
	}

	private IEnumerator Count()
	{
		bool isWork = true;
		var waitCanCount = new WaitUntil(() => _isCount);
		var waitTimeAdd = new WaitForSeconds(_addSecondTime);

		while (isWork)
		{
			yield return waitCanCount;

			CurrentTime += 1;

			yield return waitTimeAdd;
		}
	}
}
