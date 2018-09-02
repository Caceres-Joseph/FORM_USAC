/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Columnas;

import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos; 
import java.util.HashMap;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class columna {
    tablaSimbolos tablaSimbolos=new tablaSimbolos();
    elementoSimbolo simbolo;
    public columna(tablaSimbolos tablaSimbolos1, elementoSimbolo simb){
        this.tablaSimbolos=tablaSimbolos1;
        this.simbolo=simb;
        
    }
     
    public String getTipo(){
        String retorno="";
        String tipo;
        cell celda=simbolo.lstAtributos.get("tipo");
        if(celda==null){
            this.tablaSimbolos.tablaErrores.println("No se econtro el tipo");
            return retorno;
        }
        tipo = celda.val;
         
        if(tipo.toLowerCase().contains("texto")){
            simbolo.tipoPregunta="cadena"; 
            
        }else if(tipo.toLowerCase().contains("entero")){
            simbolo.tipoPregunta="entero"; 
            
        }else if(tipo.toLowerCase().contains("decimal")){
            simbolo.tipoPregunta="decimal"; 
            
        }else if(tipo.toLowerCase().contains("rango")){
            simbolo.tipoPregunta="entero"; 
            
        }else if(tipo.toLowerCase().contains("condicion")){
            simbolo.tipoPregunta="booleano"; 
            
        }else if(tipo.toLowerCase().contains("fecha")){
            simbolo.tipoPregunta="fecha"; 
            
        }else if(tipo.toLowerCase().contains("hora")){
            simbolo.tipoPregunta="hora"; 
            
        }else if(tipo.toLowerCase().contains("fecha")&&tipo.toLowerCase().contains("hora")){
            simbolo.tipoPregunta="fechahora"; 
            
        }else if(tipo.toLowerCase().contains("selecciona")&&tipo.toLowerCase().contains("uno")){
            simbolo.tipoPregunta="cadena"; 
            
        }else if(tipo.toLowerCase().contains("selecciona")&&tipo.toLowerCase().contains("multiple")){
            simbolo.tipoPregunta="cadena"; 
        
        }else if(tipo.toLowerCase().contains("nota")){
            simbolo.tipoPregunta="void";
            //No tiene respuesta
            //retorno+="\n\tentero Respuesta;";
        }else if(tipo.toLowerCase().contains("fichero")){
            simbolo.tipoPregunta="void";
            //No tiene respuesta
        }else if(tipo.toLowerCase().contains("calcular")){
            simbolo.tipoPregunta="entero"; 
        }else{
            
            simbolo.tipoPregunta="void";
            tablaSimbolos.tablaErrores.insertErrorLexical(celda.ambito, celda.posY, celda.posX, "Tipo de dato no reconocido:"+celda.val);
        }
        
        
        if(!simbolo.tipoPregunta.equals("void")){//Si no es void
            retorno+="\n\t\t"+simbolo.tipoPregunta+" Respuesta"+getPredeterminado();
        }
//        tablaSimbolos.tablaErrores.println(retorno);
        
        return retorno;
    }
    
    public String getPredeterminado(){
        String retorno=";"; 
        cell celda=simbolo.lstAtributos.get("predeterminado");
        if(celda==null){ 
            return retorno;
        }
        
        expresion exp=new expresion(tablaSimbolos, celda);
        retorno=exp.getCadena();
     
        return retorno;
    }
    public String getEtiqueta(){
        String retorno="";
        
        return retorno;
    }
}
