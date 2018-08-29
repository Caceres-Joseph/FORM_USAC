/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package GUI.Elements;

import Analyzer.Javacc.parser;
import Analyzer.Tree.tree;
import form_usac.FORM_USAC;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.nio.charset.StandardCharsets;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author joseph
 */
public class xForm extends newTab {

    public tree arbol = new tree();

    public xForm() {

    }

    @Override
    public void accGuardar() {
        System.out.println("accGuardar");
    }

    @Override
    public void accLeer() {
        this.showTableErrors();
        System.out.println("accLeer");
    }

    @Override
    public void accGenerar() {
        
        InputStream stream = new ByteArrayInputStream(this.entrada.getText().getBytes(StandardCharsets.UTF_8));
        parser par = new parser();
        par.inicializar(stream); 
        
        this.tablaErrores.concat(par.tablaSimbolos.tablaErrores);
    } 
}
