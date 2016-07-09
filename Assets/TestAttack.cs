using UnityEngine;
using System.Collections;
using GDGeek;

public class TestAttack : MonoBehaviour {
	public Animator _animtor;
	// Use this for initialization
	void Start () {
		TaskWait tw = new TaskWait (1.0f);
		TaskManager.PushBack (tw, delegate {

			//donghua	
		});

		TaskManager.Run (tw);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
