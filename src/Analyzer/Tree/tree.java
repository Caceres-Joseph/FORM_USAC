/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree;

import Analyzer.Tree.Tablas.*;
import java.util.ArrayList;

/**
 *
 * @author joseph
 */
public class tree {
    public ArrayList<nodeModel> raiz;
    public tablaErrores tablaErrores;
    public tablaSimbolos tablaSimbolos;
    
    
    public tree(){
        raiz=new ArrayList<>();
        tablaErrores=new tablaErrores();
        tablaSimbolos=new tablaSimbolos(); 
    }
    
    
    //Tiene que haber una tabla de símbolos
    //Tiene que haber una tabla de errores
    //nodo raiz
    
    
}
