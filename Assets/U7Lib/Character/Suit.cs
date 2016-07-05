using UnityEngine;
using System.Collections;
namespace U7{
	public class Suit : MonoBehaviour {
		public Coat _coat = null;
		public Weapon _weapon = null;
		public Pants _pants;
		public string _brand;
		public string brand{
			get{
				return _brand;
			}
		}
		public Pants pants{
			get{ 
				return _pants;
			}

		} 
		public Weapon weapon{
			get{ 
				return _weapon;
			}

		}
		public Coat coat{
			get{ 
				return _coat;
			}

		}


	}
}