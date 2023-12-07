using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] int estres;
    [SerializeField] int sociabilidad;
    [SerializeField] int cansancio;
    [SerializeField] int conocimiento;


    private void Start()
    {
        GameManager.Instance.setPrefs();

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
        estres = menorA0(estres);
        
    }
    public void bajarSociabilidad(int bajada)
    {
        sociabilidad -= bajada;
        sociabilidad =  menorA0(sociabilidad);
    }
    public void bajarCansancio(int bajada)
    {
        cansancio -= bajada;
        cansancio = menorA0(cansancio);
    }
    public void bajarConocimiento(int bajada)
    {
        conocimiento -= bajada;
        conocimiento = menorA0(conocimiento);
    }
    private int menorA0(int stat) 
    {
        if (stat < 0)
            stat = 0;
        return stat;
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

    public void setearStats() 
    {
        estres = PlayerPrefs.GetInt("EstresPref");
        sociabilidad = PlayerPrefs.GetInt("SociabilidadPref");
        cansancio = PlayerPrefs.GetInt("CansancioPref");
        conocimiento = PlayerPrefs.GetInt("ConocimientoPref");
        
    }
    public void setStatsPrefs() 
    {
        PlayerPrefs.SetInt("EstresPref",estres);
        PlayerPrefs.SetInt("SociabilidadPref",sociabilidad);
        PlayerPrefs.SetInt("CansancioPref",cansancio);
        PlayerPrefs.SetInt("ConocimientoPref",conocimiento);
    }
    public void resetPrefs() 
    {
        PlayerPrefs.SetInt("EstresPref", 0);
        PlayerPrefs.SetInt("SociabilidadPref", 0);
        PlayerPrefs.SetInt("CansancioPref", 0);
        PlayerPrefs.SetInt("ConocimientoPref", 0);
    }
    #endregion
}
