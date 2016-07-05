using UnityEngine;
using System.Collections;
namespace U7{
	public class Equip : MonoBehaviour, IEquip {

		public string _brand;

		public virtual string brand{ get{ 
				return _brand;
			}

		}

	}
}