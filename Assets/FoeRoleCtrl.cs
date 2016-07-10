using UnityEngine;
using System.Collections;
using GDGeek;

public class FoeRoleCtrl : RoleCtrl {
	public Animator _animator = null;
	private void doHit(float power){
		Debug.Log (power);
		this._fsm.post ("hit");
	}
	void Awake(){
		VoxelMesh[] meshs = this.gameObject.GetComponentsInChildren<VoxelMesh> ();
		for (int i = 0; i < meshs.Length; ++i) {
			GameObject go = meshs [i].gameObject;
			BodyBox bb = go.GetComponent<BodyBox> ();
			if (bb == null) {
				bb = go.AddComponent<BodyBox> ();
			}
			bb.doEnable (this.doHit);
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
		}, _fsm, delegate {
			_animator.speed = 2;
			_animator.SetBool("hit", false);
			return "idle";
		});


		return state;
	}
	// Use this for initialization
	void Start () {
		_fsm.addState ("idle", getIdle ());
		_fsm.addState ("hit", getHit ()); 
		_fsm.init ("idle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
