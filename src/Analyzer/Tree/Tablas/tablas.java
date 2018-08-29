/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Tablas;

/**
 *
 * @author joseph
 */
public class tablas {
    public tablaErrores tablaError=new tablaErrores();
    public tablaSimbolos tablaSimbolos1=new tablaSimbolos();
    
    
        
    public void println(Object str){
        String mensaje=String.valueOf(str);
        System.out.println("> "+mensaje);
    }
    
    
    public void print(Object str){
        String mensaje=String.valueOf(str);
        System.out.print(mensaje);
    }
    
}
