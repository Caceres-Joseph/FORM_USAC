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
public class padreConfiguracion extends nodeModel {
 
    public padreConfiguracion(tablaSimbolos tabla) {
        this.tablaSimbolos=tabla;
        this.nombreNodo="padreConfiguracion";
    }
   
    
    @Override
    public void execute() {
        this.ejectuarHijos();
        //System.out.println("Ejecutando el nodo configuracion");
        //System.out.println(tree.salida);
        //imprimir();
    }
    
 
}
