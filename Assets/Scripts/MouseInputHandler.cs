using UnityEngine;
using UnityEngine.Events;

public class MouseInputHandler : MonoBehaviour
{
	[SerializeField] private UnityEvent OnFirstPressMouse;
	[SerializeField] private UnityEvent OnSecondPressMouse;

	private bool _isFirstPress = false;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_isFirstPress = !_isFirstPress;

			if (_isFirstPress)
			{
				OnSecondPressMouse?.Invoke();
			}
			else
			{
				OnFirstPressMouse?.Invoke();
			}
		}
	}
}
