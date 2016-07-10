using UnityEngine;
using System.Collections;
using GDGeek;

public class FoeRoleCtrl : MonoBehaviour {
	public Animator _animator = null;
	private FSM fsm_ = new FSM();
	private void doHit(float power){
		Debug.Log (power);
		this.fsm_.post ("hit");
		//_animtor.SetBool ("hit", true);
	}
	void Awake(){
		BodyBox[] bodies = this.gameObject.GetComponentsInChildren<BodyBox> ();
		for (int i = 0; i < bodies.Length; ++i) {
			bodies [i].doEnable (doHit);
		}
	
	}
	private State getIdle(){
		State state = new State ();
		state.addAction("hit", "hit");
		return state;
	}
	public float _hitTime = 0.1f;
	private State getHit(){
		State state = TaskState.Create (delegate() {
			Task task = new Task();
			task.init = delegate {
				_animator.speed = 4;
				_animator.SetBool("hit", true);
			};
			task.isOver = delegate {
				var info = _animator.GetCurrentAnimatorStateInfo(0);
				if(info.IsName("hit") && info.normalizedTime >= 0.9f ){
					return true;
				}
				return false;
			};

			return task;
		}, fsm_, delegate {
			_animator.speed = 2;
			_animator.SetBool("hit", false);
			return "idle";
		});


		return state;
	}
	// Use this for initialization
	void Start () {
		fsm_.addState ("idle", getIdle ());
		fsm_.addState ("hit", getHit ()); 
		fsm_.init ("idle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
