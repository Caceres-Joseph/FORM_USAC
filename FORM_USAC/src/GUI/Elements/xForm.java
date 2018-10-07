/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package GUI.Elements;

import Analyzer.Javacc.parser;
import Analyzer.Tree.tree;
import GUI.Principal;
import form_usac.FORM_USAC;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.nio.charset.StandardCharsets;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.stage.FileChooser;
import readExcel.readExcel;

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
        guardarArchivo();
    }

    private void guardarArchivo() {
        try {
            //String nombre = "";
            //FileChooser file = new FileChooser();
            //file.showSaveDialog("");
            //File guarda = file.getSelectedFile();
            FileChooser fileChooser = new FileChooser();
            File guarda = fileChooser.showSaveDialog(Principal.sta);
            if (guarda != null) {
                /*guardamos el archivo y le damos el formato directamente,
    *           si queremos que se guarde en formato doc lo definimos como .doc*/
                FileWriter save = new FileWriter(guarda + ".xform");
                save.write(tree.salida);
                save.close();
                System.out.println("Guardado exitosamente");
            }
        } catch (IOException ex) {
            System.out.println("no se guardo");
        }
    }

    @Override
    public void accLeer() {

        InputStream stream = new ByteArrayInputStream(this.entrada.getText().getBytes(StandardCharsets.UTF_8));
        parser par = new parser();
        par.arbol.tablaSimbolos.tablaErrores = this.tablaErrores;
        par.inicializar(stream);

        //this.tablaErrores.concat(par.raiz.tablaSimbolos.tablaErrores);
        this.showTableErrors();
        this.arbol = par.arbol;
    }

    @Override
    public void accGenerar() {
        tree.resetVariables();
        arbol.raiz.execute();
        this.showTableErrors();
        this.setTextCode(tree.salida);
        
        tree.imprimirListas();
        //tree.imprimirVariables();
    }
}
