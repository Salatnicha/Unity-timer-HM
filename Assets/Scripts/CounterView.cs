using TMPro;
using UnityEngine;
using UniRx;

public class CounterView : MonoBehaviour
{
	private const int MinutesInHour = 60;

	[SerializeField] private TextMeshProUGUI _selfText;
	[SerializeField] private Timer _timer;

	private void OnEnable()
	{
		if (_timer != null)
		{
			_timer.CurrentTime
				.Subscribe(time => SetTime(time))
			.AddTo(this);
		}
	}

	private void SetTime(float time)
	{
		string timeFormat = string.Format("{0:00}:{1:00}", (int)time / MinutesInHour, (int)time % MinutesInHour);
		_selfText.text = timeFormat;
	}
}
