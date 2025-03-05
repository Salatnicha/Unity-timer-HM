using UnityEngine;

public class MouseInputHandler : MonoBehaviour
{
	public event System.Action MouseClicked;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			MouseClicked?.Invoke();
		}
	}
}
