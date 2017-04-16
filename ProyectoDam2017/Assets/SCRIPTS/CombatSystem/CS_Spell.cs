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


	void Start(){
		switch (spellType) {
		case SPELL_TYPE.self:
			GetComponent <Animator> ().SetFloat ("spellSelector", 0);
			break;
		case SPELL_TYPE.area:
			GetComponent <Animator> ().SetFloat ("spellSelector", 1);
			break;
		}
	}
}
