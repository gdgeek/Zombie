using UnityEngine;
using System.Collections;
using GDGeek;

public class Inside : MonoBehaviour {
	private FSM fsm_ = new FSM ();
	public AudioSource _dang;
	public Camera _camera = null;
	public Lamp _lamp = null;
	public GameLost _lost = null;
	public Body _we;
	private bool isWeakup_ = false;
	public int _winNum = 2;
	private int num_ = 0;
	public Txwx _txwx;

	public Task run(){
		Task task = new Task ();
		task.init = delegate {
			num_ = 0;
			isWeakup_ = true;
			this.fsm_.post("weakup");	
		};
		task.isOver = delegate {
			return !isWeakup_;	
		};
		return task;

	}
	StateBase getSleep(){
		var sleep = new State ();
		sleep.addAction ("weakup", "input");
		sleep.onStart += delegate {
			_txwx.hide();
			_camera.gameObject.SetActive(false);
		};
		sleep.onOver += delegate {
			_camera.gameObject.SetActive(true);
		};
		return sleep;
	}

	StateBase getWeakup(){

		var weakup = new State ();
		weakup.onStart += delegate {
			
			isWeakup_ = true;
			_we.reset();
			Debug.Log("weakup");
		};

		weakup.onOver += delegate {
			isWeakup_ = false;
			_dang.Play();
		};
		weakup.addAction ("sleep", "sleep");
		//sleep.addAction ("shiting", "shiting");
		return weakup;

	}


	StateBase getFighting(){
		State swem = new State ();

		swem.onStart += delegate {
			_lamp.reset();
		};
		swem.addAction ("shiting", "lost");

		return swem;
	}

	StateBase getInput(){
		State swem = new State ();
		swem.addAction ("attack", delegate {
			if(_lamp.isGood()){
				num_++;
				if(num_ >= this._winNum){
					return "win";
				}
				return "good";
			}	
			return "error";
		});

		swem.onStart += delegate {
			_lamp.begin();
		};
		return swem;
	}
	StateBase getGood(){
		State swem = TaskState.Create (delegate {
			return _lamp.good();
		}, fsm_, "input");
		swem.onStart += delegate {
			Debug.Log("error");
		};
		return swem;
	}
	StateBase getError(){
		State swem = TaskState.Create (delegate {
			return _lamp.error();
		}, fsm_, "input");
		swem.onStart += delegate {
			Debug.Log("error");
		};
		return swem;
	}
	StateBase getWin(){
		State swem = TaskState.Create (delegate {
			return this._lamp.winTask();
		}, fsm_, "sleep");
		swem.onStart += delegate {
			Debug.Log("win");
		};
		return swem;
	}
	StateBase getLost(){
		State swem = TaskState.Create (delegate {
			_lamp.over();
			return this._lost.lostTask();
		}, fsm_, "sleep");
		swem.onStart += delegate {
			Debug.Log("lost");
		};
		return swem;
	}
	void Start () {
		fsm_.addState ("sleep", getSleep());
		fsm_.addState ("weakup", getWeakup ());
		fsm_.addState ("fighting", getFighting (), "weakup");
		fsm_.addState ("input", getInput (), "fighting");
		fsm_.addState ("good", getGood (), "fighting");
		fsm_.addState ("error", getError (), "fighting");

		fsm_.addState ("win", getWin(), "weakup");
		fsm_.addState("lost", getLost(), "weakup");
		fsm_.init("sleep");
	}
	
	// Update is called once per frame
	void Update () {
		if (_lamp.isShiting ()) {
			//Debug.Log ("shit!!!");
			this.fsm_.post ("shiting");
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.fsm_.post("attack");
		}
	}
}
