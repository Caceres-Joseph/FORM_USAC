/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Tablas;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 *
 * @author joseph
 */
public class tablaErrores {
    public List<elementoError> tablaError=new ArrayList<>();
    public List<elementoError> listaConsola=new ArrayList<>();
    
    public void insertar(elementoError nodo){
        tablaError.add(nodo);
    }
    
    
    public void println(Object str){
        String mensaje=String.valueOf(str);
        System.out.println("> "+mensaje);
    }
    
    
    public void print(Object str){
        String mensaje=String.valueOf(str);
        System.out.print(mensaje);
    }
    
    
    public void insertErrorSyntax(int linea, int columna, String mensaje){
        elementoError elem=new elementoError();
        elem.tipo="Semantico";
        elem.linea=String.valueOf(linea+1);
        elem.columna=String.valueOf(columna+1);
        elem.descripcion=mensaje;
        
        this.tablaError.add(elem);
        println("[Error]Semantico-> "+mensaje);
    }
    
    public void insertErrorLexical(int linea, int columna,String mensaje){
        elementoError elem=new elementoError();
        elem.tipo="Semantico";
        elem.linea=String.valueOf(linea+1);
        elem.columna=String.valueOf(columna+1);
        elem.descripcion=mensaje;
        this.tablaError.add(elem);
        println("[Error]Semantico-> "+mensaje);
    }
    
    public void insertErrorSemantic(int linea, int columna, String mensaje){
        
        elementoError elem=new elementoError();
        elem.tipo="Semantico";
        elem.linea=String.valueOf(linea+1);
        elem.columna=String.valueOf(columna+1);
        elem.descripcion=mensaje;
        this.tablaError.add(elem);
        println("[Error]Semantico-> "+mensaje);
 
    }
    
    
    public void concat(tablaErrores tab){
        List<elementoError> mergeList=new ArrayList<>(); 
        mergeList.addAll(tab.tablaError);
        mergeList.addAll(this.tablaError);
        this.tablaError = mergeList; 
        
        List<elementoError> mergeList2=new ArrayList<>(); 
        mergeList2.addAll(tab.tablaError);
        mergeList2.addAll(this.tablaError);
        this.listaConsola = mergeList2;
        
    }
    
    
    
    public void imprimir() {
        System.out.println("-----cError--------");
        for (elementoError lstErrore : this.tablaError) {
            System.out.println("}");
            System.out.print("Linea{");
            System.out.print(lstErrore.linea);
            System.out.println("}");
            System.out.print("Columna{");
            System.out.print(lstErrore.columna);
            System.out.println("}");
            System.out.print("Tipo{");
            System.out.print(lstErrore.tipo);
            System.out.println("}");
            System.out.print("Descripcion{");
            System.out.print(lstErrore.descripcion);
            System.out.println("}");
        }
    }
}
