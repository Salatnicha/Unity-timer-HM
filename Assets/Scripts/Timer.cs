using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _selfText;
	[SerializeField] private float _addSecondTime = 0.5f;
	private float _currentTime;
	private bool _isCount;

	private Coroutine _countRoutine;

	[ContextMenu(nameof(Play))]
	public void Play()
	{
		_isCount = true;
		_countRoutine = StartCoroutine(Count());
	}

	[ContextMenu(nameof(Stop))]
	public void Stop()
	{
		if (_countRoutine != null)
			StopCoroutine(_countRoutine);
	}

	public void Reset()
	{
		_currentTime = 0;
		_isCount = false;
	}

	private void Start()
	{
		Reset();
	}

	private IEnumerator Count()
	{
		while (_isCount)
		{
			_currentTime += 1;
			_selfText.text = string.Format("{0:00}:{1:00}", (int)_currentTime / 60, (int)_currentTime % 60);

			yield return new WaitForSeconds(_addSecondTime);
		}
	}
}
