using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPuerta : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform door,door2;
    public AudioClip clip,clip2,clip3;
    public AudioSource source;
    public MoverCuartoArriba moverObjetos;
    public LuzParpadeante luzP;
    public bool isClosed;
    public PersonajeSusto personaje;
    public GameObject segundoTrigger;
    public GameObject personajeSusto;
    


   // public GameObject puerta;
    void Start()
    {
        personajeSusto.SetActive(false);
        segundoTrigger.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("PuertaBano"))
        {
            Debug.Log("Entro");
            moverObjetos.GetComponent<MoverCuartoArriba>().MoverObj();
            luzP.GetComponent<LuzParpadeante>().parpadearLuz();
            door.GetComponent<Door>().StartCoroutine("Closing");
            door2.GetComponent<Door>().StartCoroutine("Closing");

            source.PlayOneShot(clip);
            source.PlayOneShot(clip2);

            Destroy(col.gameObject);

            StartCoroutine(waitBeforeOpen());
            segundoTrigger.SetActive(true);
            personajeSusto.SetActive(true);

            }


        if (col.CompareTag("TriggerEscalera"))
        {
            Debug.Log("Entro a la escalera");
            personaje.GetComponent<PersonajeSusto>()._active = true;
            personaje.GetComponent<PersonajeSusto>().PrimerMovimiento();
            source.PlayOneShot(clip3);
            Destroy(col.gameObject);
            personajeSusto.SetActive(false);

        }
        }

    IEnumerator waitBeforeOpen()
    {
        
        
        door.GetComponent<Door>().isLocked = true;
        yield return new WaitForSeconds(6);
        //isClosed = false;
        //estado.isLocked = false;
        door.GetComponent<Door>().isLocked = false;
    }
    }

