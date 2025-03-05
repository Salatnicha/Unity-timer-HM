using UnityEngine;

public class MouseInputHandler : MonoBehaviour
{
	public System.Action OnMouseClick;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			OnMouseClick?.Invoke();
		}
	}
}
