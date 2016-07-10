using UnityEngine;
using System.Collections;

public class AttackBox : MonoBehaviour {

	public delegate void OnAttack(BodyBox body);
	public BoxCollider _box;
	private event OnAttack onAttack_;
	public void Awake(){
		_box.enabled = false;
	}
	public void doEnable(OnAttack onAttack){
		onAttack_ += onAttack;
		_box.enabled = true;
	}
	public void doDisable(){
		onAttack_ = null;
		_box.enabled = false;
	}
	public void OnTriggerEnter( Collider other ){
		BodyBox box = other.gameObject.GetComponent<BodyBox> ();
		Debug.Log (other.name +"b" + box +"!" + onAttack_);
		if (onAttack_ != null && box != null) {
			onAttack_ (box);//.hit ();
		}
	}
}
