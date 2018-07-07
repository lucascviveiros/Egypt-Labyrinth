using UnityEngine;
using System.Collections;

public class Spear_Shield : BaseAnimController
{
	[SerializeField]
	private string
		_threaten;

	protected override void BaseButtons ()
	{
		base.BaseButtons ();
		if (GUI.Button (new Rect (10, 140, 100, 50), "Threaten")) {
			_anim.SetTrigger (_threaten);
		}

	}


}
