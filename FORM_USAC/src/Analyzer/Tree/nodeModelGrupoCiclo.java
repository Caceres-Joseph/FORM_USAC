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
public class nodeModelGrupoCiclo extends nodeModel{
    
    /*
    |--------------------------------------------------------------------------
    | acciones de los botones
    |-------------------------------------------------------------------------- 
     */
    public void firstAtrib(atributos atr, String id) {
        this.atrib = atr;
        this.tId_Grupo_Ciclo = id;
    }

    public void secondAtrib(atributos atr, String id) {
        if (this.tId_Grupo_Ciclo.equals(id)) {
             cell atr1=this.atrib.get("idpregunta");
             cell atr2=atr.get("idpregunta");
            
            if(atr1.val.equals(atr2.val)){
//                System.out.println("secondAtrib[");
//                System.out.println(this.tId_Grupo_Ciclo);
//                this.atrib.imprimir();
//                System.out.println("------");
//                System.out.println(id);
//                atr.imprimir();
//                System.out.println("]");      
            }else{
                tablaSimbolos.tablaErrores.insertErrorSyntax(atr1.ambito, atr2.posY, atr2.posX, "Se esperaba idpregunta: "+atr1.val+" pero se obtuvo: "+atr2.val);
            }

        } else {
            if(this.tablaSimbolos!=null){
                for (String key : atr.lstCell.keySet()) {
                    cell temp = atr.lstCell.get(key);
                    tablaSimbolos.tablaErrores.insertErrorSyntax(temp.ambito,temp.posY, temp.posX,
                            "Se inició con tipo "+ tId_Grupo_Ciclo+" y se terminó la celda "+temp.val+" con tipo "+id);
                } 
            }else{
                System.out.println("Tabla de simbolos vacía");
            }
        } 
    }
}
