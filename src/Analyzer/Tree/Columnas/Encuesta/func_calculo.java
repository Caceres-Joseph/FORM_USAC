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
public class func_calculo extends etiqueta {

    public func_calculo(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }

    /**
     *
     * @return
     */
    @Override
    public String getCadena() {
        String retorno = "";

        cell celdaCalc = simbolo.lstAtributos.get("calculo");
        if (celdaCalc == null) {
            return retorno;
            
        }
        simbolo.lstFunciones.put("calcular", "calculo");
        
        
        retorno += "\n\t\tpublico calcular(){";

        retorno += restringir(celdaCalc);
        
        retorno +="\n\t\t}";
        
        return retorno;
    }
    
    
    public String getTipoCalculo() {
        String retorno = "";

        cell celdaCalc = simbolo.lstAtributos.get("calculo");
        if (celdaCalc == null) {
            return "nota";
            
        }
        
        
        expresion exp = new expresion(tablaSimbolos, celdaCalc);
        retorno = exp.getCadenaTipoCalculo();
        
        return retorno;
    }
    


    public String restringir(cell celda) {
        String retorno = "";

        expresion exp = new expresion(tablaSimbolos, celda);
        String temp1 = exp.getCadenaReq();
        simbolo.concatTempParam(exp.tempLstParametros);
        
        retorno += "\n\t\t\tRespuesta="+ temp1 + ";";
         
        return retorno;
    }
}
