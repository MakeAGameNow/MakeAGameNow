using UnityEngine;
using System.Collections;

public class PseudoInputOnTouch : MonoBehaviour
{
	public enum PseudoInputDirecton {Left, Right}
	public PseudoInputDirecton direction;

	void Touched()
	{
		if(direction == PseudoInputDirecton.Left)
		{
			PseudoInput.Instance.leftPressed = true;
		}

		if(direction == PseudoInputDirecton.Right)
		{
			PseudoInput.Instance.rightPressed = true;
		}
	}
}
