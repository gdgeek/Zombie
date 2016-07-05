using UnityEngine;
using System.Collections;



public class Head: MonoBehaviour{
	private MeshRenderer _render = null;
//	public 

	public GameObject mesh{
		get{
			if (_render == null) {
				_render = this.gameObject.GetComponentInChildren<MeshRenderer> ();
			}
			return _render.gameObject;
		}
	}
	public void swap(Head head){
		GameObject o = this.mesh;
		GameObject n = head.mesh;
		n.transform.parent = this.transform;
		n.transform.localPosition = Vector3.zero;
		n.transform.localEulerAngles = Vector3.zero;
		n.transform.localScale = Vector3.one;
		o.transform.parent = head.transform;


		o.transform.localPosition = Vector3.zero;
		o.transform.localEulerAngles = Vector3.zero;
		o.transform.localScale = Vector3.one;

	}
}

