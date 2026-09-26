using System.Collections;
using UnityEngine;

public class PuertaTrampa : MonoBehaviour
{
    [Header("Rotación de la puerta")]
    public float anguloAbierto = -90f;
    public float velocidadRotacion = 2f;

    [Header("Trampa del suelo (opcional, para más adelante)")]
    public float tiempoAntesDeTrampa = 3f;

    private bool puertaAbierta = false;
    private bool puertaCerrada = false;
    private Quaternion rotacionCerrada;
    private Quaternion rotacionAbierta;

    void Start()
    {
        rotacionCerrada = transform.localRotation;
        rotacionAbierta = Quaternion.Euler(0, anguloAbierto, 0);
    }

    public void AbrirPuerta()
    {
        if (!puertaAbierta)
        {
            puertaAbierta = true;
            StopAllCoroutines();
            StartCoroutine(RotarPuerta(rotacionAbierta));
        }
    }

    public void CerrarPuerta()
    {
        if (!puertaCerrada)
        {
            puertaCerrada = true;
            StopAllCoroutines();
            StartCoroutine(RotarPuerta(rotacionCerrada));
            // Aquí después conectamos la cuenta regresiva de la trampa del suelo
        }
    }

    private IEnumerator RotarPuerta(Quaternion objetivo)
    {
        while (Quaternion.Angle(transform.localRotation, objetivo) > 0.5f)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, objetivo, Time.deltaTime * velocidadRotacion);
            yield return null;
        }
        transform.localRotation = objetivo;
    }
}