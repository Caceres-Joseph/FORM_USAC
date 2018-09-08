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
public class func_respuesta extends etiqueta {
    
    public func_respuesta(tablaSimbolos tablaSimbolos, elementoSimbolo simbolo) {
        super(tablaSimbolos, simbolo);
    }

    /**
     *
     * @return
     */
    @Override
    public String getCadena() {
        String retorno="";
        if(simbolo.tipoPregunta.toLowerCase().contains("void")||simbolo.tipoPregunta.toLowerCase().contains("nota")){
            retorno="\n\t\t$$No hay respuesta por ser nota/void";
            return retorno ;
        }
        
        cell celdaLectura = simbolo.lstAtributos.get("lectura");
        if (celdaLectura == null) {
            retorno += "\n\t\tpublico";
        }else{
            String requerido = celdaLectura.val.toLowerCase(); 
            
            if(requerido.contains("verdad")||requerido.contains("tru")||requerido.replace(" ", "").equals("1")||requerido.replace(" ", "").equals("1.0")){
                retorno+="\n\t\tprivado";
            }else if(requerido.contains("fals")||requerido.replace(" ", "").equals("0")||requerido.replace(" ", "").equals("0.0")){
                retorno+="\n\t\tpublico";
            }else{
                tablaSimbolos.tablaErrores.insertErrorLexical(celdaLectura.ambito,celdaLectura.posY, celdaLectura.posX, "No se reconoce el tipo booleano:"+celdaLectura.val);
                return retorno;
            } 
        }  
        
        retorno += " respuesta("+simbolo.tipoPregunta +" param_1){";

        simbolo.lstFunciones.put("respuesta", "param_1");
        
        cell celda = simbolo.lstAtributos.get("restringir");
        if (celda == null) {
            retorno+="\n\t\t\tRespuesta=param_1;";
            retorno+="\n\t\t}";
            return retorno;
        }  
        
        retorno+=restringir(celda);
        
        cell celda2=simbolo.lstAtributos.get("restringirMsn");
        if(celda2==null){
            retorno+="\n\t\t}";
            return retorno;
        } 
        
        retorno+=restringirMsn(celda2, celda2.val);
        
        retorno+="\n\t\t}";
        return retorno;
    }   
    
    public String restringirMsn(cell celda, String restringirMsn){
        String retorno="";
        retorno +="\n\t\t\tSino{";
        retorno +="\n\t\t\t\tMensajes(\"" + analizar(restringirMsn, celda) + "\");";  
        retorno +="\n\t\t\t}"; 
        return retorno;
    }
    
    
    public String restringir(cell celda){
        String retorno="";
        
        
        expresion exp = new expresion(tablaSimbolos, celda);
        String temp1 = exp.getCadenaReq();
        simbolo.concatTempParam(exp.tempLstParametros);
        retorno+="\n\t\t\tSi("+temp1+"){";
        retorno+="\n\t\t\t\tRespuesta=param_1;";
        retorno+="\n\t\t\t}";


        return retorno;
    }
}
