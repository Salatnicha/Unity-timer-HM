using UnityEngine;

public class MouseInputHandler : MonoBehaviour
{
	public static System.Action OnMouseClick;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			OnMouseClick?.Invoke();
		}
	}
}
