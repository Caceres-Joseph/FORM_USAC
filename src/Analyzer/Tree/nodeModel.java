/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree;

import java.util.ArrayList;

/**
 *
 * @author joseph
 */
public class nodeModel {

    public String nombreNodo = "";
    public atributos atrib = new atributos();
    public ArrayList<nodeModel> children = new ArrayList<>();

    public void execute(Object obj) {

    }

    ;
    
    public void insertChildren(nodeModel value) {
        children.add(value);
    }

    public void imprimir() {
        System.out.println("---" + nombreNodo + "---");
        System.out.println("atributos[");
        atrib.imprimir();
        System.out.println("]");
        imprimirRecursivo(children);
    }

    public void imprimirRecursivo(ArrayList<nodeModel> elem) {
        for (nodeModel model : elem) {
            System.out.println("---" + model.nombreNodo + "---");
            System.out.println("atributos[");
            model.atrib.imprimir();
            System.out.println("]");
            imprimirRecursivo(model.children);
        }
    }

    /*
    |--------------------------------------------------------------------------
    | acciones de los botones
    |-------------------------------------------------------------------------- 
     */
    public atributos getAtrib() {
        return atrib;
    }

    public void setAtrib(atributos atrib) {
        this.atrib = atrib;
    }

    public ArrayList<nodeModel> getChildren() {
        return children;
    }

    public void setChildren(ArrayList<nodeModel> children) {
        this.children = children;
    }

}
