/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Columnas;

import Analyzer.Javacc_Exp.parser_exp;
import Analyzer.Tree.Tablas.tablaSimbolos;
import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class expresion {

    public tablaSimbolos tablaSimbolos;
    public cell celda;

    
    public   HashMap<String, cell> tempLstParametros;
    public int tipo=0;
    
    public expresion(tablaSimbolos tabla, cell celda) {
        this.tablaSimbolos = tabla;
        this.celda = celda;
        this.tempLstParametros=new LinkedHashMap<>();  
    }

    public String getCadena() {
        String retorno="= ";
        String cadena = celda.val;
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_exp par = new parser_exp();
        par.inicializar(tablaSimbolos, stream, celda);
        retorno+=par.cadenaSalida;
        retorno+=";";
        this.tempLstParametros=parser_exp.tempLstParametros;
        this.tipo=parser_exp.tipo;
         
        //System.out.println("$"+parser_exp.tipo);
        return retorno;
    }
 
    public String getCadenaReq() {
        String retorno="";
        String cadena = celda.val;
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_exp par = new parser_exp();
        par.inicializar(tablaSimbolos, stream, celda);
        retorno+=par.cadenaSalida;
        //retorno+=";";
        this.tempLstParametros=parser_exp.tempLstParametros;
        this.tipo=parser_exp.tipo;
         
        //System.out.println("$"+parser_exp.tipo);
        return retorno;
    }
}
