/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package GUI.Elements;

  
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.stream.Stream;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Orientation;
import javafx.scene.Node;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ScrollPane;
import javafx.scene.control.SplitPane;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.VBox;
//import javafx.stage.FileChooser;
import javafx.stage.Stage;

/**
 *
 * @author joseph
 */
public class crearTab {
    
    Tab tab = new Tab("tab1");
    AnchorPane contenedor = new AnchorPane();//padre
//    VBox panAreaWeb = new VBox(); //donde se va a cargar el contenido web

    AnchorPane padreWeb = new AnchorPane();
    
    TabPane tabConsola = new TabPane();//donde se carga la consola

//    AnchorPane paneConsolaError = new AnchorPane();
    Tab tabChtml = new Tab();
    Tab tabErro = new Tab();
    
    listaEntradas entradas = new listaEntradas();//Lista de entradas, con su nombre
 
    
    public void setTabCHMTL(String nombre, String texto) {
        Tab tabChtml = new Tab(nombre);
        TextArea entrada = new TextArea(texto);//tengo que abrir el archivo 
        TextArea lineas = new TextArea();
        String numeros = "";
        for (int i = 0; i < 999; i++) {
            numeros += String.valueOf(i) + "\n";
        }
        lineas.setText(numeros);
        entrada.scrollTopProperty().addListener((obs, oldVal, newVal) -> {
            lineas.setScrollTop((double) newVal);
        });
        
        lineas.setEditable(false);
        lineas.setDisable(true);
        
        AnchorPane ctn = new AnchorPane();

//        contenido.setStyle("-fx-background-color: green;");
        AnchorPane.setBottomAnchor(entrada, 10.0);
        AnchorPane.setLeftAnchor(entrada, 40.0);
        AnchorPane.setRightAnchor(entrada, 10.0);
        AnchorPane.setTopAnchor(entrada, 10.0);
        
        AnchorPane.setBottomAnchor(lineas, 10.0);
        AnchorPane.setLeftAnchor(lineas, 0.0);
        AnchorPane.setTopAnchor(lineas, 10.0);
        
        ctn.getChildren().setAll(lineas, entrada);
        
        tabChtml.setContent(ctn);

//        entradas.insertar(nombre, "CHTML", entrada);//Ingresando a la lista de entradas
//        tabChtml.getContent().set
//        tabChtml.getContent().setClip(contenido);
        tabConsola.getTabs().add(tabChtml);
        
    }
    
    public void setTabCCSS(String nombre, String texto) {
        Tab taCss = new Tab(nombre);
        TextArea entrada = new TextArea(texto);//tengo que abrir el archivo 
        TextArea lineas = new TextArea();
        String numeros = "";
        for (int i = 0; i < 999; i++) {
            numeros += String.valueOf(i) + "\n";
        }
        lineas.setText(numeros);
        entrada.scrollTopProperty().addListener((obs, oldVal, newVal) -> {
            lineas.setScrollTop((double) newVal);
        });
        
        lineas.setEditable(false);
        lineas.setDisable(true);
        
        AnchorPane ctn = new AnchorPane();

//        contenido.setStyle("-fx-background-color: green;");
        AnchorPane.setBottomAnchor(entrada, 10.0);
        AnchorPane.setLeftAnchor(entrada, 40.0);
        AnchorPane.setRightAnchor(entrada, 10.0);
        AnchorPane.setTopAnchor(entrada, 10.0);
        
        AnchorPane.setBottomAnchor(lineas, 10.0);
        AnchorPane.setLeftAnchor(lineas, 0.0);
        AnchorPane.setTopAnchor(lineas, 10.0);
        
        ctn.getChildren().setAll(lineas, entrada);
        
        taCss.setContent(ctn);

//        entradas.insertar(nombre, "CCSS", entrada);//Ingresando a la lista de entradas
//        tabChtml.getContent().set
//        tabChtml.getContent().setClip(contenido);
        tabConsola.getTabs().add(taCss);
    }
    
