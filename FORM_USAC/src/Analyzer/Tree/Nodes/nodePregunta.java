/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;

import Analyzer.Tree.Columnas.Encuesta.*;
import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import Analyzer.Tree.nodeModel;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class nodePregunta extends nodeModel {

    elementoSimbolo simbolo;

    public nodePregunta(tablaSimbolos tabla) {
        this.tablaSimbolos = tabla;
        this.nombreNodo = "nodePregunta";
    }

    @Override
    public void execute() {
//        this.mensajeDeEjecucion();
        generandoContenido();
    }

    public void generandoContenido() {
        cell idPregunta = atrib.get("idpregunta");

        simbolo = new elementoSimbolo(idPregunta, atrib, idPregunta.val);
        tablaSimbolos.insertSimbol(idPregunta.val.replace(" ", ""), simbolo);

        columna colum = new columna(tablaSimbolos, simbolo);
        String respuesta = colum.getTipo();

        etiqueta etiquet = new etiqueta(tablaSimbolos, simbolo);
        String etiqueta = etiquet.getCadena();

        sugerir suge = new sugerir(tablaSimbolos, simbolo);
        String sugerir = suge.getCadena();

        requerido reque = new requerido(tablaSimbolos, simbolo);
        String requerido = reque.getCadena();

        requeridoMsn requeMsn = new requeridoMsn(tablaSimbolos, simbolo);
        String requeridoMsn = requeMsn.getCadena();

        func_calculo func_calc = new func_calculo(tablaSimbolos, simbolo);
        String funcion_calculo = func_calc.getCadena();

        String funcion_respuesta = "";

        if (funcion_calculo.length() < 2) { //POr si viene calculo hay que quitar respuesta
            funcion_calculo = "";
            func_respuesta func_resp = new func_respuesta(tablaSimbolos, simbolo);
            funcion_respuesta = func_resp.getCadena();
        }

        func_multimedia func_multi = new func_multimedia(tablaSimbolos, simbolo);
        String funcion_multimedia = func_multi.getCadena();

        codigoPre codPre = new codigoPre(tablaSimbolos, simbolo);
        simbolo.cadenaPre = codPre.getCadena();

        codigoPost codPost = new codigoPost(tablaSimbolos, simbolo);
        simbolo.cadenaPost = codPost.getCadena();

        insertarParametros(simbolo);

        this.cadenaContenido += "\n\tPregunta " + idPregunta.val + "(" + getParametros(simbolo) + "){";

        cadenaContenido += respuesta;
        cadenaContenido += etiqueta;
        cadenaContenido += sugerir;
        cadenaContenido += requerido;
        cadenaContenido += requeridoMsn;
        cadenaContenido += funcion_calculo;
        cadenaContenido += funcion_respuesta;
        cadenaContenido += funcion_multimedia;

        cadenaContenido += "\n\t}";

        simbolo.cadenaContenido=cadenaContenido;
//        System.out.println(cadenaContenido);

        codEjec();

        //Tiene incluido el aplicable, la cadena de salida, post y pre
        repeticion repe = new repeticion(tablaSimbolos, simbolo);
        String salida = repe.getCadena();
        
        simbolo.cadenaFinal=salida;
//        System.out.println(salida);

    }

    public String getParametros(elementoSimbolo simbolo) {
        String retorno = "";

        int contador = 0;
        for (String key : simbolo.lstParametros.keySet()) {
            String val = simbolo.lstParametros.get(key);

            if (contador == 0) {
                retorno += val + " " + key;
            } else {
                retorno += ", " + val + " " + key;
            }

            contador++;
        }

        return retorno;
    }

    public void insertarParametros(elementoSimbolo simbolo) {
        //Buscando en la tabla de simbolos si existe prro
        for (String key : simbolo.tempLstParametros.keySet()) {
            String tempKey = key.replace(" ", "").toLowerCase();
            cell tempCell = simbolo.tempLstParametros.get(key);
            elementoSimbolo temp = tablaSimbolos.getSimbolo(tempKey);

            if (temp != null) {
                if (temp.tipoPregunta.toLowerCase().contains("void")) {
                    tablaSimbolos.tablaErrores.insertErrorSemantic(tempCell.ambito, tempCell.posY, tempCell.posX, "La pregunta :" + tempKey + " no retorna algun tipo.");
                } else {
                    simbolo.lstParametros.put(tempKey, temp.tipoPregunta);
                }

            } else {
                //System.out.println("Parametro no encontrado");
                tablaSimbolos.tablaErrores.insertErrorSemantic(tempCell.ambito, tempCell.posY, tempCell.posX, "No se ha declarado la pregunta:" + tempKey);
                //no lo encontro en la tabla de simbolos prro
            }
        }
    }

    public void codEjec() {
        String retorno = "";
        retorno = simbolo.idPregunta + "(";
        retorno += codEjecGetParam() + ")";
        String tipo = simbolo.tipoPregunta.substring(0, 1).toUpperCase() + simbolo.tipoPregunta.substring(1);
        if (simbolo.lstFunciones.get("respuesta") != null) {

            retorno += ".Respuesta(resp.es" + tipo + ")";

            //hay que revisar si tiene apareciencia
            String apariencia = codEjecGetApariencia();

            if (apariencia.length() < 4) {//No viene apariencia prro
                retorno += codEjecGetParamResp(tipo);
            } else {
                retorno += apariencia; 
            }

        } else if (simbolo.lstFunciones.get("calcular") != null) {
            //retorno += codEjecGetParamResp(tipo);
            retorno += ".Calcular()";
        } else if (simbolo.lstFunciones.get("mostrar") != null) {
            retorno += codEjecGetParamResp(tipo);
            retorno += ".Mostrar()"; 
            
        } else if (simbolo.tipoPregunta.contains("nota")){//ESTE IF PUEDE QUE EESTE DE MAS PRRO
            retorno+=".Nota()";
        }

        retorno += ";";

        simbolo.codigoEjecucion = retorno;
    }

    public String codEjecGetParam() {
        String retorno = "";

        int contador = 0;
        for (String key : simbolo.lstParametros.keySet()) {
//            String val = simbolo.lstParametros.get(key);

            if (contador == 0) {
                retorno += key + "().Respuesta";
            } else {
                retorno += ", " + key + "().Respuesta";
            }

            contador++;
        }
        return retorno;
    }

    public String codEjecGetParamResp(String tipo) {

        parametro param = new parametro(tablaSimbolos, simbolo);
        String parametro = param.getCadena(tipo);

        return parametro;
    }

    public String codEjecGetApariencia() {

        apariencia apar = new apariencia(tablaSimbolos, simbolo);
        String apariencia = apar.getCadena();

        return apariencia;
    }

}
