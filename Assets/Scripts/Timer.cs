using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _selfText;
	[SerializeField] private float _addSecondTime = 0.5f;
	private float _currentTime;
	private bool _isCount;

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
		_currentTime = 0;
		_isCount = false;
	}

	private void Start()
	{
		StartCoroutine(Count());
		Reset();
	}

	private IEnumerator Count()
	{
		bool isWork = true;

		while (isWork)
		{
			yield return new WaitUntil(() => _isCount);

			_currentTime += 1;
			_selfText.text = string.Format("{0:00}:{1:00}", (int)_currentTime / 60, (int)_currentTime % 60);

			yield return new WaitForSeconds(_addSecondTime);
		}
	}
}
