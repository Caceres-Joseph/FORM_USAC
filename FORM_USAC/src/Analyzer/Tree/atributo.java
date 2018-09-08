/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree;

import readExcel.cell;

/**
 *
 * @author joseph
 */
public class atributo {
    public cell cellVal;
    public String indice;
    
    public atributo(String key,String ambito, String value, String posX, String posY){
        cell celda=new cell(ambito);
        celda.val=this.quitarDelimitadores(value);
        celda.posX=Integer.valueOf(posX);
        celda.posY=Integer.valueOf(posY);
        this.cellVal=celda;
        this.indice=key;
               
    } 
        
    public String quitarDelimitadores(String cadena){
        cadena=cadena.replace("/>", "");//quitando espacios en blanco
        cadena=cadena.replace("</", "");//quitando espacios en blanco
        return cadena;
    }
}
