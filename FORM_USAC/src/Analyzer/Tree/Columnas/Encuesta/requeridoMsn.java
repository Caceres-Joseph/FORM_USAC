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
public class requeridoMsn extends etiqueta {
    
    public requeridoMsn(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }

    /**
     *
     * @return
     */
    @Override
    public String getCadena() {
        String retorno = "";
        String etiqueta;
        cell celda = simbolo.lstAtributos.get("requeridomsn");
        if (celda == null) {
            return retorno;
        } 
        etiqueta = celda.val; 
        retorno += "\n\t\tcadena RequeridoMsn = \"" + analizar(etiqueta, celda) + "\";"; 
        return retorno;
    }
    
    
    
}
