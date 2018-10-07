/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;

import Analyzer.Tree.Tablas.tablaSimbolos;
import Analyzer.Tree.nodeModel;
import Analyzer.Tree.tree;

/**
 *
 * @author joseph
 */
public class nodeRaiz extends nodeModel {

    public nodeRaiz(tablaSimbolos tabla) {
        this.tablaSimbolos = tabla;
        this.nombreNodo = "padreRaiz";
    }

    @Override
    public void execute() {
        //this.mensajeDeEjecucion();
        //primero hay que ejecutar configuracion
        //imprimir();
       this.ejecutar2();
       // ejectuarHijos();
//        ejecutarPrueba();

        
    }
    
    public void ejecutar2(){
        
        nodeModel configuracion= getNodo("padreconfiguracion");
        if(configuracion!=null){
            configuracion.execute();
        }
        
        
        //System.out.println("[nodeRaiz]entrada  treee->"+tree.salida);
        
        
        
        nodeModel opciones= getNodo("padreopcion");
        if(opciones!=null){ 
            //opciones.imprimir();
            opciones.execute(); 
        }
        
        
        nodeModel encuesta= getNodo("padreEncuesta");
        if(encuesta!=null){
            
            encuesta.execute(); 
        }
    }
    
   
    
    public void ejecutarPrueba(){
        if (tablaSimbolos!=null) {
            tablaSimbolos.tablaErrores.println("[nodeModel]"+this.nombreNodo+"_ejectuarHijos()");
        }
        for (nodeModel model : children) {
            System.out.println(model.nombreNodo);
//            model.execute();
        }
    }
    
    
}
