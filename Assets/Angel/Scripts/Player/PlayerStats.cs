using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] int estres;
    [SerializeField] int sociabilidad;
    [SerializeField] int cansancio;
    [SerializeField] int conocimiento;

    [SerializeField] bool testStats;


    private void Start()
    {
        if (!testStats)
        {
            
            setearStats();
        }
    }
    #region SUBIR_ESTADISTICAS
    public void subirEstres(int aumento) 
    {
        estres += aumento;
        if (estres >= 10)
            GameManager.Instance.gameOver();
        
    }
    public void subirSociabilidad(int aumento) 
    {
        sociabilidad += aumento;
        if (sociabilidad >= 10)
            sociabilidad = 10;
        
    }
    public void subirCansancio(int aumento)
    {
        cansancio += aumento;
        if (cansancio >= 10)
            GameManager.Instance.perderDia();
        
    }
    public void subirConocimiento(int aumento)
    {
        conocimiento += aumento;
        if (conocimiento >= 10)
            conocimiento = 10;
        
    }
    #endregion

    #region BAJAR_ESTADISTICAS
    public void bajarEstres(int bajada)
    {
        estres -= bajada;
        menorA0(estres);   
    }
    public void bajarSociabilidad(int bajada)
    {
        sociabilidad -= bajada;
        menorA0(sociabilidad);
    }
    public void bajarCansancio(int bajada)
    {
        cansancio -= bajada;
        menorA0(cansancio);
    }
    public void bajarConocimiento(int bajada)
    {
        conocimiento -= bajada;
        menorA0(conocimiento);
    }
    public void menorA0(int stat) 
    {
        if (stat < 0)
            stat = 0;
        
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

    #region FUNCIONES EXTRA

    private void setearStats() 
    {
        estres = PlayerPrefs.GetInt("EstresPref");
        sociabilidad = PlayerPrefs.GetInt("SociabilidadPref");
        cansancio = PlayerPrefs.GetInt("CansancioPref");
        conocimiento = PlayerPrefs.GetInt("ConocimientoPref");
        
    }

    #endregion
}
