using UnityEngine;
using System.Collections;

public class BodyBox : MonoBehaviour {

	public delegate void OnHit(float power);

	public BoxCollider _box;
	private event OnHit onHit_;

	public void doEnable(OnHit OnHit){
		onHit_ += OnHit;
		_box.enabled = true;
	}
	public void doDisable(){
		onHit_ = null;
		_box.enabled = false;
	}
	public void hit(float power){
		if (onHit_ != null) {
			onHit_ (power);
		}
	//	Debug.Log (this.name);

	}
}
