/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Columnas.Encuesta;

import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class etiqueta {

    tablaSimbolos tablaSimbolos ;
    elementoSimbolo simbolo;

    public etiqueta(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        this.tablaSimbolos = tablaSimbolos;
        this.simbolo = simbolo;
    } 

    public String getCadena() {
        String retorno="\n\t\tcadena Etiqueta = ";
        String etiqueta;
        cell celda = simbolo.lstAtributos.get("etiqueta");
        if (celda == null) {
            retorno+="\"\";";
            return retorno;
        }
         
        etiqueta = celda.val;
        
        
        retorno+="\""+analizar(etiqueta, celda)+"\";";
        
        return retorno;
    }
    public String analizar(String INPUT2, cell celda){
        
        String retorno="";
        
        String REGEX2 = "#\\[(.+?)]";
        
        
        Pattern p2 = Pattern.compile(REGEX2);
        Matcher m2 = p2.matcher(INPUT2);   // get a matcher object
 

        while (m2.find()) {  
            String encontrado=m2.group(1).replace(" ", "").toLowerCase();
            simbolo.tempLstParametros.put(encontrado,celda);
//            System.out.println("Cadena:"+encontrado); 
//            System.out.println("start(): " + m2.start());
//            System.out.println("end(): " + m2.end()); 
        }
        
        retorno = INPUT2.replaceAll(REGEX2, "\"+ $1 +\""); 
        return retorno;
    }
    
    
    
}
