/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;

import Analyzer.Tree.Columnas.*;
import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import Analyzer.Tree.nodeModel; 
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class nodePregunta extends nodeModel {

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

        elementoSimbolo simbolo = new elementoSimbolo(idPregunta, atrib);
        tablaSimbolos.insertSimbol(idPregunta.val, simbolo);

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
 
        func_respuesta func_resp = new func_respuesta(tablaSimbolos, simbolo);
        String funcion_respuesta = func_resp.getCadena();
        
        insertarParametros(simbolo);

        this.cadenaContenido += "\n\tPregunta " + idPregunta.val + "(" + getParametros(simbolo) + "){";

        cadenaContenido += respuesta;
        cadenaContenido += etiqueta;
        cadenaContenido += sugerir;
        cadenaContenido +=requerido;
        cadenaContenido +=requeridoMsn;
        cadenaContenido +=funcion_respuesta;
        
        cadenaContenido += "\n\t}";
        System.out.println(cadenaContenido);
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
            String tempKey=key.replace(" ", "").toLowerCase();
            cell tempCell=simbolo.tempLstParametros.get(key);
            elementoSimbolo temp = tablaSimbolos.getSimbolo(tempKey);
            
            if (temp != null) {
                if(temp.tipoPregunta.toLowerCase().contains("void")){
                    tablaSimbolos.tablaErrores.insertErrorSemantic(tempCell.ambito, tempCell.posY, tempCell.posX, "La pregunta :"+tempKey+" no retorna algun tipo.");
                }else{
                    simbolo.lstParametros.put(tempKey, temp.tipoPregunta);
                }
                 
            } else {
                //System.out.println("Parametro no encontrado");
                tablaSimbolos.tablaErrores.insertErrorSemantic(tempCell.ambito, tempCell.posY, tempCell.posX, "No se ha declarado la pregunta:" + tempKey);
                //no lo encontro en la tabla de simbolos prro
            }
        } 
    }

    public String getCuerpo() {
        String retorno = "";

        return retorno;
    }

}
