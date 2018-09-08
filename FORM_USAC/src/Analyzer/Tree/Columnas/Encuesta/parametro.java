/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Columnas.Encuesta;

import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import java.util.HashMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class parametro extends etiqueta {

    /**
     *
     * @param tablaSimbolos
     * @param simbolo
     */
    public parametro(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }

    
    public String getCadena(String tipo) {
        String retorno = "";

        cell celdaParametro = simbolo.lstAtributos.get("parametro");
        if (celdaParametro == null) {
            retorno="."+tipo+"()";
            return retorno;
        }

        String parametro = celdaParametro.val.toLowerCase();

        parametro = parametro.replace("finalizar", "_finalizar");
        parametro = parametro.replace("opcion", "_opcion");
        celdaParametro.val = parametro;

//        System.out.println("Antes de analizar");
//        System.out.println(celdaParametro.val);

        expresion exp = new expresion(tablaSimbolos, celdaParametro);
        HashMap<String, String> tempHash = exp.getCadenaParametro();

        simbolo.concatTempParam(exp.tempLstParametros);

        if (simbolo.tipoPregunta.toLowerCase().contains("cadena")) {

            String cad_max = "Nada";
            String cad_min = "Nada";
            String cad_fila = "Nada";
            if (tempHash.get("cad_max") != null) {
                cad_max = tempHash.get("cad_max");
            }

            if (tempHash.get("cad_min") != null) {
                cad_min = tempHash.get("cad_min");
            }

            if (tempHash.get("cad_fila") != null) {
                cad_fila = tempHash.get("cad_fila");
            }

            retorno += ".Cadena(" + cad_fila + "," + cad_max + "," + cad_min + ")";

        } else if (simbolo.tipoPregunta.toLowerCase().contains("entero")) {
            String finalizar = "Nada";
            if (tempHash.get("finalizar") != null) {
                finalizar = tempHash.get("finalizar");
                retorno += ".Entero(" + finalizar + ")";
            } else {
                tablaSimbolos.tablaErrores.insertErrorSemantic(celdaParametro.ambito, celdaParametro.posY, celdaParametro.posX, "No esta permitido el parametro:" + celdaParametro.val + " en el tipo entero");
                System.out.println("err param rang");
            }

        } else if (simbolo.tipoPregunta.toLowerCase().contains("booleano")) {

            if (tempHash.get("opcion") != null) {
                retorno += ".Condicion('Si','No')";
            } else {
                tablaSimbolos.tablaErrores.insertErrorSemantic(celdaParametro.ambito, celdaParametro.posY, celdaParametro.posX, "No esta permitido el parametro:" + celdaParametro.val + " en el tipo booleano");

            }
        } else {
            tablaSimbolos.tablaErrores.println("tipo de dato no soporta paramaetros");

        }
        return retorno;
    }
    
    
    
    public String getCadena2(String tipo) {
        String retorno = "";

        cell celdaParametro = simbolo.lstAtributos.get("parametro");
        if (celdaParametro == null) {
            retorno="."+tipo+"()";
            return retorno;
        }

        String parametro = celdaParametro.val.toLowerCase();

        parametro = parametro.replace("finalizar", "_finalizar");
        parametro = parametro.replace("opcion", "_opcion");
        celdaParametro.val = parametro;

//        System.out.println("Antes de analizar");
//        System.out.println(celdaParametro.val);

        expresion exp = new expresion(tablaSimbolos, celdaParametro);
        HashMap<String, String> tempHash = exp.getCadenaParametro();

        simbolo.concatTempParam(exp.tempLstParametros);

        if (simbolo.tipoPreguntaApariencia.toLowerCase().contains("cadena")) {

            String cad_max = "Nada";
            String cad_min = "Nada";
            String cad_fila = "Nada";
            if (tempHash.get("cad_max") != null) {
                cad_max = tempHash.get("cad_max");
            }

            if (tempHash.get("cad_min") != null) {
                cad_min = tempHash.get("cad_min");
            }

            if (tempHash.get("cad_fila") != null) {
                cad_fila = tempHash.get("cad_fila");
            }

            retorno += ".Cadena(" + cad_fila + "," + cad_max + "," + cad_min + ")";

        } else if (simbolo.tipoPreguntaApariencia.toLowerCase().contains("entero")) {
            String finalizar = "Nada";
            if (tempHash.get("finalizar") != null) {
                finalizar = tempHash.get("finalizar");
                retorno += ".Entero(" + finalizar + ")";
            } else {
                tablaSimbolos.tablaErrores.insertErrorSemantic(celdaParametro.ambito, celdaParametro.posY, celdaParametro.posX, "No esta permitido el parametro:" + celdaParametro.val + " en el tipo entero");
                System.out.println("err param rang");
            }

        } else if (simbolo.tipoPreguntaApariencia.toLowerCase().contains("booleano")) {

            if (tempHash.get("opcion") != null) {
                retorno += ".Condicion('Si','No')";
            } else {
                tablaSimbolos.tablaErrores.insertErrorSemantic(celdaParametro.ambito, celdaParametro.posY, celdaParametro.posX, "No esta permitido el parametro:" + celdaParametro.val + " en el tipo booleano");

            }
        } else {
            tablaSimbolos.tablaErrores.insertErrorSemantic(celdaParametro.ambito, celdaParametro.posY, celdaParametro.posX, "El parametro no lo soporta la apariencia:"+simbolo.tipoPreguntaApariencia);
            tablaSimbolos.tablaErrores.println("tipo de dato no soporta paramaetros");
        }
        return retorno;
    }
    

    public String getCadMin(String entrada) {
        String retorno = "";
        String pattern = "(?:“|\\\"|”)(.+?)(?:“|\"|”)";

        Pattern p2 = Pattern.compile(pattern);
        Matcher m2 = p2.matcher(entrada.toLowerCase());

        while (m2.find()) {
            retorno = m2.group(1);
        }
        retorno = "\"" + retorno + "\"";
        return retorno;
    }

    public String getCadMax(String entrada) {
        String retorno = "";
        String pattern = "(?:“|\\\"|”)(.+?)(?:“|\"|”)";

        Pattern p2 = Pattern.compile(pattern);
        Matcher m2 = p2.matcher(entrada.toLowerCase());

        while (m2.find()) {
            retorno = m2.group(1);
        }
        retorno = "\"" + retorno + "\"";
        return retorno;
    }

    public String getCadFila(String entrada) {
        String retorno = "";
        String pattern = "(?:“|\\\"|”)(.+?)(?:“|\"|”)";

        Pattern p2 = Pattern.compile(pattern);
        Matcher m2 = p2.matcher(entrada.toLowerCase());

        while (m2.find()) {
            retorno = m2.group(1);
        }
        retorno = "\"" + retorno + "\"";
        return retorno;
    }

    public String getRangFinalizar(String entrada) {
        String retorno = "";
        String pattern = "(?:“|\\\"|”)(.+?)(?:“|\"|”)";

        Pattern p2 = Pattern.compile(pattern);
        Matcher m2 = p2.matcher(entrada.toLowerCase());

        while (m2.find()) {
            retorno = m2.group(1);
        }
        retorno = "\"" + retorno + "\"";
        return retorno;
    }

    public String getOpcionSi_NO(String entrada) {
        String retorno = "";
        String pattern = "(?:“|\\\"|”)(.+?)(?:“|\"|”)";

        Pattern p2 = Pattern.compile(pattern);
        Matcher m2 = p2.matcher(entrada.toLowerCase());

        while (m2.find()) {
            retorno = m2.group(1);
        }
        retorno = "\"" + retorno + "\"";
        return retorno;
    }

}
