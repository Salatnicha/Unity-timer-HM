using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] private MouseInputHandler _mouseInputHandler;
	[SerializeField] private float _addSecondTime = 0.5f;

	private bool _isCount;
	private Coroutine _countRoutine;

	public float CurrentTime { get; private set; }

	private void OnEnable()
	{
		_mouseInputHandler.OnMouseClick += Toggle;
	}

	private void Start()
	{
		Reset();
	}

	private void OnDisable()
	{
		_mouseInputHandler.OnMouseClick -= Toggle;
	}

	[ContextMenu(nameof(Play))]
	public void Play()
	{
		_isCount = true;

		_countRoutine = StartCoroutine(Count());
	}

	[ContextMenu(nameof(Stop))]
	public void Stop()
	{
		_isCount = false;

		if (_countRoutine != null)
			StopCoroutine(_countRoutine);
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
		var waitTimeAdd = new WaitForSeconds(_addSecondTime);

		while (isWork)
		{
			CurrentTime += 1;

			yield return waitTimeAdd;
		}
	}
}
