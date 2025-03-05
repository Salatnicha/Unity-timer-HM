using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
	private const int MinutesInHour = 60;

	[SerializeField] private TextMeshProUGUI _selfText;
	[SerializeField] private Timer _timer;

	private void Update()
	{
		if (_timer != null)
		{
			SetTime(_timer.CurrentTime);
		}
	}

	private void SetTime(float time)
	{
		string timeFormat = string.Format("{0:00}:{1:00}", (int)time / MinutesInHour, (int)time % MinutesInHour);
		_selfText.text = timeFormat;
	}
}
