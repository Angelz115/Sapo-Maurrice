using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] int estres;
    [SerializeField] int sociabilidad;
    [SerializeField] int cansancio;
    [SerializeField] int conocimiento;
    

    #region SUBIR_ESTADISTICAS
    public void subirEstres(int aumento) 
    {
        estres += aumento;
    }
    public void subirSociabilidad(int aumento) 
    {
        sociabilidad += aumento;
    }
    public void subirCansancio(int aumento)
    {
        cansancio += aumento;
    }
    public void subirConocimiento(int aumento)
    {
        conocimiento += aumento;
    }
    #endregion

    #region BAJAR_ESTADISTICAS
    public void bajarEstres(int bajada)
    {
        estres -= bajada;
    }
    public void bajarSociabilidad(int bajada)
    {
        sociabilidad -= bajada;
    }
    public void bajarCansancio(int bajada)
    {
        cansancio -= bajada;
    }
    public void bajarConocimiento(int bajada)
    {
        conocimiento -= bajada;
    }
    #endregion

    #region CONSEGUIR_ESTADISTICAS
    public int valorEstres() 
    {
        return estres;
    }
    public int valorScoiabilidad() 
    {
        return sociabilidad;
    }
    public int valorCansancio() 
    {
        return cansancio;
    }
    public int valorConocimiento() 
    {
        return conocimiento;
    }
    #endregion
}
