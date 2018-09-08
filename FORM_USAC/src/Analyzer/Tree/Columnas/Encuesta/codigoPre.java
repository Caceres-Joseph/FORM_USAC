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
public class codigoPre extends etiqueta{
    
    /**
     *
     * @param tablaSimbolos
     * @param simbolo 
     */
    public codigoPre(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }
    
    
    /**
     *
     * @return
     */
    @Override
    public String getCadena() {
        String retorno = "";

        cell celdaCalc = simbolo.lstAtributos.get("codigo_pre");
        if (celdaCalc == null) {
            return retorno; 
        } 
        retorno += analizar(celdaCalc.val, celdaCalc);
 
        return retorno;
    }

 
    /**
     *
     * @param INPUT2
     * @param celda
     * @return
     */
    @Override
    public String analizar(String INPUT2, cell celda) {

        String retorno="";

        String REGEX2 = "@";

        if (INPUT2.contains("@")) {
            if (simbolo.lstFunciones.get("respuesta") != null) {
                retorno = INPUT2.replaceAll(REGEX2, simbolo.idPregunta + "().Respuesta");
                return retorno;
            }else if(simbolo.lstFunciones.get("calcular")!=null){
                retorno = INPUT2.replaceAll(REGEX2, simbolo.idPregunta + "().Respuesta");
                return retorno;
            }else{
                tablaSimbolos.tablaErrores.insertErrorSemantic(celda.ambito, celda.posY, celda.posX, "No se puede remplazar @ ya que la pregunta :"+simbolo.idPregunta+" no tiene el atributo respuesta");
                return retorno;
            }
        }
          
        return INPUT2;
    }
    
    
}
