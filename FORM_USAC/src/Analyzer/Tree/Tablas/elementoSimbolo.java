/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Tablas;

import Analyzer.Tree.atributos;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class elementoSimbolo {
//    String idPregunta="";  

    public HashMap<String, String> lstParametros = new LinkedHashMap<>();
    public HashMap<String, cell> tempLstParametros;
    public String tipoPregunta = "";
    public atributos lstAtributos = new atributos();
    public cell celda;
    public String codigoEjecucion = "";
    public String idPregunta;
    public HashMap<String, String> lstFunciones;

    public String cadenaPost = "";
    public String cadenaPre = "";

    public String tipoPreguntaApariencia = "";
    
    public String cadenaFinal="";
    public String cadenaContenido="";

    
    public String nombreListaOpciones="";
    
    public elementoSimbolo(cell celda, atributos lstAtributos, String idPregunta) {
        this.idPregunta = idPregunta.replace(" ", "");
        this.celda = celda;
        this.lstAtributos = lstAtributos;
        this.tempLstParametros = new LinkedHashMap<>();
        lstFunciones = new LinkedHashMap<>();

    }

    public void concatTempParam(HashMap<String, cell> lstTem) {
        HashMap<String, cell> temp = new LinkedHashMap<>();

        temp.putAll(lstTem);
        temp.putAll(tempLstParametros);
        tempLstParametros = temp;
    }

}
