/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Columnas;

import Analyzer.Javacc_Exp.parser_exp;
import Analyzer.Tree.Tablas.tablaSimbolos;
import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.nio.charset.StandardCharsets;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class expresion {

    tablaSimbolos tablaSimbolos;
    cell celda;

    public expresion(tablaSimbolos tabla, cell celda) {
        this.tablaSimbolos = tabla;
        this.celda = celda;

    }

    public String getCadena() {
        String retorno="klhlj ";
        String cadena = celda.val;
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_exp par = new parser_exp();
        par.inicializar(tablaSimbolos, stream, celda,retorno);
        
        System.out.println("$"+retorno);
        return retorno;
    }
}
