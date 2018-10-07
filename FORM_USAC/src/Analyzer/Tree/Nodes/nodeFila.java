/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;
 
import Analyzer.Tree.Tablas.tablaSimbolos;
import Analyzer.Tree.nodeModel; 
import Analyzer.Tree.tree;
import readExcel.cell;
/**
 *
 * @author joseph
 */
public class nodeFila extends nodeModel{
    
    
    
    public nodeFila(tablaSimbolos tabla) {
        this.tablaSimbolos=tabla;
        this.nombreNodo="nodeFila";
    }
    @Override
    public void execute() {
       //this.mensajeDeEjecucion();
       generandoCodigo();
    }
    
    public void generandoCodigo(){
        
        //esto es para la encuesta
         getIdForm();
         getEstilo();
         getCodigoGlobal();
         getCodigoPrincipal();
         getImports();
         
         getLista();
    }
    
    public void getLista(){
        String cad="\"";
        cell val = atrib.get("nombre_lista");
        if(val!=null){
            cad=val.val;
            
            cell nombre = atrib.get("nombre");
            if(nombre!=null){
                cad="\""+nombre.val;
            }
            
            
            cell etiqueta = atrib.get("etiqueta");
            if(etiqueta!=null){
                cad+="\",\""+etiqueta.val;
            }
            cad+="\"";
            cad="\n\t"+nombre.val.replace(" ", "")+".Insertar("+cad+");";
            if(tree.listas.containsKey(val.val.replace(" ", "").toLowerCase())){
                cad = tree.listas.get(val.val.replace(" ", "").toLowerCase())+ cad;
                tree.listas.replace(val.val.replace(" ", "").toLowerCase(),cad);
                //System.out.println("== Concatenando "+ val.val);
            }else{
                //System.out.println("== Insertando "+ val.val);
                tree.listas.put(nombre.val.replace(" ", "").toLowerCase(), cad);
            }
            
        }  
    }
    
    public void getIdForm(){
        cell val = atrib.get("idform");
        if(val!=null){
            tree.idForm=val.val;
        }
    }
    
    
    public void getEstilo(){
        cell val = atrib.get("estilo");
        if(val!=null){
            tree.estilo=val.val;
        }
    }
    
    public void getCodigoPrincipal(){
        
        cell val = atrib.get("codigo_principal");
        if(val!=null){
            tree.principal=val.val;
        }
    }
    
    
    public void getCodigoGlobal(){
        
        cell val = atrib.get("codigo_global");
        if(val!=null){
            tree.codigoGlobal=val.val;
        }
    }
    
    public void getImports(){
        cell val = atrib.get("importar");
        if(val!=null){
            
            
            String val2 = val.val.replace("importar", "");
            val2=val2.replace(" ", "");
            tree.importar=tree.importar+"\nimportar("+val2+");";
        }
    }
 
}
