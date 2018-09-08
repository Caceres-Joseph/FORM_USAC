/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;
 
import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import Analyzer.Tree.nodeModel; 

/**
 *
 * @author joseph
 */
public class padreEncuesta extends nodeModel{
  
    public padreEncuesta(tablaSimbolos tabla) {
        this.tablaSimbolos=tabla;
        this.nombreNodo="padreEncuesta";
    }
    
    
    @Override
    public void execute() {
//        this.mensajeDeEjecucion();
        this.ejectuarHijos();
        System.out.println(getCadenaClass());
        
    }
    
    public String getCadenaClass(){
        String retorno="";
        
        retorno="Clase prueba{";
        retorno+="\n\tPrincipal(){";
        retorno+="\n\t\tNuevo prueba();";
        retorno+="\n\t}";
        
        retorno+=getCadenaMetodos();
        
        retorno+="\n\tFormulario prueba(){";
        retorno+="\n\t\tRespuestas resp;";
        retorno+=getLlamadoFunciones();
        retorno+="\n\t}";
        
        retorno+="\n}";
        
        return retorno;
    }
    
    public String getCadenaMetodos(){
        String retorno="";
        for (String key : tablaSimbolos.lstSimbolos.keySet()) {
            
            elementoSimbolo tempSimbolo=tablaSimbolos.lstSimbolos.get(key);
            retorno+=tempSimbolo.cadenaContenido;
            
        }
        return retorno;
    }
    
    public String getLlamadoFunciones(){
        String retorno="";
        for (String key : tablaSimbolos.lstSimbolos.keySet()) {
            
            elementoSimbolo tempSimbolo=tablaSimbolos.lstSimbolos.get(key);
            retorno+=tempSimbolo.cadenaFinal;
            
        }
        return retorno; 
    }

     
    
}
