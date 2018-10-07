/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree;

import Analyzer.Tree.Nodes.nodeRaiz;
import Analyzer.Tree.Tablas.*; 
import java.util.LinkedHashMap;
import java.util.Map;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class tree {
    public nodeRaiz raiz; 
    public tablaSimbolos tablaSimbolos;
    public static String salida="";
    public static String idForm="idForm";
    public static String importar="importar(libForm.xform);";
    public static String principal= "";
    public static String codigoGlobal="";
    public static String estilo="todo";
    public static  Map<String, String> listas =  new LinkedHashMap<>();
    
    
    public static void resetVariables(){
        salida="";
        idForm="";
        importar="importar(libForm.xform);";
        principal="";
        codigoGlobal="";
        estilo="todo";
        listas  = new LinkedHashMap<>();
        
    }

    public static void imprimirListas() {
        System.out.println("========= LISTas ================0");
        for (Map.Entry<String, String> entry : listas.entrySet()) {
            System.out.println(entry.getKey() + " = " + entry.getValue());
        } 
    }
    
    public static void imprimirVariables(){
        System.out.println("idForm ->"+idForm);
        System.out.println("importar ->"+importar); 
        System.out.println("principal ->"+principal);
        System.out.println("codigoGlobal ->"+codigoGlobal);
        System.out.println("estilo ->"+estilo);
    }
    
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