    public void setTabErroes() {
        tabErro = new Tab("Errores");
        AnchorPane paneConsolaError = new AnchorPane();
        //Ingresando a la lista de entradas
//        tabChtml.getContent().set
//        tabChtml.getContent().setClip(contenido);
        //consolaError.retornarTabla(paneConsolaError);
//        ctn.getChildren().add(consolaError.retornarTabla());

        tabErro.setContent(paneConsolaError);
        tabConsola.getTabs().add(tabErro);
    }
    
  
    
    public void archivoCCSS() {
        
    }
    
    public void crear() {
        
    }
    
    public Tab retornaTab() {
        
        crearSplit();

//        crearAreaWeb();
//        crearParteCosola();
        tab.setContent(contenedor);
//        setTabCJS("Consola Error");
        crearNavegacion();
        setTabErroes();
//        setTabCHMTL("hola.jpg");
        return tab;
    }
    
    public void crearNavegacion() {
        Button btnRec = new Button("Rec");
        
        Button btnAtras = new Button("<");
        Button btnSiguiente = new Button(">");
        Button btnIr = new Button("Ir");
        
        TextField barraNavegacion = new TextField("entradaChtml.cs");
        
        accionBtnIr(btnIr, barraNavegacion);
        
        AnchorPane.setLeftAnchor(btnRec, 2.0);
        AnchorPane.setLeftAnchor(btnAtras, 45.0);
        AnchorPane.setLeftAnchor(btnSiguiente, 75.0);
        AnchorPane.setLeftAnchor(barraNavegacion, 105.0);
        
        AnchorPane.setRightAnchor(barraNavegacion, 60.0);
        AnchorPane.setRightAnchor(btnIr, 10.0);
        
        AnchorPane.setTopAnchor(btnRec, 10.0);
        AnchorPane.setTopAnchor(btnAtras, 10.0);
        AnchorPane.setTopAnchor(btnSiguiente, 10.0);
        AnchorPane.setTopAnchor(btnIr, 10.0);
        AnchorPane.setTopAnchor(barraNavegacion, 10.0);
        
        contenedor.getChildren().add(btnRec);
        contenedor.getChildren().add(btnAtras);
        contenedor.getChildren().add(btnSiguiente);
        contenedor.getChildren().add(btnIr);
        contenedor.getChildren().add(barraNavegacion);
        
        btnRec.setOnAction((ActionEvent event) -> {
            
            try {
                String path = btnIr.getText();
//            setTabCHMTL(path, entradas.getHthmlText());
//                anlzChtml dat = new anlzChtml(); 

//                dat.analizar(entradas.getHthmlText(), consolaSalida, consolaError, padreWeb, entradas);
//                padreWeb.setStyle("-fx-background-color: black;");
//                recargarTabla();
                setTabCCSS("entradaChtml.cs", "Csss");

//                System.out.println(entradas.getHthmlText());
            } catch (Exception ex) {
                System.out.println(ex);
                System.out.println("[CHTML]ERRO :( ");
//                Logger.getLogger(crearTab.class.getName()).log(Level.SEVERE, null, ex);
            }

            //Ahora hay que pintar as etiquetas.
        });
//        btnAtras.set
    }
//
//    public void crearTab(AnchorPane panel) {
//
//    }

    public void accionBtnIr(Button btnIr, TextField link) {
        btnIr.setOnAction((ActionEvent event) -> {
            
            tabConsola.getTabs().clear();
            entradas = new listaEntradas();//inicializo la lista de entradas,jjejej
 
//            setTabErroes(); 
            tabConsola.getTabs().add(tabErro);
            
            entradas.pintarEnPanel(tabConsola);//pintando

   
//hayq ue cargar las tabs
//            try {
//
//                String path = link.getText();
//                File file = new File(path);
//                FileReader fr = new FileReader(file);
//
//                String texto = readLineByLineJava8(path);
////                System.out.println(readLineByLineJava8(path));
//                setTabCHMTL(path, texto);
//
////                anlzChtml dat = new anlzChtml();
////                dat.analizar(link.getText(), consolaSalida, consolaError);
////            analizarHTML();
////            System.out.println("Hello World!"+ link.getText());
//            } catch (FileNotFoundException ex) {
//                System.out.println(ex);
//            }
        });
    }
    
 
    
