using UnityEngine;
using System.Collections;
namespace U7{
	public class NakedCoat : Coat {
		
		public override string brand{
			get{ 
				return Body.Naked;
			}
		}
	}
}