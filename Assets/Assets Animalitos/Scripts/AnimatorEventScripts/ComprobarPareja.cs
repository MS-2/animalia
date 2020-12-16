using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarPareja : MonoBehaviour {

	[Header("Script Principal Funciones MemoTest")]
	public MonoBehaviour FM_Test;

	public void CompruebaPareja(){
		FM_Test.GetComponent<FuncionesMemoTest>().ControlAnimal();
	}
}
