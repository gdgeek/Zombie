using UnityEngine;
using System.Collections;
using GDGeek;


namespace U7{
	public class Coat : Equip {
		public UpperBody.Parts _parts;

		public VoxelMesh lHand{
			get{ 
				return _parts._lHand;
			}

		}
		public VoxelMesh rHand{
			get{ 
				return _parts._rHand;
			}

		}

		public VoxelMesh luArm{
			get{ 
				return _parts._luArm;
			}

		}
		public VoxelMesh ruArm{
			get{ 
				return _parts._ruArm;
			}

		}
		public VoxelMesh llArm{
			get{ 
				return _parts._llArm;
			}

		}
		public VoxelMesh rlArm{
			get{ 
				return _parts._rlArm;
			}

		}

		public VoxelMesh spine1{
			get{ 
				return _parts._spine1;
			}

		}


		public VoxelMesh spine2{
			get{ 
				return _parts._spine2;
			}

		}
	}
}
