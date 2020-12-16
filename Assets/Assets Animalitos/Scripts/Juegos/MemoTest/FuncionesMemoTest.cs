using UnityEngine;
using UnityEngine.UI;

public class FuncionesMemoTest : MonoBehaviour {

    //Script PosicionesAnimalesMemoTest.
    [Header("Script PosAnimalesMemoTest.")]
    public PosicionesAnimalesMemoTest PAMT_Script;

    //Esta variable int controla la posicion de los Arreglos.
    [Header("Index General para los Arreglos.")]
    public int IndexG;
    public float TiempoAnimal;
    public float TiempoTocar;

    //Arreglos que almacenan los Animator de los animales conocidos e incógnitos.
    [Header("Animators de Animales Conocidos e Incógnitos.")]
    public Animator[] AnimatorC_Conocidos;
    public Animator[] AnimatorC_Incognitos;    

    //Este Arreglo almacena el estado de los Animales Incognitos.
    [Header("Bools de Animales Incognitos")]
    public bool[] Estado_AIncognitos;

    //AudioSource y AudioClip para animales encastrados.
	[Header("AudioSource y AudioClips para animales encastrados.")]
	public AudioSource AudioS;
    public AudioClip Adivina;
	public AudioClip Acertaste;
	public AudioClip[] NoAcertaste;

    //UI y Parametros para volver a jugar.
	[Header("UI y Parámetros para volver a Jugar.")]
	public GameObject UIEscoger;
	public GameObject[] DesBotones;
	public int Cont;
    public bool JugarDeNuevo;

//*****************************************************************
//****************** FUNCION CONTROL PAREJAS **********************
//*****************************************************************
    //Se ejecuta cuando la pareja es correcta.
    public void ParejaCorrecta(int x, int y){
        AnimatorC_Conocidos[x].SetBool("RemoverConocido", true);
        AnimatorC_Conocidos[y].SetBool("RemoverConocido", true);
        Estado_AIncognitos[x] = false;
        Estado_AIncognitos[y] = false;
        AudioS.clip = Acertaste; AudioS.Play();
        TiempoTocar = 1.1f;
        IndexG = 0;
    }

    //Se ejecuta cuando la pareja es incorrecta.
    public void ParejaIncorrecta(int x, int y){
        AnimatorC_Incognitos[x].SetBool("RemoverIncognito", false);
        AnimatorC_Incognitos[y].SetBool("RemoverIncognito", false);
        Estado_AIncognitos[x] = false;
        Estado_AIncognitos[y] = false;
        AudioS.clip = NoAcertaste[Random.Range(0, 2)]; AudioS.Play();
        TiempoTocar = 1.1f;
        IndexG = 0;
    }

