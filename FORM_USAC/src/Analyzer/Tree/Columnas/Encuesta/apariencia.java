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
public class apariencia extends etiqueta{
    
    public apariencia(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }
     
    /**
     *
     * @return
     */
    @Override
    public String getCadena() {
        String retorno = "";

        cell celdaApariencia = simbolo.lstAtributos.get("apariencia");
        if (celdaApariencia == null) {
            return retorno; 
        }
        
        String tempApar=celdaApariencia.val.toLowerCase().replace(" ", "");
        
        parametro param = new parametro(tablaSimbolos, simbolo);
        
        
         
        if(tempApar.contains("cadena")){
            
            simbolo.tipoPreguntaApariencia="cadEna"; 
        
        }else if(tempApar.contains("entero")){
            
            simbolo.tipoPreguntaApariencia="entero"; 
        
        }else if(tempApar.contains("decimal")){
            
            simbolo.tipoPreguntaApariencia="decimal"; 
            
        }else if(tempApar.contains("booleano")){
            
            simbolo.tipoPreguntaApariencia="booleano"; 
        
        }else if(tempApar.contains("fechahora")){
            
            simbolo.tipoPreguntaApariencia="fechahora"; 
        
        }else if(tempApar.contains("fecha")){
            
            simbolo.tipoPreguntaApariencia="fecha"; 
        
        }else if(tempApar.contains("hora")){
            
            simbolo.tipoPreguntaApariencia="hora"; 
            
        }else if(tempApar.contains("nota")){
            simbolo.tipoPreguntaApariencia="nota";  
            
        }else{
            tablaSimbolos.tablaErrores.println("Se reconocio como celda:"+tempApar);
            retorno+=".apariencia(\""+tempApar+"\")";
            return retorno;
        }
         
        String parametro = param.getCadena2(simbolo.tipoPreguntaApariencia);
        retorno+=".apariencia()"+parametro;
         
        
        return retorno;
    }

    
}
