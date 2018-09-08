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
public class func_multimedia extends etiqueta {

    /**
     *
     * @param tablaSimbolos
     * @param simbolo
     */
    public func_multimedia(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }

    /**
     *
     * @return
     */
    @Override
    public String getCadena() {
        String retorno = "";

        cell celdaMultime = simbolo.lstAtributos.get("multimedia");
        if (celdaMultime == null) {
            return retorno;
        } 
        simbolo.lstFunciones.put("mostrar", "multimedia");
        
        retorno += "\n\t\tpublico Mostrar(){";

        retorno += restringir(celdaMultime);

        retorno += "\n\t\t}";

        return retorno;
    }

    public String restringir(cell celda) {
        String retorno = "";
 

        String multimedia = celda.val;
        String multiLowCase = multimedia.toLowerCase();

        if (multiLowCase.contains("media_imagen")) {
            retorno += "\n\t\t\tImagen(";
        } else if (multiLowCase.contains("media_audio")) {
            retorno += "\n\t\t\tAudio(";
        } else if (multiLowCase.contains("media_video")) {
            retorno += "\n\t\t\tVideo(";
        } else {
            tablaSimbolos.tablaErrores.insertErrorSyntax(celda.ambito, celda.posY, celda.posX, "Formado multimedia no reconocido");
            return retorno;
        }

        retorno += getUrl(multimedia) + " ,"+getExpresion(celda)+");";

        return retorno;
    }

    public String getUrl(String entrada) {
        String retorno = "";
        String pattern = "(?:“|\\\"|”)(.+?)(?:“|\"|”)";

        Pattern p2 = Pattern.compile(pattern);
        Matcher m2 = p2.matcher(entrada);

        while (m2.find()) {
            retorno = m2.group(1);
        }
        retorno = "\"" + retorno + "\"";
        return retorno;
    }

    public String getExpresion(cell celda) {
        String retorno = "";


        String multimedia = celda.val.toLowerCase();

        String pattern = "= (.+?)(?:media_video|media_audio|media_imagen|$)";
        String tempRespuesta="";
        
        Pattern p2 = Pattern.compile(pattern);
        Matcher m2 = p2.matcher(multimedia);

        while (m2.find()) {
            tempRespuesta = m2.group(1);
        }
        
        //haciendo una nueva celda
        
        cell celdaExp=celda;
        celda.val=tempRespuesta;
        
        expresion exp = new expresion(tablaSimbolos, celdaExp);
        retorno = exp.getCadenaMulti();
        simbolo.concatTempParam(exp.tempLstParametros);
        
        return retorno;
    }
    

}
