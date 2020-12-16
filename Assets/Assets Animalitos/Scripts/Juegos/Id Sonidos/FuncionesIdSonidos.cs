using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuncionesIdSonidos : MonoBehaviour {

	//Lista de Sonidos y Sprites de Animales
	[Header("AudioS, Sonidos y Sprites a Mostrar.")]
	public AudioSource AudioS;
	public List<Sprite> SpritesAnimales;
	public List<AudioClip> AC_Animales;
	
	//Lista de AudioClips y Sprites Selectos.
	[Header("Listas de AudioClips, Sprites y Bools Selectos")]
	public List<AudioClip> AC_AnimalesSel;
	public List<Image> SpritesSel;
	public List<Animator> SpritesAnimatorSel;
	public int RandomIntA;
	public int[] x;	
	
	//Parámetros para escoger y comprobar el sonido.
	[Header("Parámetros para escoger y comprobar el sonido.")]
	public AudioClip CualAnimalA;
	public AudioClip CualAnimalB;
	public AudioClip AnimalCorrecto;
	public List<AudioClip> AnimalIncorrecto;
	public int RandomIntB;
	public float TiempoAnimal;
	public bool Escoger, UnaVez;

	//UI y Parametros para volver a jugar.
	[Header("UI y Parámetros para volver a Jugar.")]
	public GameObject UIEscoger;
	public GameObject[] DesBotones;
	public int Cont;


//*****************************************************************
//*************************** FUNCIONES ***************************
//*****************************************************************	
	
	public void EscogerSi(){
		Cont = 0;
		AudioS.clip = CualAnimalB; AudioS.Play();
		TiempoAnimal = 3.5f;
		Escoger = true; UnaVez = false;
		AsignarAnimales();
		UIEscoger.SetActive(false);
		for(int i = 0; i < DesBotones.Length; i++){ DesBotones[i].SetActive(true); }
	}



	//Escogemos los animales a mostrar y asignamos los audios.	
	public void AsignarAnimales(){
		if(Cont != 5){
			for(int i = 0; i < SpritesSel.Count; i++){
				RandomIntA = Random.Range(0, SpritesAnimales.Count);
				
				SpritesAnimatorSel[i].SetBool("RemoverAnimal", false);

				if(RandomIntA != x[0] && RandomIntA != x[1] && RandomIntA != x[2] && RandomIntA != x[3] && RandomIntA != x[4]){
					SpritesSel[i].sprite = SpritesAnimales[RandomIntA];
					AC_AnimalesSel[i] = AC_Animales[RandomIntA];
					x[i] = RandomIntA;
				}else{
					i--;
				}
			}
		}else{
			
		}
	}
	
	
	//Controla cuando y cual animal se debe escuchar.
	public void ControlAnimal(){
		RandomIntB = Random.Range(0, AC_AnimalesSel.Count);
			
		if(Escoger == false){
			if(Cont == 5){
				TiempoAnimal = 0;
				for(int i = 0; i < DesBotones.Length; i++){ DesBotones[i].SetActive(false); }
				UIEscoger.SetActive(true);
				return;
			}
			if(UnaVez == true){
				AsignarAnimales();				 
			}
			
			if(UnaVez == true){
				AudioS.clip = CualAnimalB; AudioS.Play();
				TiempoAnimal = 3.5f;
			}else{
				AudioS.clip = CualAnimalA; AudioS.Play();
				TiempoAnimal = 5.2f;
			}
			
			Escoger = true;
			UnaVez = false;
					
		}else{
			AudioS.clip = AC_AnimalesSel[RandomIntB]; AudioS.Play();
			TiempoAnimal = AC_AnimalesSel[RandomIntB].length + 0.25f;	
			if(Escoger == true){
				Escoger = false;
				TiempoAnimal = 0f;
			}
		}
	}
	
	//Se ejecuta para comprobar si el animal escogido es el correcto.
	public void ComprobarAnimal(int x){
		if(Cont != 5){
			if(TiempoAnimal == 0f){
				if(x == RandomIntB){
					AudioS.clip = AnimalCorrecto;
					AudioS.Play();
					for(int i = 0; i < SpritesAnimatorSel.Count; i++){
						SpritesAnimatorSel[i].SetBool("RemoverAnimal", true);
					}
					TiempoAnimal = 3.2f; Cont++;				
				}else{
					AudioS.clip = AnimalIncorrecto[Random.Range(0, 2)];
					AudioS.Play();
				}
			}
		}	
	}

	//Repite nuevamente el sonido seleccionado.
	public void RepetirSonido(){
		if(TiempoAnimal == 0f){
			AudioS.clip = AC_AnimalesSel[RandomIntB];
			AudioS.Play();
		}
	}
	

	
//*****************************************************************	

	void Start(){
		AsignarAnimales(); 
	}
	
	void Update(){
		if(TiempoAnimal < 0f){
			ControlAnimal();
			UnaVez = true;
		}else if(TiempoAnimal == 0f){

		}else{
			TiempoAnimal -= Time.deltaTime;			
		}
	}


	

}
