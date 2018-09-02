/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package readExcel;

/**
 *
 * @author joseph
 */
public class cell {
    
    public int posX;
    public int posY;
    public String val;
    public String ambito;
    
    public cell(String ambito){
        this.posX=0;
        this.posY=0;
        val="";
        this.ambito=ambito;
    }
    
}