    //Se ejecuta al tocar los animales.
    public void MostrarAnimal(int x){
        if(TiempoTocar <= 0f){
            IndexG = x;
            AnimatorC_Incognitos[IndexG].SetBool("RemoverIncognito", true);
            Estado_AIncognitos[IndexG] = true;
            TiempoTocar = 1.1f;   
        }    
    }

//*****************************************************************
//******************* FUNCION CONTROL ANIMAL **********************
//***************************************************************** 
    public void ControlAnimal(){
        //Comprueba Ardillas.
        if(Estado_AIncognitos[0] == true && Estado_AIncognitos[1] == true){
            ParejaCorrecta(0, 1); Cont++;
        }else if(Estado_AIncognitos[0] == true && IndexG != 0){
            ParejaIncorrecta(0, IndexG);
        }else if(Estado_AIncognitos[1] == true && IndexG != 1){
            ParejaIncorrecta(1, IndexG);
        }

        //Comprueba Castores.
        if(Estado_AIncognitos[2] == true && Estado_AIncognitos[3] == true){
            ParejaCorrecta(2, 3); Cont++;
        }else if(Estado_AIncognitos[2] == true && IndexG != 2){
            ParejaIncorrecta(2, IndexG);
         }else if(Estado_AIncognitos[3] == true && IndexG != 3){
            ParejaIncorrecta(3, IndexG);
        }

        //Comprueba Cebras.
        if(Estado_AIncognitos[4] == true && Estado_AIncognitos[5] == true){
            ParejaCorrecta(4, 5); Cont++;
        }else if(Estado_AIncognitos[4] == true && IndexG != 4){
            ParejaIncorrecta(4, IndexG);
        }else if(Estado_AIncognitos[5] == true && IndexG != 5){
            ParejaIncorrecta(5, IndexG);
        }

        //Comprueba Cerditos.
        if(Estado_AIncognitos[6] == true && Estado_AIncognitos[7] == true){
            ParejaCorrecta(6, 7); Cont++;
        }else if(Estado_AIncognitos[6] == true && IndexG != 6){
            ParejaIncorrecta(6, IndexG);
        }else if(Estado_AIncognitos[7] == true && IndexG != 7){
            ParejaIncorrecta(7, IndexG);
        } 

        //Comprueba Conejos.
        if(Estado_AIncognitos[8] == true && Estado_AIncognitos[9] == true){
            ParejaCorrecta(8, 9); Cont++;
        }else if(Estado_AIncognitos[8] == true && IndexG != 8){
            ParejaIncorrecta(8, IndexG);
        }else if(Estado_AIncognitos[9] == true && IndexG != 9){
            ParejaIncorrecta(9, IndexG);
        } 

        //Comprueba Delfines.
        if(Estado_AIncognitos[10] == true && Estado_AIncognitos[11] == true){
            ParejaCorrecta(10, 11); Cont++;
        }else if(Estado_AIncognitos[10] == true && IndexG != 10){
            ParejaIncorrecta(10, IndexG);
        }else if(Estado_AIncognitos[11] == true && IndexG != 11){
            ParejaIncorrecta(11, IndexG);
        }

        //Comprueba Gatos.
        if(Estado_AIncognitos[12] == true && Estado_AIncognitos[13] == true){
            ParejaCorrecta(12, 13); Cont++;
        }else if(Estado_AIncognitos[12] == true && IndexG != 12){
            ParejaIncorrecta(12, IndexG);
        }else if(Estado_AIncognitos[13] == true && IndexG != 13){
            ParejaIncorrecta(13, IndexG);
        }

        //Comprueba Leones.
        if(Estado_AIncognitos[14] == true && Estado_AIncognitos[15] == true){
            ParejaCorrecta(14, 15); Cont++;
        }else if(Estado_AIncognitos[14] == true && IndexG != 14){
            ParejaIncorrecta(14, IndexG);
        }else if(Estado_AIncognitos[15] == true && IndexG != 15){
            ParejaIncorrecta(15, IndexG);
        }

        //Comprueba Mapaches.
        if(Estado_AIncognitos[16] == true && Estado_AIncognitos[17] == true){
            ParejaCorrecta(16, 17); Cont++;
        }else if(Estado_AIncognitos[16] == true && IndexG != 16){
            ParejaIncorrecta(16, IndexG);
        }else if(Estado_AIncognitos[17] == true && IndexG != 17){
            ParejaIncorrecta(17, IndexG);
        }

        //Comprueba Osos.
        if(Estado_AIncognitos[18] == true && Estado_AIncognitos[19] == true){
            ParejaCorrecta(18, 19); Cont++;
        }else if(Estado_AIncognitos[18] == true && IndexG != 18){
            ParejaIncorrecta(18, IndexG);
        }else if(Estado_AIncognitos[19] == true && IndexG != 19){
            ParejaIncorrecta(19, IndexG);
        }
                
        //Comprueba Perros.
        if(Estado_AIncognitos[20] == true && Estado_AIncognitos[21] == true){
            ParejaCorrecta(20, 21); Cont++;
        }else if(Estado_AIncognitos[20] == true && IndexG != 20){
            ParejaIncorrecta(20, IndexG);
        }else if(Estado_AIncognitos[21] == true && IndexG != 21){
            ParejaIncorrecta(21, IndexG);
        }

        //Comprueba Pulpos.
        if(Estado_AIncognitos[22] == true && Estado_AIncognitos[23] == true){
            ParejaCorrecta(22, 23); Cont++;
        }else if(Estado_AIncognitos[22] == true && IndexG != 22){
            ParejaIncorrecta(22, IndexG);
        }else if(Estado_AIncognitos[23] == true && IndexG != 23){
            ParejaIncorrecta(23, IndexG);
        }


        //Comprueba si ya se asignaron todas las parejas.
        if(Cont == 12){
            TiempoAnimal = 3f;
            JugarDeNuevo = true;
        }

    }

    //Volvemos a jugar el MemoTest al escoger Si.
    public void EscogerSI(){
        Cont = 0;
        for(int i = 0; i < DesBotones.Length; i++){ DesBotones[i].SetActive(true); }
        PAMT_Script.AsigPosMemoTest();
        for(int i = 0; i < AnimatorC_Conocidos.Length; i++){
                AnimatorC_Conocidos[i].SetBool("RemoverConocido", false);
        }
        AudioS.clip = Adivina; AudioS.Play();
        TiempoAnimal = 3f; JugarDeNuevo = false;
        UIEscoger.SetActive(false);
    }

//***************************************************************** 

    void Update(){
        if(TiempoAnimal < 0f){
            if(JugarDeNuevo == false){
                for(int i = 0; i < AnimatorC_Incognitos.Length; i++){
                    AnimatorC_Incognitos[i].SetBool("RemoverIncognito", false);
                }
                TiempoAnimal = 0f;
            }else{
                for(int i = 0; i < DesBotones.Length; i++){ DesBotones[i].SetActive(false); }
                UIEscoger.SetActive(true); 
            }
            
        }else if(TiempoAnimal == 0){

        }else{
            TiempoAnimal -= Time.deltaTime;
        }

        if(TiempoTocar > 0f){
            TiempoTocar -= Time.deltaTime;
        }
    }


}
