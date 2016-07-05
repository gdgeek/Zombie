using UnityEngine;
using System.Collections;
namespace U7{
	public class Body : MonoBehaviour {


		public const string Naked = "naked";
		public Coat _coat = null;
		public Coat coat{
			get{ 
				return _coat;
			}
		}

		public void pull(Pants pants){

		}
		public void pull(Coat coat){
		
		}
		public void pull(Weapon weapon){
		
		}
	}
}