using UnityEngine;

public class FuncionesEncastre : MonoBehaviour {

	//Script PosicionesEncastre
	[Header("Script Posiciones Encastre.")]
	public PosAnimalesEncastre PAE_Script;
	
	//Arreglos de Bools que representan los animales ya encastrados.
	[Header("Arreglos de Bools de Animales Encastrados (Read Only).")]
	public bool[] AnimalesEncastrados;

	//UI y Parametros para volver a jugar.
	[Header("UI y Parámetros para volver a Jugar.")]
	public GameObject UIEscoger;
	public GameObject[] DesBotones;
	public float SiguienteEncastre;
	public int ContA, ContB;
	public bool VolverAJugar;

	[Header("Arreglo de Animators de Animales Encastrados.")]
	public Animator[] AnimalesColor;
	public Animator[] AnimalesBlanco;

	//AudioSource y AudioClip para animales encastrados.
	[Header("AudioSource y AudioClips para animales encastrados.")]
	public AudioSource AudioS;
	public AudioClip Ubicar;
	public AudioClip Acertaste;
	public AudioClip[] NoAcertaste;

//*****************************************************************
//********************** FUNCIONES ENCASTRE ***********************
//*****************************************************************	

	//Detecta si algunos de los animales ya ha sido encastrado.
	public void DetectarAnimalesEncastrados(int x){
		if(AnimalesEncastrados[x] == true){
			AnimalesColor[x].SetBool("RemoverEncastrado", true);
			AnimalesBlanco[x].SetBool("RemoverEncastrado", true);
			AudioS.clip = Acertaste; AudioS.Play();
		}else{
			AudioS.clip = NoAcertaste[Random.Range(0, 2)];
			AudioS.Play();
		}

		//Contamos los animales para saber cuando empezar otra vez.
		if(AnimalesEncastrados[x] == true){
			ContA++;
		}

		//Una vez contados todos los animales, reiniciamos el juego.
		if(ContA == 5){
			ContA = 0; ContB++;
			SiguienteEncastre = 3.1f;
		}

		if(ContB == 5){
			SiguienteEncastre = 3.1f;
			VolverAJugar = false;
		}

	}
//*****************************************************************
//************************* FUNCIONES UI **************************
//*****************************************************************	
	//Activa la UI para escoger si volver a jugar o no.
	public void MostrarUIEscoger(){
		UIEscoger.SetActive(true);
		for(int i = 0; i < DesBotones.Length; i++){ DesBotones[i].SetActive(false); }
	}

	//Permite volver a jugar si se tocan el Boton SI.
	public void EscogerSi(){
		ContA = 0; ContB = 0;
		VolverAJugar = true; 
		UIEscoger.SetActive(false);
		for(int i = 0; i < DesBotones.Length; i++){ DesBotones[i].SetActive(true); }
		JugarEncastre();										
	}

	//Activa los animales para moverlos.
	public void JugarEncastre(){
		if(VolverAJugar == true){
			for(int i = 0; i < AnimalesEncastrados.Length; i++){
				AnimalesEncastrados[i] = false;
			}
			PAE_Script.AsignarAnimalesCBP();
			AudioS.clip = Ubicar; AudioS.Play();
			SiguienteEncastre = 0f;
		}	
	}


//*****************************************************************	

	void Start(){
		PAE_Script.AsignarAnimalesCBP();
	}
	
	void Update(){
		if(SiguienteEncastre < 0f){
			if(VolverAJugar == true){
				JugarEncastre();				
			}else{				
				MostrarUIEscoger();
				SiguienteEncastre = 0;
			}
		}else if(SiguienteEncastre == 0f){

		}else{
			SiguienteEncastre -= Time.deltaTime;
		}
	}
}