    public void insertarTab(String nombre, String texto) {
        Tab tabChtml = new Tab(nombre);
        TextArea entrada = new TextArea(texto);//tengo que abrir el archivo 
        TextArea lineas = new TextArea();
        String numeros = "";
        for (int i = 0; i < 999; i++) {
            numeros += String.valueOf(i) + "\n";
        }
        lineas.setText(numeros);
        entrada.scrollTopProperty().addListener((obs, oldVal, newVal) -> {
            lineas.setScrollTop((double) newVal);
        });
        
        lineas.setEditable(false);
        lineas.setDisable(true);
        
        AnchorPane ctn = new AnchorPane();

//        contenido.setStyle("-fx-background-color: green;");
        AnchorPane.setBottomAnchor(entrada, 10.0);
        AnchorPane.setLeftAnchor(entrada, 40.0);
        AnchorPane.setRightAnchor(entrada, 10.0);
        AnchorPane.setTopAnchor(entrada, 10.0);
        
        AnchorPane.setBottomAnchor(lineas, 10.0);
        AnchorPane.setLeftAnchor(lineas, 0.0);
        AnchorPane.setTopAnchor(lineas, 10.0);
        
        ctn.getChildren().setAll(lineas, entrada);
        
        tabChtml.setContent(ctn);

//        entradas.insertar(nombre, "CHTML", entrada);//Ingresando a la lista de entradas
//        tabChtml.getContent().set
//        tabChtml.getContent().setClip(contenido);
        tabConsola.getTabs().add(tabChtml);
    }
     
    
    public void crearSplit() {
        SplitPane split = new SplitPane();
        split.setOrientation(Orientation.VERTICAL);
//        split.setDividerPosition(12, 0.71);

        split.setDividerPositions(0.9);
        AnchorPane.setBottomAnchor(split, 2.0);
        AnchorPane.setLeftAnchor(split, 2.0);
        AnchorPane.setRightAnchor(split, 2.0);
        AnchorPane.setTopAnchor(split, 40.0);
        
        crearAreaWeb(split);
        crearParteCosola(split);
        contenedor.getChildren().add(split);
        
    }
    
    public void crearAreaWeb(SplitPane split) {
        AnchorPane areaWeb = new AnchorPane();
        ScrollPane scroll = new ScrollPane();
        
        AnchorPane.setBottomAnchor(scroll, 0.0);
        AnchorPane.setLeftAnchor(scroll, 0.0);
        AnchorPane.setRightAnchor(scroll, 0.0);
        AnchorPane.setTopAnchor(scroll, 0.0);

//        AnchorPane panAreaWeb=new AnchorPane();
//        //scroll.get
//        panAreaWeb.setStyle("-fx-background-color: blue;");
//        
//        panAreaWeb.setPrefSize(400, 300);
//        scroll.setContent(panAreaWeb);
//        VBox panAreaWeb = new VBox();
//        padreWeb.setStyle("-fx-background-color: red;");
        padreWeb.setPrefWidth(400);

//        padreWeb.setPrefHeight(400);
//        Label la=new Label("hola");
//        padreWeb.getChildren().add(la);
//        padreWeb.setPrefSize(400, 300);
        redimensionar(scroll, padreWeb);
        
        scroll.setContent(padreWeb);
        
        areaWeb.getChildren().add(scroll);
        split.getItems().add(areaWeb);
    }
    
    public void crearParteCosola(SplitPane split) {
        AnchorPane areaConsola = new AnchorPane();
        
        tabConsola = new TabPane();
//        tabConsola.setStyle("-fx-background-color: blue;");
        AnchorPane.setBottomAnchor(tabConsola, 0.0);
        AnchorPane.setLeftAnchor(tabConsola, 0.0);
        AnchorPane.setRightAnchor(tabConsola, 0.0);
        AnchorPane.setTopAnchor(tabConsola, 0.0);
        areaConsola.setPrefSize(400, 300);
        areaConsola.getChildren().add(tabConsola);
        
        split.getItems().add(areaConsola);
    }
    
