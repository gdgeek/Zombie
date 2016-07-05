using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using GDGeek;
using System.IO;

public class CharacterTest {

	[Test]
	public void TestChest(){
		
	 
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

		return;
		U7.Pants pants = suit.pants;

		Assert.AreEqual (suit.pants.brand, "armour");
		body.pull (pants);

		U7.Coat coat = suit.coat;
		body.pull (coat);
		U7.Weapon weapon = suit.weapon;
		body.pull (weapon);


		/*		body.pants = suit.pants;
		body.weapon = suit.weapon;
		body.coat = suit.coat;
		*/
	

	//	Head head = chracter.getHead ();
	//	Assert.IsNotNull (head);

		GameObject hobj = GameObject.Find ("Head");
		Assert.IsNotNull (hobj);
		chracter.setHead (hobj.GetComponent<Head>());
		Head old = chracter.head;

		Assert.IsNotNull (old.mesh);
	//	Assert.AreEqual()
		old.swap (hobj.GetComponent<Head>());

		//chracter.head.swap (hobj.GetComponent<Head>());
		//Assert.AreEqual (chracter.head, hobj);

		//head.change (hobj);
		//chracter.
		//Assert.AreEqual (1, 1);
	}

}
