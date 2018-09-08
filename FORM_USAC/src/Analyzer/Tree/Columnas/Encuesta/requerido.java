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
public class requerido extends etiqueta {

    /**
     *
     * @param tablaSimbolos
     * @param simbolo
     */
    public requerido(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }

    /**
     *
     * @return
     */
    @Override
    public String getCadena() {
        String retorno = "";
        String requerido;
        cell celda = simbolo.lstAtributos.get("requerido");
        if (celda == null) {
            return retorno;
        }
        
        requerido = celda.val.toLowerCase();
        
        if(requerido.contains("verdad")||requerido.contains("tru")||requerido.replace(" ", "").equals("1")||requerido.replace(" ", "").equals("1.0")){
            requerido="verdadero";
        }else if(requerido.contains("fals")||requerido.replace(" ", "").equals("0")||requerido.replace(" ", "").equals("0.0")){
            requerido="falso"; 
        }else{
            tablaSimbolos.tablaErrores.insertErrorSemantic(celda.ambito,celda.posY,celda.posX, "Valor booleano no reconocido:"+celda.val);
            return retorno;
        }
        
        retorno += "\n\t\tbooelano Requerido = " + requerido + ";";
        return retorno;
    }
    
    

}
