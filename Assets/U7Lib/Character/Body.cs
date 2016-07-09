using UnityEngine;
using System.Collections;
namespace U7{
	public class Body : MonoBehaviour {


		//public const string Naked = "naked";
		public UpperBody _upper = null;
		public UpperBody upper{
			get{ 
				return _upper;
			}
		}

		public void pull(Pants pants){

		}
		public void pull(Coat coat){
			_upper.pull (coat);
		}
		public void pull(Weapon weapon){
		
		}
	}
}