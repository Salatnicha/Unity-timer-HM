using System.Collections;
using UnityEngine;
using UniRx;

public class Timer : MonoBehaviour
{
	[SerializeField] private MouseInputHandler _mouseInputHandler;
	[SerializeField] private float _addSecondTime = 0.5f;

	private bool _isCount;
	private Coroutine _countRoutine;
	private ReactiveProperty<float> _currentTime = new ReactiveProperty<float>(0);

	public IReadOnlyReactiveProperty<float> CurrentTime => _currentTime;

	private void OnEnable()
	{
		_mouseInputHandler.MouseClicked += Toggle;
	}

	private void Start()
	{
		Reset();
	}

	private void OnDisable()
	{
		_mouseInputHandler.MouseClicked -= Toggle;
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
		_currentTime.Value = 0;
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
			_currentTime.Value += 1;

			yield return waitTimeAdd;
		}
	}
}
