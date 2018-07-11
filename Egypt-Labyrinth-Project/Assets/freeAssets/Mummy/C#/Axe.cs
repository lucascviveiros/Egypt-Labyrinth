using UnityEngine;
using System.Collections;

public class Axe : BaseAnimController
{
	[SerializeField]
	private string
		_atack_1;

	protected override void BaseButtons ()
	{
		base.BaseButtons ();
		if (GUI.Button (new Rect (10, 130, 100, 50), "Atack_1")) {
			_anim.SetTrigger (_atack_1);
		}
	}
}
