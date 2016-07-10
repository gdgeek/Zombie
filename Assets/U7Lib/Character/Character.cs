using UnityEngine;
using System.Collections;


namespace U7{


	[ExecuteInEditMode]
	public class Character : MonoBehaviour {
		//public bool _reset = false;
		public Body _body = null;
		// Use this for initialization
		void Start () {
			
		}
		public U7.Body body{
			get{ 
				return _body;
			}

		}
		public void refresh(){
			//head_ = this.gameObject.GetComponentInChildren<Head> ();
		//	head_ = null;
		}
		public void doit(){
			Debug.Log ("ddd it!");
		}
	}

}