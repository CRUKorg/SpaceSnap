using UnityEngine;
using System.Collections;

public static class waitforseconds {

	public static IEnumerable wait(int delay)
	{
		yield return new WaitForSeconds(delay);
	}
}
