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
public class repeticion extends etiqueta {

    public repeticion(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }

    /**
     *
     * @return
     */
    @Override
    public String getCadena() {
        String retorno = "";
        aplicable apli = new aplicable(tablaSimbolos, simbolo);

        cell celdaCalc = simbolo.lstAtributos.get("repeticion");

        if (celdaCalc == null) {
            retorno = apli.getCadena();
            return retorno;
        }

//        if (simbolo.tipoPregunta.equals("entero") || simbolo.tipoPregunta.equals("decimal")) {
            retorno += "\n\t\tPara(Entero " + simbolo.idPregunta + "_it=0 ; " + simbolo.idPregunta + "_it <" + calcular(celdaCalc) + "; " + simbolo.idPregunta + "_iter++){";

            retorno += apli.getCadenaNivel2();
            retorno += "\n\t\t}";
//        } else {
//            retorno = apli.getCadena();
//            tablaSimbolos.tablaErrores.insertErrorSemantic(celdaCalc.ambito, celdaCalc.posY, celdaCalc.posX, "No se puede iterar el tipo:" + simbolo.tipoPregunta);
//        }

        return retorno;
    }
    
    public String getCadena2() {
        String retorno = "";
        aplicable apli = new aplicable(tablaSimbolos, simbolo);

        cell celdaCalc = simbolo.lstAtributos.get("repeticion");

        if (celdaCalc == null) {
            retorno = apli.getCadena();
            return retorno;
        }

//        if (simbolo.tipoPregunta.equals("entero") || simbolo.tipoPregunta.equals("decimal")) {
            retorno += "\n\t\tPara(Entero " + simbolo.idPregunta + "_it=0 ; " + simbolo.idPregunta + "_it <" + calcular(celdaCalc) + "; " + simbolo.idPregunta + "_iter++){";

           
//        } else {
//            retorno = apli.getCadena();
//            tablaSimbolos.tablaErrores.insertErrorSemantic(celdaCalc.ambito, celdaCalc.posY, celdaCalc.posX, "No se puede iterar el tipo:" + simbolo.tipoPregunta);
//        }

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
