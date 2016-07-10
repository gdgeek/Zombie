﻿using UnityEngine;
using System.Collections;

public class AttackBox : MonoBehaviour {

	public delegate void OnAttack(BodyBox body);
	public BoxCollider _box;
	private event OnAttack onAttack_;
	public void doEnable(OnAttack onAttack){
		onAttack_ += onAttack;
		_box.enabled = true;
	}
	public void doDisable(){
		onAttack_ = null;
		_box.enabled = false;
	}
	public void OnTriggerEnter( Collider other ){
		Debug.Log ("name" + other.name);
		BodyBox box = other.gameObject.GetComponent<BodyBox> ();
		if (onAttack_ != null && box != null) {
			onAttack_ (box);//.hit ();
		}
	}
}
