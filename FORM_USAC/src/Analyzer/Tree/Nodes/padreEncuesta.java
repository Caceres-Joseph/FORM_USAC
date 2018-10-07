/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;
 
import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import Analyzer.Tree.nodeModel; 
import Analyzer.Tree.tree;

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
        //System.out.println(getCadenaClass());
        tree.salida=getCadenaClass();
    }
    
    public String getCadenaClass(){
        String retorno="";
        retorno+= tree.importar;
        
        retorno+="\nClase principal{";
        retorno+="\n\t"+tree.codigoGlobal;
        
        retorno+="\n\tPrincipal(){";
        retorno +="\n\t"+tree.principal;
        retorno+="\n\t\tNuevo "+tree.idForm+"()."+tree.estilo+";";
        retorno+="\n\t}";
        
        retorno+=getCadenaMetodos();
        
        retorno+="\n\tFormulario "+tree.idForm+"(){";
        retorno+="\n\t\tRespuesta resp = nuevo Respuesta();";
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