    public void redimensionar(ScrollPane scro, AnchorPane pan) {
        final ChangeListener<Number> listener = new ChangeListener<Number>() {
            final Timer timer = new Timer(); // uses a timer to call your resize method
            TimerTask task = null; // task to execute after defined delay
            final long delayTime = 200; // delay that has to pass in order to consider an operation done

            @Override
            public void changed(ObservableValue<? extends Number> observable, Number oldValue, final Number newValue) {
                
                pan.setPrefWidth(scro.getWidth() - 10);
//                 pe.setPrefSize(sta.getWidth(), sta.getHeight());
            }
        };
        scro.widthProperty().addListener(listener);

//         sta.heightProperty().addListener(listener);
    }
    
    private String readLineByLineJava8(String filePath) {
        StringBuilder contentBuilder = new StringBuilder();
        
        try (Stream<String> stream = Files.lines(Paths.get(filePath), StandardCharsets.UTF_8)) {
            stream.forEach(s -> contentBuilder.append(s).append("\n"));
        } catch (IOException e) {
        }
        
        return contentBuilder.toString();
    }
    
    public class listaEntradas {//Todas las entradas a ejecutar

        public List<nodoText> lstTexto = new ArrayList<>();
        
        public void insertar(String nombre, String tipo, String area) {
            nodoText nod = new nodoText();

            //AQUI VOY A CREAR EL TEXT AREA, JEJEJE
            Tab pesta = new Tab(nombre);
            TextArea entrada = new TextArea(area);//tengo que abrir el archivo 
            TextArea lineas = new TextArea();
            String numeros = "";
            for (int i = 0; i < 999; i++) {
                numeros += String.valueOf(i) + "\n";
            }
            lineas.setText(numeros);
            entrada.scrollTopProperty().addListener((obs, oldVal, newVal) -> {
                lineas.setScrollTop((double) newVal);
            });
            
            lineas.setEditable(false);
            lineas.setDisable(true);
            
            AnchorPane ctn = new AnchorPane();

//        contenido.setStyle("-fx-background-color: green;");
            AnchorPane.setBottomAnchor(entrada, 10.0);
            AnchorPane.setLeftAnchor(entrada, 40.0);
            AnchorPane.setRightAnchor(entrada, 10.0);
            AnchorPane.setTopAnchor(entrada, 10.0);
            
            AnchorPane.setBottomAnchor(lineas, 10.0);
            AnchorPane.setLeftAnchor(lineas, 0.0);
            AnchorPane.setTopAnchor(lineas, 10.0);
            
            ctn.getChildren().setAll(lineas, entrada);
            
            pesta.setContent(ctn);

            //fin 
            nod.insertar(nombre, tipo, entrada, pesta);
            
            lstTexto.add(nod);
        }
        
        public void imprimir() {
            for (nodoText text : lstTexto) {
                
                System.out.println("Nombre->" + text.nombre + "|tipo->" + text.tipo + "|Contenido");
            }
        }
        
        public void pintarEnPanel(TabPane tabConsola) {
            for (nodoText text : lstTexto) {
                tabConsola.getTabs().add(text.tab);
            }
        }
        
        public String getHthmlText() {
            
            String retorno = "";
            for (nodoText text : lstTexto) {
                if (text.tipo.equals("CHTML")) {
                    retorno = text.area.getText();
                    break;
                }
            }
            return retorno;
        }
        
        public class nodoText {
            
            public String nombre = "";
            public String tipo = "";//chtml, cjs, ccss
            public TextArea area = new TextArea();
            public Tab tab = new Tab("");
            
            public void insertar(String nombre, String tipo, TextArea area, Tab pestania) {
                this.nombre = nombre;
                this.tipo = tipo;
                this.area = area;
                this.tab = pestania;
            }
        }
    }
    
}
