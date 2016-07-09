using UnityEngine;
using System.Collections;
using GDGeek;
using System;


namespace U7{
	public class UpperBody :MonoBehaviour{
		[Serializable]
		public class Parts{
			public VoxelMesh _lHand = null;
			public VoxelMesh _rHand = null;
			public VoxelMesh _luArm = null;
			public VoxelMesh _ruArm = null;
			public VoxelMesh _llArm = null;
			public VoxelMesh _rlArm = null;
			public VoxelMesh _spine1 = null;
			public VoxelMesh _spine2 = null;
		}


		public Parts _body = new Parts();
		public Parts _wear = new Parts();
		private VoxelMesh pullIt(VoxelMesh body, VoxelMesh d){
			var wear = (VoxelMesh)GameObject.Instantiate (d);
			wear.transform.parent = body.transform.parent;
			wear.transform.localPosition = body.transform.localPosition;
			wear.transform.localRotation = body.transform.localRotation;
			wear.transform.localScale = body.transform.localScale;
			wear.gameObject.SetActive (true);
			body.gameObject.SetActive (false);
			return wear;
		}
		public void pull(Coat coat){
			doff ();
			if (coat.lHand != null) {
				_wear._lHand = pullIt (_body._lHand, coat.lHand);
			}

			if (coat.rHand != null) {
				_wear._rHand = pullIt (_body._rHand, coat.rHand);
			}


			if (coat.rlArm != null) {
				_wear._rlArm = pullIt (_body._rlArm, coat.rlArm);
			}


			if (coat.ruArm != null) {
				_wear._ruArm = pullIt (_body._ruArm, coat.ruArm);
			}


			if (coat.llArm != null) {
				_wear._llArm = pullIt (_body._llArm, coat.llArm);
			}

			if (coat.luArm != null) {
				_wear._luArm = pullIt (_body._luArm, coat.luArm);
			}


			if (coat.spine1 != null) {
				_wear._spine1 = pullIt (_body._spine1, coat.spine1);
			}
			if (coat.spine2 != null) {
				_wear._spine2 = pullIt (_body._spine2, coat.spine2);
			}
			//_lHand.gameObject.SetActive (false);
		}
		public void doff (){
			if (_wear._lHand != null) {
				GameObject.DestroyImmediate (_wear._lHand.gameObject);
			}
			_body._lHand.gameObject.SetActive (true);
			if (_wear._rHand != null) {
				GameObject.DestroyImmediate (_wear._rHand.gameObject);
			}
			_body._rHand.gameObject.SetActive (true);
			if (_wear._llArm != null) {
				GameObject.DestroyImmediate (_wear._llArm.gameObject);
			}
			_body._llArm.gameObject.SetActive (true);
			if (_wear._luArm != null) {
				GameObject.DestroyImmediate (_wear._luArm.gameObject);
			}
			_body._luArm.gameObject.SetActive (true);
			if (_wear._rlArm != null) {
				GameObject.DestroyImmediate (_wear._rlArm.gameObject);
			}
			_body._rlArm.gameObject.SetActive (true);
			if (_wear._rlArm != null) {
				GameObject.DestroyImmediate (_wear._rlArm.gameObject);
			}
			_body._rlArm.gameObject.SetActive (true);
			if (_wear._ruArm != null) {
				GameObject.DestroyImmediate (_wear._ruArm.gameObject);
			}
			_body._ruArm.gameObject.SetActive (true);
			if (_wear._spine1 != null) {
				GameObject.DestroyImmediate (_wear._spine1.gameObject);
			}
			_body._spine1.gameObject.SetActive (true);
			if (_wear._spine2 != null) {
				GameObject.DestroyImmediate (_wear._spine2.gameObject);
			}
			_body._spine2.gameObject.SetActive (true);

		}
	}
}