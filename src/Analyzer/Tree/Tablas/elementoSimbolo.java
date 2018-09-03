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
import java.util.List;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class elementoSimbolo {
//    String idPregunta="";  
    public HashMap<String, String>   lstParametros = new LinkedHashMap<>();
    public HashMap<String, cell> tempLstParametros;
    public String tipoPregunta="";
    public atributos lstAtributos=new atributos();
    public cell celda;
    public elementoSimbolo(cell celda,atributos lstAtributos){ 
        this.celda=celda;
        this.lstAtributos=lstAtributos;
        this.tempLstParametros=new LinkedHashMap<>();
        
    }
    
    
    public void concatTempParam(HashMap<String,cell> lstTem){
        HashMap<String,cell> temp=new LinkedHashMap<>(); 
        
        temp.putAll(lstTem);
        temp.putAll(tempLstParametros);
        tempLstParametros=temp;
    }
    
         

    
     
}
