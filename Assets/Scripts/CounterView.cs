using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _selfText;
	[SerializeField] private Timer _timer;

	private void Update()
	{
		if (_timer != null)
		{
			SetTime(_timer.CurrentTime);
		}
	}

	public void SetTime(float time)
	{
		_selfText.text = string.Format("{0:00}:{1:00}", (int)time / 60, (int)time % 60);
	}
}
