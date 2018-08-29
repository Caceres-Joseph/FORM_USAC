/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package GUI;

 
import GUI.Elements.crearTab;
import GUI.Elements.newTab;
import GUI.Elements.xForm;
import java.awt.ScrollPane;
import java.io.FileNotFoundException;
import java.net.URL;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.geometry.Pos;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;

/**
 * FXML Controller class
 *
 * @author joseph
 */
public class Navegador implements Initializable {

    /**
     * Initializes the controller class.
     */
    @FXML
    private VBox vBox1;

    @FXML
    private TabPane tabSuprema;

    @FXML
    private StackPane stackPanel;
    @FXML
    private AnchorPane supremo;

    @FXML
    private Button btnIr;

    @FXML
    private Button btnBoton1;

    @FXML
    void btnIr(ActionEvent event) { 
         

        Button hol = new Button();
        hol.setId("hoa");

    }

    @FXML
    void btnSalir(ActionEvent event) {
        System.out.println("Finalizado...");
        System.exit(0);

    }

    @FXML
    void btnPrueba(ActionEvent event) {
//        supremo.getStylesheets().add("/GUI/Estilos.css");
        agregarTab();
//        stackPanel.setAlignment(Pos.CENTER);
//         supremo.setStyle("#hola{\n"
//                 + "    -fx-text-fill: #006464;\n"
//                 + "    -fx-background-color:green;\n"
//                 + "    -fx-border-radius: 20;\n"
//                 + "    -fx-background-radius: 20;\n"
//                 + "    -fx-padding: 5;\n"
//                 + "}");
//         
//         btnBoton1.setId("supremo");
    }

    @FXML
    void btnResize(ActionEvent event) {
        vBox1.setPrefWidth(900);

    }

    @FXML
    public void exitApplication(ActionEvent event) {
        System.out.println("salir");
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }

    public void agregarTab() {  
        xForm xform=new xForm();
        tabSuprema.getTabs().add(xform.retornaTab());
    }

}
