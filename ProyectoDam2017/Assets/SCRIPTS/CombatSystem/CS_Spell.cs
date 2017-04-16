using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Spell : MonoBehaviour {

	public enum SPELL_TYPE
	{
		self,
		area
	}

	public SPELL_TYPE spellType;

	[Header ("Modifiers")]
	public float health;
	public float strenght;
	public float stamina;

	public float area;


}
