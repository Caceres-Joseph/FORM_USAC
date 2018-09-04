/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Columnas.Encuesta;

import Analyzer.Javacc_Exp.parser_exp;
import Analyzer.Javacc_Param.parser_param;
import Analyzer.Javacc_TipoCalculo.parser_calculo;
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

    public HashMap<String, cell> tempLstParametros;
    public int tipo = 0;

    public expresion(tablaSimbolos tabla, cell celda) {
        this.tablaSimbolos = tabla;
        this.celda = celda;
        this.tempLstParametros = new LinkedHashMap<>();
    }

    public String getCadena() {
        String retorno = "= ";
        String cadena = celda.val;
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_exp par = new parser_exp();
        par.inicializar(tablaSimbolos, stream, celda);
        retorno += par.cadenaSalida;
        retorno += ";";
        this.tempLstParametros = parser_exp.tempLstParametros;
        this.tipo = parser_exp.tipo;

        //System.out.println("$"+parser_exp.tipo);
        return retorno;
    }

    public String getCadenaReq() {
        String retorno = "";
        String cadena = celda.val;
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_exp par = new parser_exp();
        par.inicializar(tablaSimbolos, stream, celda);
        retorno += par.cadenaSalida;
        //retorno+=";";
        this.tempLstParametros = parser_exp.tempLstParametros;
        this.tipo = parser_exp.tipo;

        //System.out.println("$"+parser_exp.tipo);
        return retorno;
    }

    String getCadenaMulti() {
        String retorno = "";

        String cadena = celda.val;
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_exp par = new parser_exp();
        par.inicializar(tablaSimbolos, stream, celda);
        retorno += par.cadenaSalida;
        //retorno+=";";
        this.tempLstParametros = parser_exp.tempLstParametros;
        this.tipo = parser_exp.tipo;

        return retorno;
    }

    public HashMap<String, String> getCadenaParametro() {
        HashMap<String, String> retorno;
        String cadena = celda.val;
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_param par = new parser_param();
        retorno = par.initParametro2(tablaSimbolos, stream, celda);

        //retorno+=";";
//        this.tempLstParametros = parser_param.tempLstParametros;
//        this.tipo = parser_exp.tipo;
        return retorno;
    }

    public String getCadenaAplicable() {
        String retorno = "";
        String cadena = celda.val;
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_param par = new parser_param();
        par.inicializar(tablaSimbolos, stream, celda);
        retorno += par.cadenaSalida;
        //retorno+=";"; 
        this.tipo = parser_exp.tipo;
        return retorno;
    }

    public String getCadenaTipoCalculo() {
        String retorno = "";
        String cadena = celda.val;
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_calculo par = new parser_calculo();
        par.inicializar(tablaSimbolos, stream, celda);

        //retorno+=";"; 
        this.tipo = parser_exp.tipo;

        switch (parser_calculo.tipo) {
            case 0:
                retorno="nota";
                break;
            case 1:
                retorno="entero";
                break;
            case 2:
                retorno="decimal";
                break;
            case 3:
                retorno="booleano";
                break;
            case 4:
                retorno="cadena";
                break;
            case 5:
                retorno="fecha";
                break;
            case 6:
                retorno="fechahora";
                break;
            case 7:
                retorno="hora";
                break;
            default:
                retorno="void";
                break;
        }
        
        return retorno;
    }
}
