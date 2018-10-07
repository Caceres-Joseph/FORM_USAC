/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree;

import Analyzer.Tree.NodTemp.nodoString;
import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import java.util.ArrayList; 
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class nodeModel {
    
    public elementoSimbolo simbolo;
    
    public String nombreNodo = "";
    public atributos atrib = new atributos();
    public ArrayList<nodeModel> children = new ArrayList<>();

    
    public String cadenaContenido="";
    
    public tablaSimbolos tablaSimbolos;

    //Esto es para el grupo y ciclo
    String tId_Grupo_Ciclo;

    
    
    
    public void execute() {
        
//        tablaSimbolos.tablaErrores.print("[nodeModel]"+this.nombreNodo+"_execute()");
 

    } 

    public nodeModel getNodo(String nombre) {
  
        for (nodeModel model : children) {
            if(model.nombreNodo.toLowerCase().equals(nombre.toLowerCase())){
                return model;
            }
        }
        return null;
    }
    
    
    
    public void executeSinLlamar(nodoString nodCad) {
//        tablaSimbolos.tablaErrores.print("[nodeModel]"+this.nombreNodo+"_execute()");
    } 
    
    
     public void ejectuarHijosSinLlamar(nodoString nodCad){
 
        for (nodeModel model : children) {
//            System.out.println(model.nombreNodo);
            model.executeSinLlamar(nodCad);
        }
    }
    
    public void ejectuarHijos(){
        if (tablaSimbolos!=null) {
            tablaSimbolos.tablaErrores.println("[nodeModel]"+this.nombreNodo+"_ejectuarHijos()");
        }
        for (nodeModel model : children) {
//            System.out.println(model.nombreNodo);
            model.execute();
        }
    }
    
    public void mensajeDeEjecucion(){
        if (tablaSimbolos!=null) {
            tablaSimbolos.tablaErrores.print("[nodeModel]"+this.nombreNodo+"_execute() idPregunta->");
           cell temp= this.atrib.get("idpregunta");
            if(temp!=null){ 
                String idPregunta=temp.val;
                this.tablaSimbolos.tablaErrores.println(idPregunta);
            }else{
                tablaSimbolos.tablaErrores.println("null");
            } 
        }

        
    }
    
    public void insertChildren(nodeModel value) {
        children.add(value);
    }

    public void imprimir() {
        System.out.println("---" + nombreNodo + "---");
        System.out.println("atributos[");
        atrib.imprimir();
        System.out.println("]");
        imprimirRecursivo(children, nombreNodo);
    }

    public void imprimirRecursivo(ArrayList<nodeModel> elem, String padre) {
        
        for (nodeModel model : elem) {
            System.out.println("--------Hijos de "+padre+"---------------------------");
            System.out.println("---" + model.nombreNodo + "---");
            System.out.println("atributos[");
            model.atrib.imprimir();
            System.out.println("]");
            imprimirRecursivo(model.children, model.nombreNodo);
        }
    }


}
