/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Tablas;

import java.util.HashMap;
import java.util.LinkedHashMap;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class tablaSimbolos {

    public tablaErrores tablaErrores = new tablaErrores();
    public HashMap<String, elementoSimbolo> lstSimbolos = new LinkedHashMap<>();

    public void insertSimbol(String idPregunta, elementoSimbolo simbolo) {
        lstSimbolos.put(idPregunta, simbolo);

    }

    public elementoSimbolo getSimbolo(String nombre) {
        elementoSimbolo elem = null;
        for (String key : lstSimbolos.keySet()) {

            if (key.toLowerCase().contains(nombre.toLowerCase())) {
                return lstSimbolos.get(key);
            } 
        } 
        return elem;
    }

}
