using UnityEngine;

public class TriggerPuerta : MonoBehaviour
{
    public PuertaTrampa puerta;
    public bool esTriggerDeApertura = true; // marca false para el de cierre

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (esTriggerDeApertura)
                puerta.AbrirPuerta();
            else
                puerta.CerrarPuerta();
        }
    }
}