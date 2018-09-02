/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;
 
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
        this.mensajeDeEjecucion();
        this.ejectuarHijos();
        
    }

     
    
}
