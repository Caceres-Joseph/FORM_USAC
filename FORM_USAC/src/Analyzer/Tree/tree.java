/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree;

import Analyzer.Tree.Nodes.nodeRaiz;
import Analyzer.Tree.Tablas.*; 

/**
 *
 * @author joseph
 */
public class tree {
    public nodeRaiz raiz; 
    public tablaSimbolos tablaSimbolos;
    
    
    public tree(){
        raiz=new nodeRaiz(tablaSimbolos);  
        tablaSimbolos=new tablaSimbolos(); 
    }
    
    public void execute(){ 
      
        raiz.execute();
    }
    
    
    //Tiene que haber una tabla de símbolos
    //Tiene que haber una tabla de errores
    //nodo raiz
    
    
}
