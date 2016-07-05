using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using GDGeek;
using System.IO;

public class CharacterTest {

	[Test]
	public void TestCoat(){
		U7.Suit suit =  Component.FindObjectOfType<U7.Suit> ();
		U7.Coat coat = suit.coat;
		Assert.IsAssignableFrom<VoxelMesh> (coat.lHand);
		Assert.NotNull (coat.lHand);

		Assert.IsAssignableFrom<VoxelMesh> (coat.rHand);
		Assert.NotNull (coat.rHand);


		Assert.IsAssignableFrom<VoxelMesh> (coat.luArm);
		Assert.NotNull (coat.luArm);
		Assert.IsAssignableFrom<VoxelMesh> (coat.ruArm);
		Assert.NotNull (coat.ruArm);



		Assert.IsAssignableFrom<VoxelMesh> (coat.llArm);
		Assert.NotNull (coat.llArm);
		Assert.IsAssignableFrom<VoxelMesh> (coat.rlArm);
		Assert.NotNull (coat.rlArm);


		Assert.IsAssignableFrom<VoxelMesh> (coat.spine);
		Assert.NotNull (coat.spine);


		Assert.IsAssignableFrom<VoxelMesh> (coat.spine1);
		Assert.NotNull (coat.spine1);


		Assert.IsAssignableFrom<VoxelMesh> (coat.spine2);
		Assert.NotNull (coat.spine2);


	}
	[Test] 
	public void TestCharacter(){

		U7.Character chracter = Component.FindObjectOfType<U7.Character> ();
		Assert.IsNotNull (chracter);
		chracter.refresh ();
		U7.Body body = chracter.body;
		Assert.IsInstanceOf<U7.Coat> (body.coat);
		Assert.IsInstanceOf<U7.IEquip> (body.coat);
		Assert.AreSame (body.coat.brand, U7.Body.Naked);


		U7.Suit suit =  Component.FindObjectOfType<U7.Suit> ();

		Assert.AreEqual (suit.brand, "armour");

		U7.Pants pants = suit.pants;

		Assert.AreEqual (suit.pants.brand, "armour");
		body.pull (pants);

		U7.Coat coat = suit.coat;
		body.pull (coat);
		U7.Weapon weapon = suit.weapon;
		body.pull (weapon);


	}

}
