/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;
 
import Analyzer.Tree.Columnas.columna;
import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import Analyzer.Tree.nodeModel; 
import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.LinkedList;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class nodePregunta extends nodeModel {
      

    
    public nodePregunta(tablaSimbolos tabla) {
        this.tablaSimbolos=tabla;
        this.nombreNodo="nodePregunta";
    }
    
    @Override
    public void execute() {
//        this.mensajeDeEjecucion();
        generandoContenido();
    }
    
    
    public void generandoContenido(){
        cell idPregunta=atrib.get("idpregunta");
        elementoSimbolo simbolo=new elementoSimbolo(idPregunta, atrib); 
        tablaSimbolos.insertSimbol(idPregunta.val, simbolo);
        
        columna colum=new columna(tablaSimbolos, simbolo);
        
        this.cadenaContenido+="\n\tPregunta "+idPregunta.val+"("+"){";
        
        cadenaContenido+=colum.getTipo();
        
        cadenaContenido+="\n\t}"; 
        System.out.println(cadenaContenido);
    }
    
    
    public String getParametros(){
        String retorno="";
        
        
        return retorno; 
    }
    public String getCuerpo(){
        String retorno="";
        
        
        return retorno;
    }
    
 
}
