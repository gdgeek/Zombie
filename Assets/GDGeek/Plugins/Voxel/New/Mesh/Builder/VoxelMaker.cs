using UnityEngine;
using System.Collections;
using System.IO;


namespace GDGeek{
	[ExecuteInEditMode]
	public class VoxelMaker : MonoBehaviour {
		public TextAsset _voxFile = null;
		public bool _building = true;
		public VoxelStruct _vs = null;

		public Material _material = null;
		void init ()
		{
			

			#if UNITY_EDITOR
			if(_material == null){
				_material = UnityEditor.AssetDatabase.LoadAssetAtPath<Material>("Assets/GdGeek/Media/Voxel/Material/VoxelMesh.mat");
			}

			#endif
		}

		// Update is called once per frame
		void Update () {
			if (_building == true && _voxFile != null) {

				init();
				if (_voxFile != null) {
					Stream sw = new MemoryStream(_voxFile.bytes);
					System.IO.BinaryReader br = new System.IO.BinaryReader (sw); 
					_vs = VoxelFormater.ReadFromMagicaVoxel (br);
					VoxelDirector.BuildIt (_vs, this.gameObject, this._material);//体素模型
				}
				_building = false;	
			}
		}
	}

}