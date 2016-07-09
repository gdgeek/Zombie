using UnityEngine;
using System.Collections;

public class FoeRoleCtrl : MonoBehaviour {
	public Animator _animtor = null;
	private void doHit(float power){
		Debug.Log (power);
		_animtor.SetBool ("hit", true);
	}
	void Awake(){
		BodyBox[] bodies = this.gameObject.GetComponentsInChildren<BodyBox> ();
		for (int i = 0; i < bodies.Length; ++i) {
			bodies [i].doEnable (doHit);
		}
	
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
