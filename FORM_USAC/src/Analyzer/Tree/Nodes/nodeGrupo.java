/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;
 
import Analyzer.Tree.Tablas.tablaSimbolos;
import Analyzer.Tree.nodeModel; 
import Analyzer.Tree.nodeModelGrupoCiclo;

/**
 *
 * @author joseph
 */
public class nodeGrupo extends nodeModelGrupoCiclo{
      
    public nodeGrupo(tablaSimbolos tabla) {
        this.tablaSimbolos=tabla;
        this.nombreNodo="nodeGrupo"; 
    }
    @Override
    public void execute() {
        this.mensajeDeEjecucion();
    }
 
}
