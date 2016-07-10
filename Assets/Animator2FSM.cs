using UnityEngine;
using System.Collections;

public class Animator2FSM : MonoBehaviour {
	public RoleCtrl _ctrl;
	public void footHurmed(){
		_ctrl._fsm.post("foot_hurmed");
	}
	public void footUnhurmed(){
		_ctrl._fsm.post("foot_unhurmed");
	}


	public void weaponHurmed(){
		_ctrl._fsm.post("weapon_hurmed");
	}
	public void weaponUnhurmed(){
		_ctrl._fsm.post("weapon_unhurmed");
	}
}
