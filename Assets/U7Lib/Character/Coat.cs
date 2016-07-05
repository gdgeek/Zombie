using UnityEngine;
using System.Collections;
namespace U7{
	public class Coat : MonoBehaviour, IEquip {

		public virtual string brand{
			get{ 
				return "";
			}
		}
	}
}
