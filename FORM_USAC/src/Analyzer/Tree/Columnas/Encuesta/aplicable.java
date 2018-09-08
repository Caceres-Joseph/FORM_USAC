/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Columnas.Encuesta;

import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class aplicable extends etiqueta {

    public aplicable(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }

    /**
     *
     * @return
     */
    @Override
    public String getCadena() {
        String retorno = "";

        cell celdaCalc = simbolo.lstAtributos.get("aplicable");

        if (celdaCalc == null) {
            if (simbolo.cadenaPre.length() > 4) {
                retorno += "\n\t\t" + simbolo.cadenaPre;
            }

            retorno += "\n\t\t" + simbolo.codigoEjecucion;

            if (simbolo.cadenaPost.length() > 4) {
                retorno += "\n\t\t" + simbolo.cadenaPost;
            }
            return retorno;
        }

        retorno = "\n\t\tSi(" + calcular(celdaCalc) + "){";
        
        if (simbolo.cadenaPre.length() > 4) {
            retorno += "\n\t\t\t" + simbolo.cadenaPre;
        }

        retorno += "\n\t\t\t" + simbolo.codigoEjecucion;

        if (simbolo.cadenaPost.length() > 4) {
            retorno += "\n\t\t\t" + simbolo.cadenaPost;
        }

        retorno += "\n\t\t}";
        
        return retorno;
    }
    
    public String getCadenaNivel2() {
        String retorno = "";

        cell celdaCalc = simbolo.lstAtributos.get("aplicable");

        if (celdaCalc == null) {
            if (simbolo.cadenaPre.length() > 4) {
                retorno += "\n\t\t\t" + simbolo.cadenaPre;
            }

            retorno += "\n\t\t\t" + simbolo.codigoEjecucion;

            if (simbolo.cadenaPost.length() > 4) {
                retorno += "\n\t\t\t" + simbolo.cadenaPost;
            }
            return retorno;
        }

        retorno = "\n\t\t\tSi(" + calcular(celdaCalc) + "){";
        
        if (simbolo.cadenaPre.length() > 4) {
            retorno += "\n\t\t\t\t" + simbolo.cadenaPre;
        }

        retorno += "\n\t\t\t\t" + simbolo.codigoEjecucion;

        if (simbolo.cadenaPost.length() > 4) {
            retorno += "\n\t\t\t\t" + simbolo.cadenaPost;
        }

        retorno += "\n\t\t\t}";
        
        return retorno;
    }
    
    

    public String calcular(cell celda) {
        String retorno = "";

        expresion exp = new expresion(tablaSimbolos, celda);
        String temp1 = exp.getCadenaAplicable();  
        retorno = temp1; 
        return retorno;
    }

}
