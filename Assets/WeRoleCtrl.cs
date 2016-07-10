using UnityEngine;
using System.Collections;
using GDGeek;

public class WeRoleCtrl : MonoBehaviour {

	public FSM _fsm = new FSM();
	public Animator _animator = null;
	public GameObject _attackPoint;
	public GameObject _idlePoint;
	public AttackBox	 _foot = null;
	// Use this for initialization
	void Start () {
		_fsm.addState("idle", getIdle());
		_fsm.addState("attack", getAttack());
		_fsm.addState("pre_idle", getPreIdle(), "attack");
		_fsm.addState("pre_attack", getPreAttack(), "attack");
		_fsm.addState("post_attack", getPostAttack(), "attack");
		_fsm.init ("idle");
	}	
	private void drawBox(){
		Debug.DrawRay (this.gameObject.transform.position, Vector3.one);
	
	}
	private StateBase getPreIdle(){
		State state = TaskState.Create (delegate() {
			return new TaskTween(delegate() {
				Tween tween = TweenWorldPosition.Begin(this.gameObject, 0.01f, _idlePoint.transform.position);
				tween.method = Tween.Method.EaseIn;
				return tween;
			});
			
		}, _fsm, delegate {
			return "idle";
		});
		return state;
	} 
	private StateBase getIdle(){
		State swem = new State ();
		swem.onStart += delegate {
			_animator.speed = 2.0f;
		};
		swem.addAction("atk", "pre_attack");
		return swem;
	} 
	public float _attackTime = 0.5f;
	private int atkNumber_ = 0;
	private  StateBase getAttack(){
		State swem = new State ();

		return swem;	
	
	}
	private StateBase getPreAttack(){
		State swem = TaskState.Create (delegate() {
			TaskSet ts = new TaskSet();
			TaskManager.PushFront(ts, delegate {
				atkNumber_ ++;

				_animator.SetBool("atk", true);
			});

			ts.push(new TaskPack(delegate() {
				if(atkNumber_ == 1){
					return new TaskTween(delegate() {
						Tween tween = TweenWorldPosition.Begin(this.gameObject, 0.01f, _attackPoint.transform.position);
						tween.method = Tween.Method.EaseIn;
						return tween;
					});

				}
				return new Task();
			}));

			ts.push(new TaskCheck(delegate{
				var info = _animator.GetCurrentAnimatorStateInfo(0);
				if(atkNumber_ == 1 && info.IsName("attack")){
					_foot.doEnable(delegate(BodyBox bb){
						bb.hit(1.0f);
						_foot.doDisable();

					});
					return true;

				}
				if(atkNumber_ == 2 && info.IsName("attack_first")){
					return true;

				}
				if(atkNumber_ == 3 && info.IsName("attack_second")){
					return true;

				}
				return false;

			}));
			return ts;
		}, _fsm, delegate {
			return "post_attack";
		});
		return swem;
	}
	private StateBase getPostAttack(){
		bool nextAtk = false;
		State state = TaskState.Create (delegate() {
			Task task = new Task();
			task.init = delegate {
				nextAtk = false;	
				var info = _animator.GetCurrentAnimatorStateInfo(0);
				_animator.speed = info.length/_attackTime;	
			};

			task.isOver = delegate {
				var info = _animator.GetCurrentAnimatorStateInfo(0);
				if(atkNumber_ == 1){
					if(info.IsName("attack") && info.normalizedTime >= 0.9f ){

						return true;
					}

				}
				if(atkNumber_ == 2){
					if(info.IsName("attack_first") && info.normalizedTime >= 0.9f ){
						return true;
					}
				}


				if(atkNumber_ == 3){
					if(info.IsName("attack_second") && info.normalizedTime >= 0.9f ){
						return true;
					}
				}
				return false;

			
			};

			return task;
		}, _fsm, delegate {
			if(nextAtk){
				if(atkNumber_ == 1){
					_animator.SetBool("atk2", true);
				}else if(atkNumber_ == 2){
					_animator.SetBool("atk3", true);
				}
				return "pre_attack";
			}else{
				atkNumber_ = 0;
				_animator.SetBool("atk", false);
				_animator.SetBool("atk2", false);
				_animator.SetBool("atk3", false);
				return "pre_idle";
			}
		});

	

		state.addAction ("atk", delegate {
			if(atkNumber_<=2){
				nextAtk = true;
			}
		});
		return state;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			_fsm.post ("atk");
		}
		drawBox ();
	}


}
