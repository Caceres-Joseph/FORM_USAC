/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package GUI.Elements;

import Analyzer.Tree.Tablas.elementoError;
import Analyzer.Tree.Tablas.tablaErrores;
import java.util.ArrayList;
import java.util.List;
import javafx.beans.property.SimpleStringProperty;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.AnchorPane;

/**
 *
 * @author joseph
 */
public class cError {

   public tablaErrores tablaErrores;
    TableView<elementoTabla> table = new TableView<>();

    AnchorPane padre=new AnchorPane();

    
    public cError(tablaErrores tabl){
        this.tablaErrores =tabl;
        padre=new AnchorPane();
        
    }
    public void refrescarTabla() {
//        ObservableList<elementoTabla> retorno = FXCollections.observableArrayList();
//        retorno.add(new elementoTabla("44343","ad","adf","adsf","afd"));

//        table.setItems(retorno);
//        inicializarTabla();
        this.padre.getChildren().clear();
//        table.setItems(cargar());
//
//        padre.getChildren().add(table);

//        table.setItems(cargar());
//        table.refresh();
//        retornarTabla(padre);
    }

    public AnchorPane retornarTabla() {//retorna la tabla
         

        inicializarTabla();
        table.setItems(cargar());

        padre.getChildren().add(table); 
        return padre;
    }

    public void inicializarTabla() {
        table = new TableView<>();
        AnchorPane.setBottomAnchor(table, 10.0);
        AnchorPane.setLeftAnchor(table, 10.0);
        AnchorPane.setRightAnchor(table, 10.0);
        AnchorPane.setTopAnchor(table, 10.0);

//        ObservableList<elementoTabla> data
//                = FXCollections.observableArrayList(new elementoTabla("hol", "hje", "hlsd", "k", "hk"));
//        ObservableList<elementoTabla> data = null;
 

        TableColumn tcLinea = new TableColumn("Linea");
        tcLinea.setMinWidth(100);
        tcLinea.setCellValueFactory(
                new PropertyValueFactory<>("linea"));

        TableColumn tcColumna = new TableColumn("Columna");
        tcColumna.setMinWidth(100);
        tcColumna.setCellValueFactory(
                new PropertyValueFactory<>("columna"));

        TableColumn tcTipo = new TableColumn("Tipo");
        tcTipo.setMinWidth(100);
        tcTipo.setCellValueFactory(
                new PropertyValueFactory<>("tipo"));
//        
        TableColumn tcDescripcion = new TableColumn("Descripcion");
        tcDescripcion.setMinWidth(300);
        tcDescripcion.setCellValueFactory(
                new PropertyValueFactory<>("descripcion"));

        table.getColumns().addAll( tcLinea, tcColumna, tcTipo, tcDescripcion);
    }

    public ObservableList<elementoTabla> cargar() {
        ObservableList<elementoTabla> retorno = FXCollections.observableArrayList();
 
        for (elementoError lstErrore : this.tablaErrores.tablaError) {
            retorno.add(new elementoTabla( lstErrore.linea, lstErrore.columna, lstErrore.tipo, lstErrore.descripcion));
        }
        return retorno;
    }

 

    public void imprimir() {
        System.out.println("-----cError--------");
        for (elementoError lstErrore : this.tablaErrores.tablaError) {
            System.out.println("}");
            System.out.print("Linea{");
            System.out.print(lstErrore.linea);
            System.out.println("}");
            System.out.print("Columna{");
            System.out.print(lstErrore.columna);
            System.out.println("}");
            System.out.print("Tipo{");
            System.out.print(lstErrore.tipo);
            System.out.println("}");
            System.out.print("Descripcion{");
            System.out.print(lstErrore.descripcion);
            System.out.println("}");
        }
    }

    public class elementoTabla {

        public SimpleStringProperty archivo = new SimpleStringProperty();
        public SimpleStringProperty linea = new SimpleStringProperty();
        public SimpleStringProperty columna = new SimpleStringProperty();
        public SimpleStringProperty tipo = new SimpleStringProperty();
        public SimpleStringProperty descripcion = new SimpleStringProperty();

        public elementoTabla() {

        }

        public elementoTabla( String linea, String columna, String tipo, String descripcion) {
            this.linea = new SimpleStringProperty(linea);
            this.columna = new SimpleStringProperty(columna);
            this.tipo = new SimpleStringProperty(tipo);
            this.descripcion = new SimpleStringProperty(descripcion);
        }

        public String getArchivo() {
            return archivo.get();
        }

        public String getLinea() {
            return linea.get();
        }

        public String getColumna() {
            return columna.get();
        }

        public String getTipo() {
            return tipo.get();
        }

        public String getDescripcion() {
            return descripcion.get();
        }

    }

//    class error {
//
//        String archivo = "";
//        String linea = "";
//        String columna = "";
//        String tipo = "";
//        String descripcion = "";
//
//        public error() {
//
//        }
//
//        public void insertar(String archivo, String linea, String columna, String tipo, String descripcion) {
//            this.archivo = archivo;
//            this.linea = linea;
//            this.columna = columna;
//            this.tipo = tipo;
//            this.descripcion = descripcion;
//
//        }
//
//    }

    
}
