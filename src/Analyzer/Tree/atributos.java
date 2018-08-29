/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree;
 
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class atributos {
    public Map<String, cell> lstCell ;
    
    public atributos(){
         lstCell = new LinkedHashMap<>();
    }
    
    
    public void insert(String key, String value, String posX, String posY){
        cell celda=new cell();
        celda.val=this.quitarDelimitadores(value);
        celda.posX=Integer.valueOf(posX);
        celda.posY=Integer.valueOf(posY);
        if(!this.validarSiYaExiste(key)){
            lstCell.put(key, celda);
        }
        
    }
  
    public boolean validarSiYaExiste(String key){
//        cell val=lstCell.get(key);
//        if(val==null){
//            return false;
//        }else{
//            //llenar la tabla de errores
//            System.out.println("Ya existe");
//            return true;
//        }
        
        return false;
    }
    
    public void imprimir(){
        String cadena="";
        Iterator it = lstCell.keySet().iterator();
        while (it.hasNext()) {
            String key = (String) it.next();
            cell temp=lstCell.get(key);
            cadena+="\t"+key ;
            cadena+=" x:"+temp.posX +" ";
            cadena+=" y:"+temp.posY +" ";
            cadena+="-> " + temp.val+"\n";
        } 
        System.out.println(cadena);
    }
    
    
    public String quitarDelimitadores(String cadena){
        cadena=cadena.replace("/>", "");//quitando espacios en blanco
        cadena=cadena.replace("</", "");//quitando espacios en blanco
        return cadena;
    }
    
}
